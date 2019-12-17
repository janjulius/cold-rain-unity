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
    public class ItemDatabase : MonoBehaviour
    {
        private static List<Item> items = new List<Item>();

        public Sprite[] InventoryIcon;

        public EquipmentItemMultiArray[] EquipmentArray;

        private void Awake()
        {
            BuildItemDatabase();
        }

        void BuildItemDatabase()
        {
            items = new List<Item>()
            {
                new Item(0, "Hedgehog Plushie", 1, false, new Stats(), "A nice plushie, it says POG on the label.", false, true, InventoryIcon[0], EquipmentArray[0]),
            };
            if (Settings.SHOW_DEBUG_MESSAGES)
                print($"Succesfully created all the items in the database size:{items}");
        }

        public static Item GetItem(int id)
        {
            Item it = items.Where(i => i.Id == id).FirstOrDefault();
            return it;
        }
    }
}
