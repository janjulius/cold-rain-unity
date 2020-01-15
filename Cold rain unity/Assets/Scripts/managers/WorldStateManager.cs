using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.managers
{
    public class WorldStateManager : Node
    {
        private Dictionary<int, WorldState> worldStateDict = new Dictionary<int, WorldState>();
        
        public WorldState this[int id]
        {
            get
            {
                if (!worldStateDict.ContainsKey(id))
                {
                    worldStateDict.Add(id, new WorldState(0));
                }
                return worldStateDict[id];
            }
            set
            {
                if (!worldStateDict.ContainsKey(id))
                {
                    worldStateDict.Add(id, new WorldState(0));
                }
                worldStateDict[id] = value;
            }
        }
        
        private void RaiseWorldStateChanged(int id)
        {
            WorldState state;
            if (worldStateDict.TryGetValue(id, out state))
                state.RaiseWorldStateChanged();
        }
    }
}
