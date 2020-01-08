using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class HunterDialogue : Dialogue
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
                    Player("HELLO THERE");
                    stage++;
                    break;
                case 1:
                    Npc("MonkaS who R U");
                    stage = 100;
                    break;
                case 100:
                    OpenShop(ShopConstants.HUNTING_SHOP);
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
            Npc($"{NPC.EntityName} the hunter, pleased to meet you.");
            stage = 0;
            return true;
        }
    }
}
