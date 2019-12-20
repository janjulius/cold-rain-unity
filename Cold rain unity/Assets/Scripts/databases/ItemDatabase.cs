using Assets.Scripts.item;
using Assets.Scripts.logger;
using Assets.Scripts.node;
using Assets.Scripts.stats;
using Assets.Scripts.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.databases
{
    /// <summary>
    /// Items stored in this game
    /// </summary>
    public class ItemDatabase : CRDatabase
    {
        /// <summary>
        /// The inventory icons
        /// </summary>
        public Sprite[] InventoryIcon;
        
        public EquipmentItemMultiArray[] EquipmentArray;
        
        /// <summary>
        /// Builds the item database
        /// </summary>
        public override void BuildDatabase()
        {
            CrLogger.Log(this, "Building item database...");
            if (InventoryIcon.Length != EquipmentArray.Length)
            {
                CrLogger.Log(this, "The size of InventoryIcon[] and EquipmentArray[] in ItemDatabase are not the same, please review", CrLogger.LogType.ERROR);
                CrLogger.Log(this, "ITEM DATABASE WAS NOT INITIALISED", CrLogger.LogType.ERROR);
                return;
            }

            items = new List<DbElement>()
            {
                new Item(0, "Hedgehog Plushie", false, new Stats(), new Skills(), "A nice plushie, it says POG on the label.", false, true),
                new Item(1, "Rat Plushie", false, new Stats(), new Skills(), "When you squeeze it, it squeeks!", false, true),
                new Item(2, "Cat Plushie", false, new Stats(), new Skills(), "Meeeeeeeow", false, true),
                new Item(3, "Dog Plushie", false, new Stats(), new Skills(), "He doesn't do much but he's a good boy.", false, true),
                new Item(4, "Rodent trap", false, new Stats(), new Skills(), "Used to catch rodents.", false, true),
                new Item(5, "Bird trap", false, new Stats(), new Skills(), "Conveniently made with two spoons.", false, true),
                new Item(6, "Deer bait", false, new Stats(), new Skills(), "The smell lures deer.", false, true),
                new Item(7, "Game call", false, new Stats(), new Skills(), "What a weird sound!", false, true),

            };

            for(int i = 0; i < InventoryIcon.Length; i++)
                ((Item)items[i]).SetSprites(InventoryIcon[i], EquipmentArray[i]);

            CrLogger.Log(this, "The item database was built succesfully");
        }

        public Item GetItem(int id)
        {
            Item it;
            it = items.Where(i => i.Id == id).FirstOrDefault() as Item;
            return it;
        }
    }
}
