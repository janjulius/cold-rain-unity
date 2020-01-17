using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class ArtisanYouthDialogue1 : Dialogue
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
                    Player("Yeah okay whatever");
                    stage++;
                    break;
                case 1:
                    switch (stage) // SWITCH (ARTISANSTATE)
                    {
                        case 0:
                            Npc("Get out boomer");
                            stage = 100;
                            break;
                        case 1:
                            Player("Hey, would you be interested in running the artisan workshop for me as an intern?");
                            stage++;
                            break;
                    }
                    break;
                case 2:
                    Npc("Yeah sure that sounds good. I'll start today.");
                    stage = 100;
                    //SET ARTISANSTATE TO 2
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
            base.Open(args);
            Npc($"We dabbing out here");
            stage = 0;
            return true;
        }
    }
}
