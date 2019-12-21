using Assets.Scripts.databases;
using Assets.Scripts.item;
using Assets.Scripts.logger;
using Assets.Scripts.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.styles.hairstyles
{
    public class HairDatabase : CRDatabase
    {

        public override void BuildDatabase()
        {
            CrLogger.Log(this, "Building hair database...");
            items = new List<DbElement>()
            {
                new HairStyle(0, "Bald"),
                new HairStyle(1, "Classic"),
                new HairStyle(2, "Monk")
            };
            EquipmentArray = new EquipmentItemMultiArray[items.Count];
            for(int i = 0; i < items.Count; i++)
            {
                print(i);
                EquipmentArray[i] = new EquipmentItemMultiArray();
                EquipmentArray[i].EquipSprites = new Sprite[4];
                for(int j = 0; j < EquipmentArray[i].EquipSprites.Length; j++)
                {
                    EquipmentArray[i].EquipSprites[j] = Resources.Load<Sprite>($"Hair/{i}/hair_{i}_{j}");
                }
            }

            CrLogger.Log(this, "The hair database was built succesfully");
        }

        public Sprite[] GetHairStyleEquipements(int id)
        {
            return EquipmentArray[id].EquipSprites;
        }
    }
}
