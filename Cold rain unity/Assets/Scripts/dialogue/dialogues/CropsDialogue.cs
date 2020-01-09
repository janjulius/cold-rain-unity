using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class CropsDialogue : Dialogue
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
                    Player("CROPS GANG");
                    stage++;
                    break;
                case 1:
                    Npc("GANG GANG HOMIE");
                    stage = 100;
                    break;
                case 100:
                    OpenShop(ShopConstants.CROP_SHOP);
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
            Npc($"{NPC.EntityName}'s the name, leader of the CROPS GANG.");
            stage = 0;
            return true;
        }
    }
}
