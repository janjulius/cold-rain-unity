using Assets.Scripts.math;
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
        protected int level = 1;
        protected int exp = 0;

        public void AddExp(int toAdd)
        {
            exp = exp + toAdd;
            CheckForLevelUp();
        }

        //public void SetExp(int xp)
        //{
        //
        //}

        //public void SetLevel(int level)
        //{
        //
        //}

        private void CheckForLevelUp()
        {
            if (ProgressCalculator.GetLevelByExperience(exp) > level)
            {
                //player levels up
                level = ProgressCalculator.getExperienceByLevel(exp);
                return;
            }
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
