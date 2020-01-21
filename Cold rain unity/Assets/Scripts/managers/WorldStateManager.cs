using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.managers
{
    public class WorldStateManager : Node, SavingModule
    {
        private WorldStateManager() { }
        public static WorldStateManager Instance;

        public override void Initiate()
        {
            base.Initiate();
            Instance = this;
        }
        
        public Dictionary<int, Action<int>> ActionDictionary = new Dictionary<int, Action<int>>();
        private Dictionary<int, WorldState> worldStateDict = new Dictionary<int, WorldState>();
        
        private void RaiseWorldStateChanged(int id)
        {
            WorldState state;
            if (worldStateDict.TryGetValue(id, out state))
                state.RaiseWorldStateChanged();
        }

        public Action<int> Register(int id)
        {
            if (!worldStateDict.ContainsKey(id))
            {
                worldStateDict.Add(id, new WorldState(0));
                if (!ActionDictionary.ContainsKey(id))
                {
                    ActionDictionary.Add(id, new Action<int>(RaiseWorldStateChanged));
                }
                return ActionDictionary[id];
            }
            return ActionDictionary[id];
        }

        public bool SetState(int id, int state)
        {
            if (worldStateDict.ContainsKey(id))
            {
                worldStateDict[id].state = state;
                ActionDictionary?[id]?.Invoke(state);
                return true;
            }
            return false;
        }

        internal int GetState(int p)
        {
            return worldStateDict[p].state;
        }

        public void Load()
        {
            int s = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "size"), 0);

            worldStateDict = new Dictionary<int, WorldState>(s);

            for(int i = 0; i < s; i++)
            {
                Register(i);
                SetState(i, PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"worldstate-{i}"), 0));
            }
        }

        public void Save()
        {
            PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, "size"), worldStateDict.Count);

            for(int i = 0; i < worldStateDict.Count; i++)
            {
                PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"worldstate-{i}"), worldStateDict[i].state);
            }
        }

    }
}
