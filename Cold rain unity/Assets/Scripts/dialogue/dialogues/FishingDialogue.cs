using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class FishingDialogue : Dialogue
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
                    Player("you seem fishy");
                    stage++;
                    break;
                case 1:
                    Npc("Shut the fuck up man");
                    stage = 100;
                    break;
                case 100:
                    OpenShop(ShopConstants.FISHING_SHOP);
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
            Npc($"Fisher {NPC.EntityName} speaking.");
            stage = 0;
            return true;
        }
    }
}
