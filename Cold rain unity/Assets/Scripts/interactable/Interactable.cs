﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.interactable
{
    public class Interactable : Node, Iinteractable
    {
        public override void StartInitiate()
        {
            base.StartInitiate();
            gameObject.layer = (int)UnityLayers.INTERACTABLE;
        }

        public virtual void Interact(Entity sender)
        {

        }
    }
}
