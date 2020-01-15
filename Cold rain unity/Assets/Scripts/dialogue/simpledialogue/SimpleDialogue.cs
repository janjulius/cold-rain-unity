using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.simpledialogue
{
    public class SimpleDialogue : Dialogue
    {
        public string dialogue;

        public override void Handle()
        {
            base.Handle();
            switch (stage)
            {
                case 0:
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
            Npc(dialogue);
            stage = 0;
            return true;
        }
    }
}
