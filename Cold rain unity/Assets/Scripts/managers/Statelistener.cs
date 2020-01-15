using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.managers
{
    public abstract class Statelistener : Node
    {
        [Header("Make sure this is unique")]
        public int listeningId;
        
        private WorldStateManager stateManager;

        public override void StartInitiate()
        {
            base.StartInitiate();
            stateManager = Camera.main.GetComponent<WorldStateManager>();
            stateManager[listeningId].worldStateChanged += OnUpdateState;
        }
        
        public virtual void OnUpdateState(object e, EventArgs args)
        {
            print("onupdatestate was called");
        }
    }
}
