using Assets.Scripts.skills.farming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.interactable.Skilling
{
    public class FarmingInteractable : Interactable
    {
        public FarmingInteractableType farmingInteractable;

        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            switch (farmingInteractable)
            {
                case FarmingInteractableType.PLANT:
                    GetComponent<FarmingCrop>();
                    break;
            }
        }
    }

    public enum FarmingInteractableType
    {
        PLANT
    }
}
