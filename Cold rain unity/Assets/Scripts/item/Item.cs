using Assets.Scripts.stats;
using Assets.Scripts.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.item
{
    public class Item
    {
        public int Id { private set; get; }
        public string Name { private set; get; }
        public int Amount { private set; get; }
        public bool Stackable { private set; get; }
        public Stats Stats { private set; get; }
        public string Examine { private set; get; }
        public bool QuestItem { private set; get; }
        public bool Equipable { private set; get; }

        public Sprite InventoryIcon { private set; get; }

        /// <summary>
        /// 0 = Front, 1 = FACE RIGHT, 2 = Back, 3 = FACE LEFT
        /// </summary>
        public Sprite[] EquipSprites { private set; get; }

        public Item(int id, string name, int amount, bool stackable, Stats stats, string examine, bool questItem, bool equipable, Sprite inventoryIcon, EquipmentItemMultiArray eqima)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Stackable = stackable;
            Stats = stats;
            Examine = examine;
            QuestItem = questItem;
            Equipable = equipable;
            InventoryIcon = inventoryIcon;
            EquipSprites = eqima.EquipSprites;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nExamine: {Examine}\nAmount: {Amount}\nStackable: {Stackable}\nStats: {Stats}\nQuestItem: {QuestItem}\nEquipable: {Equipable}\nInventoryIcon: {InventoryIcon}\nEquipSprites: {EquipSprites}";
        }
    }
}
