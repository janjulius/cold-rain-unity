using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class WarriorStoreDialogue1 : Dialogue
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
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 1;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.WARRION_SHOP_WEAPONRY);
                            stage = 100;
                            break;
                        case 1:
                            stage = 100;
                            Continue();
                            break;
                    }
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
            Npc($"Would you Like to browse the warrior weaponry store?");
            stage = 0;
            return true;
        }
    }
}
