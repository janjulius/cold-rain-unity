using Assets.Scripts.contants;
using Assets.Scripts.dialogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.interactable
{
    public class InteractableObject : Interactable
    {
        [Header("NOTE: If using this make sure the corresponding class is added or assigned.")]
        public InteractionType InteractionType;
        
        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            switch (InteractionType)
            {
                case InteractionType.DIALOGUE:
                    GetComponent<Dialogue>()?.Open(null);
                    break;
            }
        }
    }
}
