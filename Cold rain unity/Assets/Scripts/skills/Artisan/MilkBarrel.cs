using Assets.Scripts.activity.minigame;
using Assets.Scripts.dialogue;
using Assets.Scripts.interactable.Skilling;
using System;

namespace Assets.Scripts.skills.Artisan
{
    class MilkBarrel : Dialogue
    {
        private ArtisanFoodActivity foodActivity;

        public override void Initiate()
        {
            base.Initiate();
        }

        public override void Handle()
        {
            base.Handle();
            switch (stage)
            {
                case 0:
                    SendOptionsDialogue("What would you like to make?", "Unripe cheese", "Unripe goat cheese");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            gameObject.GetComponent<ArtisanInteractable>().HandleMilk(0);
                            End();
                            break;
                        case 1:
                            gameObject.GetComponent<ArtisanInteractable>().HandleMilk(1);
                            End();
                            break;
                    }
                    break;
                case 100:
                    End();
                    break;
            }
        }

        public override void End(object[] args)
        {
            throw new NotImplementedException();
        }

        public override bool Open(object[] args)
        {
            base.Open(args);
            foodActivity = (ArtisanFoodActivity)args[0];
            stage = 0;
            Handle();
            return true;
        }
    }
}
