using Assets.Scripts.math;
using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.skills
{
    public abstract class Skill : Node, SavingModule
    {
        protected int level = 1;
        protected int exp = 0;

        public abstract string Name
        {
            get;
        }

        public event EventHandler LevelUp;

        public void AddExp(int toAdd)
        {
            exp = exp + toAdd;
            CheckForLevelUp();
        }

        public void SetExp(int xp)
        {
            this.exp = xp;
            level = ProgressCalculator.GetLevelByExperience(xp);
        }

        public void SetLevel(int level)
        {
            this.level = level;
            exp = ProgressCalculator.getExperienceByLevel(level);
        }

        internal int GetExp()
        {
            return exp;
        }

        private void CheckForLevelUp()
        {
            if (ProgressCalculator.GetLevelByExperience(exp) > level)
            {
                //player levels up
                level = ProgressCalculator.getExperienceByLevel(exp);
                return;
            }
        }

        public virtual void OnLevelUp(EventArgs args)
        {
            EventHandler handler = LevelUp;
            handler?.Invoke(this, args);
        }

        public int GetLevel() => level;
        
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
