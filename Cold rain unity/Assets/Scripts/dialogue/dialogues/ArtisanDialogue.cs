using Assets.Scripts.quest;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class ArtisanDialogue : Dialogue
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
                    SendOptionsDialogue("Select an option", "Wheelchair?", "What is an artisan?", "Progression", "Where can I work?", "-next page-");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("How did you end up in that wheelchair?");
                            Npc("I had a stroke when I thought about the future of this town with this mayor. Since then my legs have been paralyzed.");
                            stage--;
                            break;
                        case 1:
                            Player("What does an artisan do?");
                            Npc("An artisan can do a large variety of things, but in my case I make leather armor for the archers, I make cheese and I make jam. Each one of those net me a nice profit.");
                            stage--;
                            break;
                        case 2:
                            Player("Can I become a master artisan?");
                            Npc("If you spend enough time in the workshop, anyone can become a master artisan. When you do believe you've become a master artisan please come and see me.");
                            stage++;
                            break;
                        case 3:
                            Player("Where can I work?");
                            Npc("You can work in my workshop in the back. the big machine in the right side is where you process leather. On the left side you can make cheese and jam.");
                            stage--;
                            break;
                        case 4:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 2:
                    Npc("Being an artisan in a wheelchair is very difficult, I've been waiting for someone that can take my post so I can finally stop doing this exhausing work.");
                    stage = 0;
                    break;
                case 3:
                    SendOptionsDialogue("Select an option", "-previous page-", "How to work the machines", "About a quest", "Goodbye");
                    stage++;
                    break;
                case 4:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("How do I work the machines?");
                            stage++;
                            break;
                        case 2:
                            Player("About a quest..");
                            stage = 7;
                            break;
                        case 3:
                            Player("Goodbye");
                            Npc("Oh, you're leaving..");
                            stage = 100;
                            break;
                        case 0:
                            stage = 0;
                            Continue();
                            break;
                    }
                    break;
                case 5:
                    SendOptionsDialogue("Select an option", "How to make cheese", "How to make jam", "How to make leather armor", "-previous page-");
                    stage++;
                    break;
                case 6:
                    switch (SelectedOption){
                        case 0:
                            Player("How do I make cheese?");
                            Npc("You don't"); //write this when artisan has been fully worked out.
                            break;
                        case 1:
                            Player("How do I make jam?");
                            Npc("You don't"); //write this when artisan has been fully worked out.
                            break;
                        case 2:
                            Player("How do I make leather armor?");
                            Npc("You don't"); //write this when artisan has been fully worked out.
                            break;
                        case 3:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 7:
                    if (titoTutorialQuest.Stage < 2 || titoTutorialQuest.Stage > 17)
                    {
                        Npc("I don't have any quests for you");
                        stage = 3;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 8:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Harold sent me here to borrow your ladder.");
                            if (titoTutorialQuest.Stage == 2)
                            {
                                Npc("Ah, Harold knows I don't lend out my ladder for free though. Blake runs the livestock shop east of here, if you can get me some of his milk I'll let you use my ladder.");
                                stage = 100;
                                titoTutorialQuest.SetStage(3);
                            }
                            else if (titoTutorialQuest.Stage >= 3 && titoTutorialQuest.Stage < 16)
                            {
                                Npc("Get me some milk from Blake's livestock shop east of here if you want to borrow my ladder.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 16 && player.InventoryContainer.Contains(400))
                            {
                                Player("Here's some milk.");
                                stage = 9;
                            }
                            else if (titoTutorialQuest.Stage == 16 && !player.InventoryContainer.Contains(400))
                            {
                                Npc("It seems you didn't me any milk. Go and get some from blake in the house east from here.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 17 && !player.InventoryContainer.Contains(399) && player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the ladder, good thing it found it's way back to me. Here you go.");
                                player.InventoryContainer.Add(399, 1);
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 17 && !player.InventoryContainer.Contains(399) && !player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the ladder, good thing it found it's way back to me. You don't seem to have space for it though, make some space and talk to me again.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 17 && player.InventoryContainer.Contains(399))
                            {
                                Npc("You've got my ladder, go and take it to Harold south of here.");
                                stage = 100;
                            }
                            else
                            {
                                Npc("I can't help you with that right now.");
                                stage = 3;
                            }
                            break;
                        case 0:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 9:
                    Npc("Thanks, heres the ladder. Go and bring it to Harold south of here.");
                    player.InventoryContainer.Remove(400, 1);
                    player.InventoryContainer.Add(399, 1);
                    titoTutorialQuest.SetStage(17);
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
            Npc("Watch your toes around these wheels. Im reckless.");
            stage = 0;
            return true;
        }
    }
}
