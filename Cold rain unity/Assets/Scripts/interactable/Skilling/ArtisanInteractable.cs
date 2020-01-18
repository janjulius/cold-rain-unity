using Assets.Scripts.activity.minigame;
using Assets.Scripts.managers.skilling;
using System;
using UnityEngine;

namespace Assets.Scripts.interactable.Skilling
{
    public class ArtisanInteractable : Interactable
    {
        SkillingInterfaceManager skillingInterfaceManager;
        public ArtisanInteractableType interactableType;
        private int berryAmount;

        public override void Initiate()
        {
            base.Initiate();
            skillingInterfaceManager = Camera.main.GetComponent<GameManager>().skillingInterfaceManager;
        }

        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            Player player = (Player)sender;
            switch (interactableType)
            {
                case ArtisanInteractableType.LEATHER:
                    skillingInterfaceManager.OpenArtisanInterface(player);
                    break;
                case ArtisanInteractableType.JAM_START:
                    if (player.InventoryContainer.Contains(271))
                    {
                        if (player.InventoryContainer.GetAmount(271) >= berryAmount)
                        {
                            player.InventoryContainer.Remove(271, berryAmount);
                            //ArtisanFoodActivity.StartActivity( player);
                        }
                    }
                    break;
            }

        }

    }

    [Flags]
    public enum ArtisanInteractableType
    {
        LEATHER = (1 << 0),
        JAM_START = (1 << 1),
        MILK_START = (1 << 2),
        CHEESE_START = (1 << 3),
        JAM_DONE = (1 << 4),
        MILK_DONE = (1 << 5),
        CHEESE_DONE = (1 << 6)
    }
}
