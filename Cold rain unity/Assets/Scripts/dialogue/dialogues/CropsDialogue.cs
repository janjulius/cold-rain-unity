using Assets.Scripts.managers;
using Assets.Scripts.quest;
using Assets.Scripts.shops.constants;
using Assets.Scripts.skills;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class CropsDialogue : Dialogue
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
                    if (WorldStateManager.Instance.GetState(StateConstants.FARMING_NPC_STATE) == 2)
                    {
                        Npc("I told you to find some interns in the youth center south of town, Remember?");
                        stage = 100;
                    }
                    else if (WorldStateManager.Instance.GetState(StateConstants.FARMING_NPC_STATE) == 1)
                    {
                        Npc("My brother told you to find some interns in the youth center south of town, Right?");
                        stage = 100;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Browse store", "Crops gang?", "CROPS GANG!", "Farming?", "-Next page-");
                        stage = 1;
                    }
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.CROP_SHOP);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("What is this crops gang thing?");
                            Npc("The crops gang is a way of living, I can't be bother to explain such a complicated matter to a simpleton like yourself.");
                            stage = 0;
                            break;
                        case 2:
                            Player("CROPS GANG!");
                            Npc("G A N G  G A N G  C R O P S  G A N G  H O M E  D O G!");
                            stage = 0;
                            break;
                        case 3:
                            Player("Can you tell me something about farming?");
                            Npc("What would you like to hear about?");
                            stage = 2;
                            break;
                        case 4:
                            stage = 2;
                            Continue();
                            break;
                    }
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "-Previous page-", "Why farm?", "Crops?", "Farming progression?", "-Next page-");
                    stage = 3;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            stage = 0;
                            Continue();
                            break;
                        case 1:
                            Player("What's the point of farming?");
                            Npc("It is important for the town that there are farmers because farming is the only way to obtain secondaries for a solid meal. The town would be nothing without meals.");
                            stage = 4;
                            break;
                        case 2:
                            Player("So you farm crops?");
                            Npc("Yes, there are two farming methods; Livestock and crops. My brother next door runs the livestock gang if you're interested in that.");
                            stage = 7;
                            break;
                        case 3:
                            Player("How do I become a good farmer?");
                            Npc("Both farming livestock and farming crops should give you plenty of credibility as a good farmer, so you could do either... or both!");
                            stage = 11;
                            break;
                        case 4:
                            stage = 14;
                            Continue();
                            break;

                    }
                    break;
                case 4:
                    Npc("Through farming you can obtain tomato, corn, lettuce, onion, eggs, milk, cheese, berries and wool. There is no other way of obtaining these.");
                    stage = 5;
                    break;
                case 5:
                    Npc("My brother Blake and I have been wanting to go on a trip for a while now, we want to move to mexico. But we can't just leave the town without finding a good replacement.");
                    stage = 6;
                    break;
                case 6:
                    Npc("I was hoping you could help us out!");
                    stage = 2;
                    break;
                case 7:
                    Npc("Farming crops is all about planting and taking care of your crops. You can buy seeds and material to take care of you crops with in my shop.");
                    stage = 8;
                    break;
                case 8:
                    Npc("All you need to do is throw compost in the patch when you plant the seeds, and water the plants every day untill they're fullgrown.");
                    stage = 9;
                    break;
                case 9:
                    Npc("Once the plant has fully grown, you can harvest it and either use it for food or sell it for cash.");
                    stage = 10;
                    break;
                case 10:
                    Npc("You can use the patches in my greenhouse if you want, it's behind the shop.");
                    stage = 2;
                    break;
                case 11:
                    Npc("Both methods have their own unique rewards so it might be smart to do a bit of both. But if you only like farming crops, thats cool too.");
                    stage = 12;
                    break;
                case 12:
                    Npc("Anyway, if you've done enough farming, either me or my brother can promote you to the new head of farming.");
                    stage = 2;
                    break;
                case 13:
                    Npc("Once you have your own greenhouse you will have more patches, more patches means more plants so that should increase you produce.");
                    stage = 14;
                    break;
                case 14:
                    SendOptionsDialogue("Select an option", "-Previous Page-", "Where to farm ?", "Master farming", "About a quest..", "Goodbye");
                    stage++;
                    break;
                case 15:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Where do I farm crops?");
                            Npc("You can start off by using my greenhouse, it's behind the shop. once you've gotten experienced enough you can get your own greenhouse.");
                            stage = 13;
                            break;
                        case 2:
                            Player("I think I've become a master farmer.");
                            stage = 20;
                            break;
                        case 3:
                            Player("About a quest..");
                            stage = 16;
                            break;
                        case 4:
                            Player("Goodbye");
                            Npc("See ya");
                            stage = 100;
                            break;
                        case 0:
                            stage = 2;
                            Continue();
                            break;
                    }
                    break;
                case 16:
                    if (titoTutorialQuest.Stage < 4 || titoTutorialQuest.Stage > 15)
                    {
                        Npc("I don't have any quests for you");
                        stage = 14;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 17:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Blake sent me to take back his spoon.");
                            if (titoTutorialQuest.Stage == 4)
                            {
                                Npc("HIS spoon?? I don't understand, mom always said I was her favorite... But I guess she did give to him.. You can take the spoon if you get me something in return.");
                                stage++;
                            }
                            else if (titoTutorialQuest.Stage >= 5 && titoTutorialQuest.Stage < 14)
                            {
                                Npc("Go and get me a permit to grow tomatoes from the mayor. The mayor's house is in the center of town, south west from here.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 14 && player.InventoryContainer.Contains(402))
                            {
                                Player("Here's a permit to grow tomatoes.");
                                stage = 19;
                            }
                            else if (titoTutorialQuest.Stage == 14 && !player.InventoryContainer.Contains(402))
                            {
                                Npc("It seems you didn't bring the permit. Go get a new one from Gunther south west of here.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 15 && !player.InventoryContainer.Contains(401) && player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the spoon, you're lucky I gave you a fake one. Here's a new one.");
                                player.InventoryContainer.Add(401, 1);
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 15 && !player.InventoryContainer.Contains(401) && !player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the spoon, you're lucky I gave you a fake one. You don't seem to have space for it though, make some space and talk to me again.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 15 && player.InventoryContainer.Contains(401))
                            {
                                Npc("You've got the spoon, go and take it to Blake nextdoor.");
                                stage = 100;
                            }
                            else
                            {
                                Npc("I can't help you with that right now.");
                                stage = 14;
                            }
                            break;
                        case 0:
                            stage = 14;
                            Continue();
                            break;
                    }
                    break;
                case 18:
                    Npc("The mayor hates tomatoes so he refuses to give me a permit to grow tomatoes. Please go and get me a permit anyway. The mayor lives in the large house south west from here.");
                    stage = 100;
                    titoTutorialQuest.SetStage(5);
                    break;
                case 19:
                    Npc("Thanks, here's the spoon. Bring it to my brother next door.");
                    player.InventoryContainer.Remove(402, 1);
                    player.InventoryContainer.Add(401, 1);
                    titoTutorialQuest.SetStage(15);
                    stage = 100;
                    break;
                case 20:
                    if (player.skills.GetSkill(SKILLS.FARMING).GetLevel() >= 50)
                    {
                        Npc("It seems you've become a capable master farmer. Me and my brother will be leaving the stores in your hands then. Together with the CROPS GANG and LIVESTOCK GANG.");
                        stage++;
                    }
                    else
                    {
                        Npc("Debatable. Try again when you reach level 50.");
                        stage = 3;
                    }
                    break;
                case 21:
                    SendOptionsDialogue("Select an option", "Yes", "No, not yet");
                    stage++;
                    break;
                case 22:
                    switch (SelectedOption)
                    {
                        case 0:
                            Npc("Alright, there's no way you can run two shops all on your own though, why don't you go find some interns at the youth center?");
                            stage++;
                            break;
                        case 1:
                            Npc("Oh... soon though? I hope.");
                            stage = 3;
                            break;
                    }
                    break;
                case 23:
                    Npc("You know where the youth center is, right? It's south of town somewhere in the woods.");
                    stage++;
                    break;
                case 24:
                    Npc("By the time you hire some interns, we'll be out of this place, so I guess this will be goodbye. We're going to mexico!");
                    stage++;
                    break;
                case 25:
                    Player("Goodbye");
                    Npc("See ya");
                    WorldStateManager.Instance.SetState(StateConstants.FARMING_NPC_STATE, 2);
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
            Npc($"CROPS GANG at your service, how can I help?");
            stage = 0;
            return true;
        }
    }
}
