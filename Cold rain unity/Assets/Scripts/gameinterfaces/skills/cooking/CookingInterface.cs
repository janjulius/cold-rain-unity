using Assets.Scripts.databases;
using Assets.Scripts.databases.game;
using Assets.Scripts.game.consumables.consumable;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.skills.cooking
{
    public class CookingInterface : GameInterface
    {
        public ConsumableDatabase consumeableDatabase;
        public ItemDatabase itemDatabase;
        
        public GameObject ScrollViewContent;

        public Button CookButton;
        public Slider AmountSlider;

        public TextMeshProUGUI MinText;
        public TextMeshProUGUI MaxText;
        public TextMeshProUGUI CurText;

        public Image RecipeImage;
        public TextMeshProUGUI RecipeTitle;
        public TextMeshProUGUI RecipeDescription;
        
        public GameObject CookingSlotPrefab;

        private Food selectedFood;
        private int ReqBaseTime = 0;
        private Item itemResult;
        
        public override void Create(Player player)
        {
            consumeableDatabase = consumeableDatabase ?? Camera.main.GetComponent<ConsumableDatabase>();
            itemDatabase = itemDatabase ?? Camera.main.GetComponent<ItemDatabase>();
            this.player = player;
            AmountSlider.onValueChanged.AddListener(SetCurText);
            Refresh();
        }

        public override void Refresh()
        {
            Clear();
            CookButton.interactable = false;

            foreach (Food food in consumeableDatabase.GetItems())
            {
                if (player.InventoryContainer.Contains(food.rawId) 
                    && (food.addedId == -1 ? true : player.InventoryContainer.Contains(food.addedId))
                    && player.skills.GetSkill(SKILLS.COOKING).GetLevel() >= food.reqLevel)
                {
                    GameObject slot = Instantiate(CookingSlotPrefab, ScrollViewContent.transform);
                    slot.GetComponent<CookingSlot>().Load(itemDatabase, food, this);
                }
            }
        }

        public void ProcessSelectedFood(Food food)
        {
            CookButton.interactable = true;
            RecipeImage.gameObject.SetActive(true);
            selectedFood = food;
            itemResult = itemDatabase.GetItem(selectedFood.cookedId);

            if (food.addedId == -1)
                ReqBaseTime = 10;
            else
                ReqBaseTime = 5;

            AmountSlider.minValue = 1;
            AmountSlider.maxValue = MinAmountOfFoodMaterials(food);
            MinText.text = AmountSlider.minValue.ToString();
            MaxText.text = AmountSlider.maxValue.ToString();
            SetCurText(AmountSlider.value);

            UpdateRecipeDescription();
            RecipeTitle.text = itemResult.Name;
            RecipeImage.sprite = itemResult.InventoryIcon;
        }

        private string GetRecipeDescription()
        {
            return RecipeDescription.text = $"{itemResult.Examine}\nCooking Time: {AmountSlider.value * ReqBaseTime} minutes\nExp: {selectedFood.givenExperience * AmountSlider.value}.";
        }

        private void UpdateRecipeDescription()
        {
            RecipeDescription.text = GetRecipeDescription();
        }

        public void SetCurText(float i)
        {
            CurText.text = i.ToString();
            UpdateRecipeDescription();
        }

        private int MinAmountOfFoodMaterials(Food food)
        {
            int result = 0;
            int freeslots = player.InventoryContainer.GetFreeSlots();
            if (food.addedId == -1)
            {
                result = player.InventoryContainer.GetAmount(food.rawId);
                result = result > freeslots ? freeslots : result;
                return result;
            }
            else
            {
                int min = Math.Min(player.InventoryContainer.GetAmount(food.rawId), player.InventoryContainer.GetAmount(food.addedId));
                result = min > freeslots ? freeslots : min;
                return result;
            }
        }

        public void Cook()
        {
            if(selectedFood != null && itemResult != null)
            {
                int amount = (int)AmountSlider.value;
                if (player.InventoryContainer.Remove(selectedFood.rawId, amount))
                {
                    bool useAddedFood = selectedFood.addedId != -1;
                    bool pass = !useAddedFood;
                    if (useAddedFood)
                    {
                        pass = player.InventoryContainer.Remove(selectedFood.addedId, amount);
                    }
                    if (pass)
                    {
                        player.InventoryContainer.Add(itemResult.Id, amount);
                        player.skills.GetSkill(SKILLS.COOKING).AddExp((int)Math.Floor(AmountSlider.value * selectedFood.givenExperience));
                        Camera.main.GetComponent<GameManager>().IncreaseTime((int)(AmountSlider.value * ReqBaseTime));
                        Clear();
                        ToggleActive();
                    }
                }
            }
        }

        public void OnEnable()
        {
        }

        public void Clear()
        {
            foreach (Transform t in ScrollViewContent.transform)
                Destroy(t.gameObject);
            AmountSlider.minValue = 0;
            AmountSlider.maxValue = 0;
            MinText.text = "-";
            MaxText.text = "-";
            RecipeDescription.text = "";
            RecipeTitle.text = "";
            RecipeImage.gameObject.SetActive(false);
        }
    }
}
