using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Assets.Scripts.skills;
using Assets.Scripts.math;
using Assets.Scripts.game.consumables.consumable;
using Assets.Scripts.databases;
using Assets.Scripts.item;

namespace Assets.Scripts.gameinterfaces.skills.cooking
{
    public class CookingSlot : Node
    {
        public Image ResultImage;
        public TextMeshProUGUI ResultNameText;
        public TextMeshProUGUI RequiredMaterialsText;

        private CookingInterface parentInterface;
        private Food food;

        public void Load(ItemDatabase itemdb, Food food, CookingInterface parentInterface)
        {
            this.food = food;
            this.parentInterface = parentInterface;
            Item itemResult = itemdb.GetItem(food.cookedId);
            ResultImage.sprite = itemResult.InventoryIcon;
            ResultNameText.text = itemResult.Name;
            RequiredMaterialsText.text = $"1x {itemdb.GetItem(food.rawId).Name}" + (food.addedId != -1 ? $" and 1x {itemdb.GetItem(food.addedId).Name}." : "."); 
        }

        public void OnMouseClick()
        {
            parentInterface?.ProcessSelectedFood(food);
        }

    }
}
