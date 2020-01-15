using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class ArcherDialogue3 : Dialogue
    {
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
                    SendOptionsDialogue("Select an option", "Browse store", "About archery", "Goodbye");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.ARCHER_SHOP_AMMO);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("I have some questions about archery");
                            Npc("Unfortunately I cannot provide you with the best information, for that you should visit Susan. Susan can be found in the corner behind the counter");
                            stage = 0;
                            break;
                        case 2:
                            Player("Goodbye");
                            Npc("So long");
                            stage = 100;
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
            if (player.Combatstate == Combatstate.WARRIOR)
            {
                Npc("Shoo, get back you dirty ape.");
                stage = 100;
            }
            else
            {
                Npc($"Good day, elegant visitor. Can I help you?");
                stage = 0;
            }
            return true;
        }
    }
}
