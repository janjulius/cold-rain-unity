using Assets.Scripts.logger;
using Assets.Scripts.styles.hairstyles;
using Assets.Scripts.util;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.databases.appearance
{
    class BeardDatabase : CRDatabase
    {

        public override void BuildDatabase()
        {
            CrLogger.Log(this, "Building beard database...");
            items = new List<DbElement>()
            {
                    new BeardStyle(0, "Bald"),
                    new BeardStyle(1, "Short beard"),
                    new BeardStyle(2, "Medium beard"),
                    new BeardStyle(3, "Long beard")
            };
            EquipmentArray = new EquipmentItemMultiArray[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                EquipmentArray[i] = new EquipmentItemMultiArray();
                EquipmentArray[i].EquipSprites = new Sprite[4];
                for (int j = 0; j < EquipmentArray[i].EquipSprites.Length; j++)
                {
                    EquipmentArray[i].EquipSprites[j] = Resources.Load<Sprite>($"Beard/{i}/beard_{i}_{j}");
                }
            }

            CrLogger.Log(this, "The hair database was built succesfully");
        }

        public Sprite[] GetBeardStyleEquipements(int id)
        {
            //catch exception because hair could not be added
            return EquipmentArray[id].EquipSprites;
        }
    }
}
