using Assets.Scripts.gameinterfaces.console;
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
        
        public event Action LevelUp;

        public void AddExp(int toAdd)
        {
            exp = exp + toAdd;
            CheckForLevelUp();
        }

        public void AddExp(float toAdd)
        {
            AddExp((int)Math.Floor(toAdd));
        }

        public void SetExp(int xp)
        {
            exp = xp;
            level = ProgressCalculator.GetLevelByExperience(xp);
        }

        public void SetLevel(int level)
        {
            this.level = level;
            exp = ProgressCalculator.GetExperienceByLevel(level);
        }

        internal int GetExp()
        {
            return exp;
        }

        private void CheckForLevelUp()
        {
            if (ProgressCalculator.GetLevelByExperience(exp) > level)
            {
                level = ProgressCalculator.GetLevelByExperience(exp);
                OnLevelUp();
                return;
            }
        }

        public virtual void OnLevelUp()
        {
            GameConsole.Instance.SendConsoleMessage($"Congratulations, you leveled up to level {level} {Name}.");
            LevelUp?.Invoke();
            //EventHandler handler = LevelUp;
            //handler?.Invoke(this, args);
        }

        public int GetLevel() => level;
        
        public void Load()
        {

        }

        public void Save()
        {

        }
    }
}
