using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.managers
{
    public class WorldState
    {
        public int state;
        public event EventHandler worldStateChanged;

        public WorldState(int state)
        {
            this.state = state;
        }

        public void RaiseWorldStateChanged()
        {
            worldStateChanged?.Invoke(this, EventArgs.Empty);
        }

        internal void SetState(int s)
        {
            state = s;
        }
    }
}
