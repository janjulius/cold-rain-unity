using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class WarriorDialogue3 : Dialogue
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
                    SendOptionsDialogue("Select an option", "Browse store", "Ask about warriors", "Goodbye");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.WARRION_SHOP_AMMO);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("I have some questions about being a warrior.");
                            Npc("GO ASK SWORD, HE IN CORNER.");
                            stage = 0;
                            break;
                        case 2:
                            Player("Goodbye");
                            Npc("BYE");
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
            if (player.Combatstate == Combatstate.ARCHER)
            {
                Npc("BACK OFF SMARTASS.");
                stage = 100;
            }
            else
            {
                Npc($"HELLO I HELP?");
                stage = 0;
            }
            return true;
        }
    }
}
