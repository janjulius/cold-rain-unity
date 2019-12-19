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
    public class ItemDatabase : MonoBehaviour
    {
        /// <summary>
        /// The items
        /// </summary>
        private static List<Item> items = new List<Item>();

        /// <summary>
        /// The inventory icons
        /// </summary>
        public Sprite[] InventoryIcon;

        public EquipmentItemMultiArray[] EquipmentArray;

        private void Awake()
        {
            BuildItemDatabase();
        }

        /// <summary>
        /// Builds the item database
        /// </summary>
        void BuildItemDatabase()
        {
            print("Building item database...");
            items = new List<Item>()
            {
                new Item(0, "Hedgehog Plushie", 1, false, new Stats(), "A nice plushie, it says POG on the label.", false, true, InventoryIcon[0], EquipmentArray[0]),
            };
            if (Settings.SHOW_DEBUG_MESSAGES)
                print($"Succesfully created all the items in the database size:{items}");
            print("The item database was built succesfully");
        }

        /// <summary>
        /// Gets an item with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Item GetItem(int id)
        {
            Item it = null;
            it = items.Where(i => i.Id == id).FirstOrDefault();
            return it;
        }
    }
}
