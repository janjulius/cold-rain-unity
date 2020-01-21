using Assets.Scripts.logger;
using Assets.Scripts.styles.clothingstyles;
using Assets.Scripts.styles.hairstyles;
using Assets.Scripts.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.databases.appearance
{
    public class LegsDatabase : CRDatabase
    {
        public override void BuildDatabase()
        {
            CrLogger.Log(this, "Building legs database...");
            items = new List<DbElement>()
            {
                new LegStyle(0, "Back skirt"),
                new LegStyle(1, "Back Legs"),
            };

            EquipmentArray = new EquipmentItemMultiArray[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                EquipmentArray[i] = new EquipmentItemMultiArray();
                EquipmentArray[i].EquipSprites = new Sprite[4];
                for (int j = 0; j < EquipmentArray[i].EquipSprites.Length; j++)
                {
                    string lookfor = $"Legs/{i}/legs_{i}_{GetSideLetter(j)}";
                    EquipmentArray[i].EquipSprites[j] = Resources.Load<Sprite>(lookfor);
                }
            }
        }

        public Sprite[] GetLegStyleEquipements(int id)
        {
            //catch exception because legs could not be added
            return EquipmentArray[id].EquipSprites;
        }

    }
}
