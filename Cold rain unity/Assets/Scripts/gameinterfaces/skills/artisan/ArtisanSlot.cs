using Assets.Scripts.databases;
using Assets.Scripts.game.consumables.consumable;
using Assets.Scripts.gameinterfaces.skills.cooking;
using Assets.Scripts.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.skills.artisan
{
    public class ArtisanSlot : Node
    {
        public Image ResultImage;
        public TextMeshProUGUI ResultNameText;
        public TextMeshProUGUI DescriptionText;

        private ArtisanInterface parentInterface;
        private ArtisanRecipe recipe;

        public void Load(ItemDatabase itemdb, ArtisanRecipe recipe, ArtisanInterface parentInterface, string text)
        {
            this.recipe = recipe;
            this.parentInterface = parentInterface;
            Item itemResult = itemdb.GetItem(recipe.resultId);
            ResultImage.sprite = itemResult.InventoryIcon;
            ResultNameText.text = itemResult.Name;
            DescriptionText.text = text;
        }

        public void OnMouseClick()
        {
            parentInterface?.ProcessSelectedRecipe(recipe);
        }

        public void SetText(string text)
        {
            DescriptionText.text = text;
        }
    }
}
