using Assets.Scripts.managers;
using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class HunterYouthDialogue1 : Dialogue
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
                    switch (WorldStateManager.Instance.GetState(StateConstants.HUNTING_NPC_STATE))
                    {
                        case 0:
                            Npc("Get out boomer");
                            stage = 100;
                            break;
                        case 1:
                            Player("Hey, would you be interested in running the hunting shop for me as an intern?");
                            stage++;
                            break;
                    }
                    break;
                case 2:
                    Npc("Yeah sure that sounds good. I'll start today.");
                    stage = 100;
                    WorldStateManager.Instance.SetState(StateConstants.HUNTING_NPC_STATE, 2);
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
