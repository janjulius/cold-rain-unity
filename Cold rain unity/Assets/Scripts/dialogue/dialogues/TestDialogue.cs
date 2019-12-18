using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class TestDialogue : Dialogue
    {
        public override void Handle()
        {
            base.Handle();
            switch (stage)
            {
                case 0:
                    Player("Testing dialogue");
                    stage++;
                    break;
                case 1:
                    Npc("Sounds like a plan");
                    stage = 100;
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
            Npc("Hello.");
            stage = 0;
            return true;
        }
    }
}
