using Assets.Scripts.managers.skilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.interactable.Skilling
{
    public class CookingInteractable : Interactable
    {
        SkillingInterfaceManager skillingInterfaceManager;

        public override void Initiate()
        {
            base.Initiate();
            skillingInterfaceManager = Camera.main.GetComponent<GameManager>().skillingInterfaceManager;
        }

        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            if(sender is Player)
                skillingInterfaceManager.OpenCookingInterface((Player)sender);
        }
    }
}
