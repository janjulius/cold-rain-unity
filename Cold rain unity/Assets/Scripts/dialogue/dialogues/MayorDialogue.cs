using Assets.Scripts.managers;
using Assets.Scripts.quest;
using Assets.Scripts.skills;
using System;

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
            Quest theHouseQuest = gameManager.GetQuestById(1);
            switch (stage)
            {
                case 0:
                    if (!theHouseQuest.IsStarted())
                    {
                        Player("I heard you have a vacant house?");
                        stage = 5;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Hello", "About a quest..", "Goodbye");
                        stage++;
                    }
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
                    if ((theHouseQuest.IsCompleted()) && (titoTutorialQuest.Stage < 5 || titoTutorialQuest.Stage > 14))
                    {
                        Npc("I don't have any quests for you");
                        stage = 0;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial", "The house");
                        stage++;
                    }
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Jake sent me to get a permit for growing tomatoes.");
                            if (titoTutorialQuest.Stage == 5)
                            {
                                Npc("Yuck tomatoes!? Hmm, I might despise tomatoes but what I despise even more is being ignored. I sent clara a love letter but she hasn't replied yet. Get me an answer and I'll get you a permit.");
                                stage = 100;
                                titoTutorialQuest.SetStage(6);
                            }
                            else if (titoTutorialQuest.Stage >= 6 && titoTutorialQuest.Stage < 13)
                            {
                                Npc("Go and get me an answer from Clara, she lives in the house south west of here.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 13 && player.InventoryContainer.Contains(403))
                            {
                                Player("Here's a reply from Clara.");
                                stage = 4;
                            }
                            else if (titoTutorialQuest.Stage == 13 && !player.InventoryContainer.Contains(403))
                            {
                                Npc("It seems you lost the letter.. go get a new one from Clara");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 14 && !player.InventoryContainer.Contains(402) && player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the permit. You're lucky I always make a backup.");
                                player.InventoryContainer.Add(402, 1);
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 14 && !player.InventoryContainer.Contains(402) && !player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the permit. You're lucky I always make a backup. You don't seem to have space for it though, make some space and talk to me again.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 14 && player.InventoryContainer.Contains(402))
                            {
                                Npc("You've got your permit. Scram, back to where you came from north east of here.");
                                stage = 100;
                            }
                            else
                            {
                                Npc("I can't help you with that right now.");
                                stage = 0;
                            }
                            break;
                        case 0:
                            stage = 0;
                            Continue();
                            break;
                        case 2:
                            if (player.InventoryContainer.Contains(412))
                            {
                                Player("I found santa's sleigh.");
                                stage = 12;
                            }
                            else if (theHouseQuest.IsStarted())
                            {
                                Player("I can't find santa's sleigh...");
                                stage = 15;
                            }
                            else
                            {
                                Npc("I don't think I can help you with this.");
                                stage = 0;
                            }
                            break;
                    }
                    break;
                case 4:
                    Npc("Thanks, here's your permit. Go and bring it to Jake north east of here.");
                    player.InventoryContainer.Remove(403, 1);
                    player.InventoryContainer.Add(402, 1);
                    titoTutorialQuest.SetStage(14);
                    stage = 100;
                    break;
                case 5:
                    Npc("I sure do! Have you come to buy if off me?");
                    stage++;
                    break;
                case 6:
                    Player("Yes! But I don't have any money so you can just give it to me right?");
                    stage++;
                    break;
                case 7:
                    Npc("GIVE it to you!? Who do you think I am, Santa Claus? You're not getting a dime from me for free.");
                    stage++;
                    break;
                case 8:
                    Player("Oh okay then, can I do something for you to earn the house?");
                    stage++;
                    break;
                case 9:
                    Npc("Not a chance. I only take money. You remind me of those hobo's Tita, Tito and Titus. They've spreading rumors about Santa's sleigh since they appeared one day.");
                    stage++;
                    break;
                case 10:
                    Npc("You know what, if you can find Santa's sleigh I'll trade it for the house! Haha, what a joke.");
                    stage++;
                    break;
                case 11:
                    gameManager.ProposeQuest(1);
                    End();
                    break;
                case 12:
                    Npc("WHAT!? Give it to me right now I need to verify this.");
                    stage++;
                    break;
                case 13:
                    player.InventoryContainer.Remove(412, 1);
                    Npc("I cannot believe you actually found santa's sleigh. I dismissed those hobos completely but it seems they were actually on to something.");
                    stage++;
                    break;
                case 14:
                    Npc("I hate to say it but I cannot break my promise. The house is yours.");
                    theHouseQuest.Finish();
                    stage = 100;
                    break;
                case 15:
                    Npc($"I doubt there is one anyway! But don't give up {player.EntityName}, I bet those hobos can help you out, they think they're onto something hahaha.");
                    stage = 0;
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
