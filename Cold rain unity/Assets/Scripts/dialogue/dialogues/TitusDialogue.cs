using Assets.Scripts.managers;
using Assets.Scripts.quest;
using Assets.Scripts.skills;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class TitusDialogue : Dialogue
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
                                if (theHouseQuest.Stage == 3)
                                {
                                    Player("Tita said you've been looking for santa's sleigh too, care to share what you know with me? I'm also looking for it.");
                                    stage++;
                                }
                                else if (theHouseQuest.Stage == 1)
                                {
                                    Npc("You should go see my brother Tito about that first. Tito lives in a box in the center of town, right below the mayor's house.");
                                    stage = 100;
                                }
                                else if(theHouseQuest.Stage == 2)
                                {
                                    Npc("You should go see my sister Tita about that first. Tita's usually roaming around the neighborhood west side of town.");
                                    stage = 100;
                                }
                                else
                                {
                                    Npc("I'm not going to tell you anything!.");
                                    stage = 12;
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
                    Npc("That's right, I've been looking all over this beach for clues to where the sleigh might be. But I don't understand why I would just share it with you?");
                    stage++;
                    break;
                case 8:
                    Npc("I've been wandering this beach for as long as I can remember and all I ever found was a clue suggesting that the sleigh is on the north side of town.");
                    stage++;
                    break;
                case 9:
                    Npc("........................");
                    stage++;
                    break;
                case 10:
                    Npc("I just told you didn't I... ehm.. Whatever it was a worthless hint anyway, I checked north but I didnt find any sleigh.");
                    stage++;
                    break;
                case 11:
                    Player("(So I guess that means that the sleigh is in a tree that can be found north west of town.)");
                    theHouseQuest.SetStage(4);
                    WorldStateManager.Instance.SetState(StateConstants.THE_HOUSE_QUEST_TREES, 1);
                    stage = 100;
                    break;
                case 12:
                    Player("(This unfriendly hobo told me one of the wind directions is north, with that information I can conclude the sleigh is in a tree north west of town.");
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
