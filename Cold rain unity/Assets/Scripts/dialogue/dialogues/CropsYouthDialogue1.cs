using Assets.Scripts.managers;
using Assets.Scripts.shops.constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.dialogue.dialogues
{
    class CropsYouthDialogue1 : Dialogue
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
                    switch (WorldStateManager.Instance.GetState(StateConstants.FARMING_NPC_STATE))
                    {
                        case 0:
                            Npc("Get out boomer");
                            stage = 100;
                            break;
                        case 1:
                        case 2:
                            Player("Hey, would be you and your brother be interested in running the farming shop for me as interns?");
                            stage++;
                            break;
                    }
                    break;
                case 2:
                    Npc("Yeah sure that sounds good. We'll start right now.");
                    stage++;
                    break;
                case 3:
                    player.BlockMovement(1.5f);
                    gameManager.FadeScreen(1);
                    StartCoroutine(SetFarmingState(3));
                    End();
                    break;
                case 100:
                    End();
                    break;
            }
        }

        public IEnumerator SetFarmingState(int state)
        {
            yield return new WaitForSeconds(1);
            WorldStateManager.Instance.SetState(StateConstants.FARMING_NPC_STATE, state);
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
