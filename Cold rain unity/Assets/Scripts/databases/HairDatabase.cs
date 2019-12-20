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
        public EquipmentItemMultiArray[] equipmentItemMultiArray;

        public override void BuildDatabase()
        {
            CrLogger.Log(this, "Building hair database...");
            items = new List<DbElement>()
            {
                new HairStyle(0, "Bald"),
                new HairStyle(1, "Classic")
            };
            CrLogger.Log(this, "The hair database was built succesfully");
        }

        public Sprite[] GetHairStyleEquipements(int id)
        {
            return equipmentItemMultiArray[id].EquipSprites;
        }
    }
}
