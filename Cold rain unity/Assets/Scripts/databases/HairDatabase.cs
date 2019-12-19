using Assets.Scripts.databases;
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
        public EquipmentItemMultiArray[] equipmentItemMultiArray;

        public override void BuildDatabase()
        {
            print("Building hair database...");
            items = new List<DbElement>()
            {
                new HairStyle(0, "Bald"),
                new HairStyle(1, "Classic")
            };
            print("The hair database was built succesfully");
        }

        public Sprite[] GetHairStyleEquipements(int id)
        {
            return equipmentItemMultiArray[id].EquipSprites;
        }
    }
}
