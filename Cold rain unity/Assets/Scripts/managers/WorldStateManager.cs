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
        private short currentWorldState = 0;


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

        public void setWorldState(int id, short worldState)
        {
            
        }
    }
}
