using Assets.Scripts.databases;
using Assets.Scripts.skills;
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
    [Serializable]
    public class Item : DbElement
    {
        public string Name { private set; get; }
        public int Amount { set; get; }
        public bool Stackable { private set; get; }
        public Stats Stats { private set; get; }
        public SkillRequirement Requirements { private set; get; }
        public string Examine { private set; get; }
        public bool QuestItem { private set; get; }
        public bool Equipable { private set; get; }
        public EquipmentType EquipmentType{ private set; get;}
        public int Charges { private set; get; }
        
        public Sprite InventoryIcon { private set; get; }

        /// <summary>
        /// 0 = Front, 1 = FACE RIGHT, 2 = Back, 3 = FACE LEFT
        /// </summary>
        public Sprite[] EquipSprites { private set; get; }

        public Item(int id, string name, bool stackable, Stats stats, SkillRequirement requirements, string examine, bool questItem, bool equipable, EquipmentType equipmentType)
        {
            Id = id;
            Name = name;
            Stackable = stackable;
            Amount = 1;
            Stats = stats;
            Requirements = requirements;
            Examine = examine;
            QuestItem = questItem;
            Equipable = equipable;
            this.EquipmentType = equipmentType;
            Charges = 0;
        }

        public void SetSprites(Sprite inventoryIcon, EquipmentItemMultiArray eqima)
        {
            InventoryIcon = inventoryIcon;
            EquipSprites = eqima.EquipSprites;
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nExamine: {Examine}\nAmount: {Amount}\nStackable: {Stackable}\nStats: {Stats}\nQuestItem: {QuestItem}\nEquipable: {Equipable}\nInventoryIcon: {InventoryIcon}\nEquipSprites: {EquipSprites}";
        }
    }
}
