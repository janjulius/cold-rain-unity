using Assets.Scripts.databases;
using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.quest
{
    [Serializable]
    public abstract class Quest : SavingModule
    {
        public int Id { protected set; get; }
        public string Name { protected set; get; }
        public string Description { protected set; get; }
        public string Rewards { protected set; get; }
        public int Stage { protected set; get; }

        public abstract Quest Initialize();

        public abstract void GiveRewards(Player player);

        public void Finish(params string[] rewards)
        {

        }

        public void SetStage(int stage)
        {
            Stage = stage;
        }

        public bool IsStarted() {
            return Stage >= 0 && Stage <= 100;
        }

        public void Load()
        {
            Stage = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsQuestKey(this, Name));
        }

        public void Save()
        {
            PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsQuestKey(this, Name), Stage);
        }
    }
}
