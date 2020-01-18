using Assets.Scripts.managers.skilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.interactable.Skilling
{
    public class ArtisanInteractable : Interactable
    {
        SkillingInterfaceManager skillingInterfaceManager;
        public ArtisanInteractableType interactableType;

        public override void Initiate()
        {
            base.Initiate();
            skillingInterfaceManager = Camera.main.GetComponent<GameManager>().skillingInterfaceManager;
        }

        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            if (sender is Player)
            {
                switch (interactableType)
                {
                    case ArtisanInteractableType.LEATHER:
                        skillingInterfaceManager.OpenArtisanInterface((Player)sender);
                        break;
                }
            }
        }

    }

    [Flags]
    public enum ArtisanInteractableType
    {
        LEATHER = (1 << 0),
        JAM = (1 << 1),
        MILK = (1 << 2),
        CHEESE = (1 << 3)
    }
}
