using Assets.Scripts.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.databases
{
    public abstract class CRDatabase : Node
    {
        protected List<DbElement> items = new List<DbElement>();

        protected EquipmentItemMultiArray[] EquipmentArray;

        public override void Initiate()
        {
            base.Initiate();
            BuildDatabase();
        }

        /// <summary>
        /// Gets an element with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DbElement GetElementById(int id) 
        {
            DbElement it;
            it = items.Where(i => i.Id == id).FirstOrDefault();
            return it;
        }

        public abstract void BuildDatabase();
    }
}
