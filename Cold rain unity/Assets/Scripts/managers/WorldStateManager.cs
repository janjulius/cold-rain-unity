using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.managers
{
    class WorldStateManager : Node
    {
        public Dictionary<int, short> worldStateDict = new Dictionary<int, short>();
        public short currentWorldState = 0;
        public event EventHandler worldStateChanged;

        public override void Initiate()
        {

        }

        public int this[int id]
        {
            get
            {
                if (!worldStateDict.ContainsKey(id))
                {
                    worldStateDict.Add(id, currentWorldState);
                }
                return worldStateDict[id];
            }
        }
        
        private void RaiseWorldState(int id)
        {
            if (worldStateDict.ContainsKey(id))
            {
                currentWorldState++;
            }
        }
    }
}
