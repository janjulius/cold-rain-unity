using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class WarriorDialogue1 : Dialogue
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
                    Player("Ooga");
                    stage++;
                    break;
                case 1:
                    Npc("Booga");
                    stage = 100;
                    break;
                case 100:
                    OpenShop(ShopConstants.WARRION_SHOP_WEAPONRY);
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
            Npc($"Warrior represent");
            stage = 0;
            return true;
        }
    }
}
