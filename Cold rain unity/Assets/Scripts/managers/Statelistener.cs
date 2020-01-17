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
        public void OnDestroy()
        {
            WorldStateManager.Instance.ActionDictionary[listeningId] -= OnUpdateState;
        }

        public override void StartInitiate()
        {
            base.StartInitiate();
            WorldStateManager.Instance.Register(listeningId);
            WorldStateManager.Instance.ActionDictionary[listeningId] += OnUpdateState;
            OnUpdateState(WorldStateManager.Instance.GetState(listeningId));
        }

        public abstract void OnUpdateState(int newVal);
    }
}
