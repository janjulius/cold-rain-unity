using Assets.Scripts.quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class MayorDialogue : Dialogue
    {
        public override void Initiate()
        {
            base.Initiate();
        }

        public override void Handle()
        {
            base.Handle();
            Quest titoTutorialQuest = gameManager.GetQuestById(0);
            switch (stage)
            {
                case 0:
                    SendOptionsDialogue("Select an option", "Hello", "About a quest..", "Goodbye");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Hello");
                            Npc("Good day");
                            stage--;
                            break;
                        case 1:
                            Player("About a quest..");
                            stage++;
                            break;
                        case 2:
                            Player("Goodbye");
                            Npc("Farewell");
                            stage = 100;
                            break;
                    }
                    break;
                case 2:
                    if (titoTutorialQuest.IsCompleted() || !titoTutorialQuest.IsStarted() || titoTutorialQuest.Stage < 5)
                    {
                        Npc("I don't have any quests for you");
                        stage = 0;
                    }
                    else if (titoTutorialQuest.Stage >= 5)
                    {
                        SendOptionsDialogue("Select an option", "Tito's tutorial", "Previous page");
                        stage++;
                    }
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Jake sent me to get a permit for growing tomatoes.");
                            if (titoTutorialQuest.Stage == 5)
                            {
                                Npc("Yuck tomatoes!? Hmm, I might despise tomatoes but what I despise even more is being ignored. I sent clara a love letter but she hasn't replied yet. Get me an answer and I'll get you a permit.");
                                stage = 100;
                                titoTutorialQuest.SetStage(6);
                            }
                            else
                            {
                                Npc("Go and get me an asnwer from Clara, she lives in the house south west of here.");
                                stage = 100;
                            }
                            break;
                        case 1:
                            stage = 0;
                            Continue();
                            break;
                    }
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
            Npc($"You are speaking to the one and only {NPC.EntityName}.");
            stage = 0;
            return true;
        }
    }
}
