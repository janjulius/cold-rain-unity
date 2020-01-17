using Assets.Scripts.databases;
using Assets.Scripts.databases.game;
using Assets.Scripts.game.consumables.consumable;
using Assets.Scripts.item;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.skills.artisan
{
    public class ArtisanInterface : GameInterface
    {
        public ArtisanRecipeDatabase artisanRecipes;
        public ItemDatabase itemDatabase;

        public GameObject ScrollViewContent;
        public GameObject ToMakeScrollViewContent;
        
        public Slider AmountSlider;

        public TextMeshProUGUI MinText;
        public TextMeshProUGUI MaxText;
        public TextMeshProUGUI CurText;

        public Image RecipeImage;
        public TextMeshProUGUI RecipeTitle;
        public TextMeshProUGUI RecipeDescription;

        public GameObject ArtisanSlotPrefab;

        public List<ArtisanRecipe> readyRecipes = new List<ArtisanRecipe>();
        private ArtisanRecipe selectedRecipe;
        private Item itemResult;

        public int ReqBaseTime { get; private set; }

        public override void Create(Player player)
        {
            artisanRecipes = artisanRecipes ?? Camera.main.GetComponent<ArtisanRecipeDatabase>();
            itemDatabase = itemDatabase ?? Camera.main.GetComponent<ItemDatabase>();
            this.player = player;

            AmountSlider.onValueChanged.AddListener(SetCurText);

            Refresh();
        }

        public override void Refresh()
        {
            Clear();

            foreach (ArtisanRecipe ar in artisanRecipes.GetItems())
            {
                if ((player.InventoryContainer.GetAmount(ar.materialId) >= ar.materialAmount 
                    && player.InventoryContainer.GetAmount(ar.materialId2) >= ar.materialAmount2))
                {
                    GameObject slot = Instantiate(ArtisanSlotPrefab, ScrollViewContent.transform);
                    slot.GetComponent<ArtisanSlot>().Load(itemDatabase, ar, this, itemDatabase.GetItem(ar.resultId).Examine);
                }

            }
        }

        internal void ProcessSelectedRecipe(ArtisanRecipe recipe)
        {
            RecipeImage.gameObject.SetActive(true);
            selectedRecipe = recipe;
            itemResult = itemDatabase.GetItem(recipe.resultId);
            
            AmountSlider.minValue = 1;
            AmountSlider.maxValue = MinAmountOfMaterials(recipe);
            MinText.text = AmountSlider.minValue.ToString();
            MaxText.text = AmountSlider.maxValue.ToString();
            SetCurText(AmountSlider.value);
            
            RecipeTitle.text = itemResult.Name;
            RecipeImage.sprite = itemResult.InventoryIcon;
        }

        private float MinAmountOfMaterials(ArtisanRecipe recipe)
        {
            return Mathf.Min(
                Mathf.Floor(player.InventoryContainer.GetAmount(recipe.materialId) / recipe.materialAmount),
                Mathf.Floor(player.InventoryContainer.GetAmount(recipe.materialId2) / recipe.materialAmount2));
        }

        internal void AddToPreparation(ArtisanRecipe recipe, int amnt)
        {
            GameObject slot = Instantiate(ArtisanSlotPrefab, ToMakeScrollViewContent.transform);
            ArtisanSlot slotObj = slot.GetComponent<ArtisanSlot>();
            slotObj.Load(itemDatabase, recipe, this, "1x");
            for (int i = 0; i < amnt; i++)
            {
                if (player.InventoryContainer.Remove(recipe.materialId, recipe.materialAmount) 
                    && player.InventoryContainer.Remove(recipe.materialId2, recipe.materialAmount2))
                {
                    slotObj.SetText($"{amnt}x");
                }
            }
        }

        public void SetCurText(float i)
        {
            CurText.text = i.ToString();
        }

        public void Clear()
        {
            foreach (Transform t in ScrollViewContent.transform)
                Destroy(t.gameObject);
            foreach (Transform t in ToMakeScrollViewContent.transform)
                Destroy(t.gameObject);
        }
    }
}
