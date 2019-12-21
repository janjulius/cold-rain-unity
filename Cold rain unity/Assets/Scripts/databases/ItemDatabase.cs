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
        private Sprite[] InventoryIcon;
        
        /// <summary>
        /// Builds the item database
        /// </summary>
        public override void BuildDatabase()
        {
            CrLogger.Log(this, "Building item database...");

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

            EquipmentArray = new EquipmentItemMultiArray[items.Count];
            InventoryIcon = new Sprite[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                EquipmentArray[i] = new EquipmentItemMultiArray();
                EquipmentArray[i].EquipSprites = new Sprite[4];
                for (int j = 0; j < EquipmentArray[i].EquipSprites.Length; j++)
                {
                    InventoryIcon[i] = Resources.Load<Sprite>($"Item/{i}/item_{i}");
                    EquipmentArray[i].EquipSprites[j] = Resources.Load<Sprite>($"Item/{i}/item_{i}_{j}");
                }
            }

            //for(int i = 0; i < InventoryIcon.Length; i++)
            //    ((Item)items[i]).SetSprites(InventoryIcon[i], EquipmentArray[i]);



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
