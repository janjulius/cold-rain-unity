using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class LivestockDialogue : Dialogue
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
                    Player("LIVESTOCK GANG");
                    stage++;
                    break;
                case 1:
                    Npc("GANG GANG HOMIE");
                    stage = 100;
                    break;
                case 100:
                    OpenShop(ShopConstants.LIVESTOCK_SHOP);
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
            Npc($"{NPC.EntityName}'s the name, leader of the LIVESTOCK GANG.");
            stage = 0;
            return true;
        }
    }
}
