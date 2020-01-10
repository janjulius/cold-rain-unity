using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class TestDialogue : Dialogue
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
                    Player("Testing dialogue");
                    stage = 2;
                    break;
                case 1:
                    Npc("Heres my shop");
                    stage = 100;
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "Goodbye", "I wanna talk to you", "Open the shop");
                    stage = 3;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Npc("Goodbye");
                            stage = 100;
                            break;
                        case 1:
                            Npc("I dont wanna talk to you");
                            stage = 4;
                            break;
                        case 2:
                            stage = 5;
                            GameConsole.Instance.SendDevMessage("3:2  " + stage);
                            Continue();
                            break;
                    }
                    break;
                case 4:
                    Player("Bit rude but ok");
                    stage = 100;
                    break;
                case 5:
                    OpenShop(ShopConstants.TEST_SHOP);
                    End();
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
            Npc($"Hello! My name is {NPC.EntityName}.");
            stage = 0;
            return true;
        }
    }
}
