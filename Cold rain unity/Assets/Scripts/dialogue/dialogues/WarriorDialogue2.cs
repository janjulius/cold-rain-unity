using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class WarriorDialogue2 : Dialogue
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
                    Player("Ook ook");
                    stage++;
                    break;
                case 1:
                    Npc("Oeh oe ah aah!");
                    stage = 100;
                    break;
                case 100:
                    OpenShop(ShopConstants.WARRION_SHOP_ARMOR);
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
            Npc($"Me warrior");
            stage = 0;
            return true;
        }
    }
}
