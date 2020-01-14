using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.saving;
using System;
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
            Stage = 1000;
        }

        public void SetStage(int stage)
        {
            Stage = stage;
        }

        public bool IsStarted()
        {
            return Stage >= 1 && Stage <= 1000;
        }

        public bool IsCompleted() =>
            Stage >= 1000;


        internal void Accept()
        {
            if (Stage == 0)
            {
                GameConsole.Instance.SendConsoleMessage($"You accepted the quest: {Name}");
                Stage++;
            }
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
