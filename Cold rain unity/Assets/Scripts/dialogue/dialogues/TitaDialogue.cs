using Assets.Scripts.quest;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class TitaDialogue : Dialogue
    {
        public override void Initiate()
        {
            base.Initiate();
        }

        public override void Handle()
        {
            base.Handle();
            Quest theHouseQuest = gameManager.GetQuestById(1);
            switch (stage)
            {
                case 0:
                    Player("Hello there!");
                    stage++;
                    break;
                case 1:
                    Npc("What do you want");
                    stage++;
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "I want to talk to you", "About a quest..", "Goodbye");
                    stage++;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("I want to talk to you.");
                            Npc("I dont wanna talk to you");
                            stage = 100;
                            break;
                        case 2:
                            Player("Goodbye");
                            Npc("Bye bye");
                            stage = 100;
                            break;
                        case 1:
                            Player("About a quest..");
                            stage = 5;
                            break;
                    }
                    break;
                case 4:
                    Player("Bit rude but ok");
                    stage = 100;
                    break;
                case 5:
                    if (!theHouseQuest.IsStarted() || theHouseQuest.IsCompleted())
                    {
                        Npc("I don't have any quests for you");
                        stage = 2;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "The house");
                        stage++;
                    }
                    break;
                case 6:
                    switch (SelectedOption)
                    {
                        case 0:
                            stage = 2;
                            Continue();
                            break;
                        case 1:
                            if (theHouseQuest.IsStarted())
                            {
                                if (theHouseQuest.Stage == 1)
                                {
                                    Player("Tito said you've been looking for santa's sleigh too, care to share what you know with me? I'm also looking for it.");
                                    stage++;
                                }
                                else if(theHouseQuest.Stage == 0)
                                {
                                    Npc("You should go see my brother Tito about that first. Tito lives in a box in the center of town, right below the mayor's house.");
                                    stage = 100;
                                }
                                else
                                {
                                    Npc("I told you there are two wind directions that describe the location of the tree, the first one is west. My brother Titus is on the beach east of town, maybe he knows the second direction.");
                                    stage = 100;
                                }
                            }
                            else
                            {
                                Npc("I can't help you with that right now.");
                                stage = 2;
                            }
                            break;
                    }
                    break;
                case 7:
                    Npc("That's right. I guess I'll share what i've gathered with you.. but only because Tito did.");
                    stage++;
                    break;
                case 8:
                    Npc("So what I've been able to gather is that the tree in question can easily be found if you have both wind directions. So far I've only been able to gather that the first direction is west.");
                    stage++;
                    break;
                case 9:
                    Npc("So if you can find the second wind direction, you should be able to find the tree. Perhaps my brother Titus knows, you should be able to find him on the beach east of town.");
                    theHouseQuest.SetStage(2);
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
            base.Open(args);
            Npc($"Hello! My name is {NPC.EntityName}.");
            stage = 0;
            return true;
        }
    }
}
