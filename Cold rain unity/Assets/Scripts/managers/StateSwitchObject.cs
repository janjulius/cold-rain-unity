using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.managers
{
    public class StateSwitchObject : Statelistener
    {
        public int EnableAt;

        public override void OnUpdateState(object e, EventArgs args)
        {
            base.OnUpdateState(e, args);
            print("Stateswitchobject called");
        }
    }
}
