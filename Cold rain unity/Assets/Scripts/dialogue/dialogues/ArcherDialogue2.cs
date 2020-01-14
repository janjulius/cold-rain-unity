using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class ArcherDialogue2 : Dialogue
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
                    Player("Alright.");
                    stage++;
                    break;
                case 1:
                    Npc("My apologies, can I help?");
                    stage++;
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "Browse store", "About archery", "Goodbye");
                    stage++;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.ARCHER_SHOP_ARMOR);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("I have some questions about archery");
                            Npc("Oh I'm sorry but I think you should redirect those questions towards Susan, she's the leader around here. You can find Susan in the corner behind the counter.");
                            stage = 2;
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
                Npc("Shoo, get away, ape.");
                stage = 100;
            }
            else
            {
                Npc($"Oh lord, the sheer beauty of a flying arrow gives me chills down my spine");
                stage = 0;
            }
            return true;
        }
    }
}
