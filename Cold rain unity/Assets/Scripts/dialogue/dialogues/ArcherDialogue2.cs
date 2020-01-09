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
                    Player("u ok?");
                    stage++;
                    break;
                case 1:
                    Npc("Rather magnificent, thank you for asking kind adventurer!");
                    stage = 100;
                    break;
                case 100:
                    OpenShop(ShopConstants.ARCHER_SHOP_ARMOR);
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
            Npc($"Oh lord, the sheer beauty of a flying arrow gives me chills down my spine");
            stage = 0;
            return true;
        }
    }
}
