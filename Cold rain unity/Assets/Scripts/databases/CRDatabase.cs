using Assets.Scripts.logger;
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

        /// <summary>
        /// If this is false, the database will not be initiated on startup but requires being 
        /// initialised by another class.
        /// This will also need to be called before this <see cref="Initiate()"/> is called.
        /// </summary>
        protected bool CallSelf = true;

        public override void Initiate()
        {
            base.Initiate();
            if (CallSelf)
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

        protected string GetSideLetter(int i)
        {
            if (i == 0)
                return "F";
            if (i == 1)
                return "I";
            if (i == 2)
                return "B";
            if (i == 3)
                return "O";
            CrLogger.Log(this, "GetSideLetter returned default value, this could mean an incorrect value was given.", CrLogger.LogType.WARNING);
            return "F";
        }

        public abstract void BuildDatabase();
    }
}
