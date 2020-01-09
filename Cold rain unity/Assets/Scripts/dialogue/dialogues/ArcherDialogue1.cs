using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class ArcherDialogue1 : Dialogue
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
                    Player("?");
                    stage++;
                    break;
                case 1:
                    Npc("Quite the truth, sir!");
                    stage = 100;
                    break;
                case 100:
                    OpenShop(ShopConstants.ARCHER_SHOP_WEAPONRY);
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
            Npc($"Archery is a fine art");
            stage = 0;
            return true;
        }
    }
}
