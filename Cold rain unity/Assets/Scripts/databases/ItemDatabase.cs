using Assets.Scripts.item;
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
            print("Building item database...");
            items = new List<DbElement>()
            {
                new Item(0, "Hedgehog Plushie", false, new Stats(), new Skills(), "A nice plushie, it says POG on the label.", false, true, InventoryIcon[0], EquipmentArray[0]),
                new Item(1, "Rat Plushie", false, new Stats(), new Skills(), "When you squeeze it, it squeeks!", false, true, InventoryIcon[1], EquipmentArray[1]),
                new Item(2, "Cat Plushie", false, new Stats(), new Skills(), "Meeeeeeeow", false, true, InventoryIcon[2], EquipmentArray[2]),
                new Item(3, "Dog Plushie", false, new Stats(), new Skills(), "He doesn't do much but he's a good boy.", false, true, InventoryIcon[3], EquipmentArray[3]),
                new Item(4, "Rodent trap", false, new Stats(), new Skills(), "Used to catch rodents.", false, true, InventoryIcon[4], EquipmentArray[4]),
                new Item(5, "Bird trap", false, new Stats(), new Skills(), "Conveniently made with two spoons.", false, true, InventoryIcon[5], EquipmentArray[5]),
                new Item(6, "Deer bait", false, new Stats(), new Skills(), "The smell lures deer.", false, true, InventoryIcon[6], EquipmentArray[6]),
                new Item(7, "Game call", false, new Stats(), new Skills(), "What a weird sound!", false, true, InventoryIcon[7], EquipmentArray[7]),

            };
            if (Settings.SHOW_DEBUG_MESSAGES)
                print($"Succesfully created all the items in the database size:{items}");
            print("The item database was built succesfully");
        }

        public Item GetItem(int id)
        {
            Item it;
            it = items.Where(i => i.Id == id).FirstOrDefault() as Item;
            return it;
        }
    }
}
