using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.skills
{
    public class Skill : SavingModule
    {
        protected int level = 0;
        protected int exp = 0;

        public void AddExp(int toAdd)
        {

        }

        public void SetExp(int xp)
        {

        }

        public void SetLevel(int level)
        {

        }
        
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
