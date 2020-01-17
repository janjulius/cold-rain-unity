using Assets.Scripts.contants;
using Assets.Scripts.quest;
using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class LivestockDialogue : Dialogue
    {

        private int chickenPrice = AnimalPricesConstants.CHICKEN_PRICE;
        private int goatPrice = AnimalPricesConstants.GOAT_PRICE;
        private int sheepPrice = AnimalPricesConstants.SHEEP_PRICE;
        private int cowPrice = AnimalPricesConstants.COW_PRICE;

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
                    if (stage == 1000)//farmingstate == 1)
                    {
                        Npc("I told you to find an intern in the youth center south of town, Remember?");
                        stage = 100;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Browse store", "Buy livestock", "Livestock gang?", "LIVESTOCK GANG!", "-Next page-");
                        stage++;
                    }
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.LIVESTOCK_SHOP);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("I'd like to purchase some livestock");
                            Npc("What type of livestock?");
                            stage = 3;
                            break;
                        case 2:
                            Player("What is this livestock gang thing?");
                            Npc("The livestock gang is a way of living, I can't be bother to explain such a complicated matter to a simpleton like yourself.");
                            stage--;
                            break;
                        case 3:
                            Player("LIVESTOCK GANG!");
                            Npc("G A N G  G A N G  L I V E S T O C K  G A N G  H O M E  D O G!");
                            stage--;
                            break;
                        case 4:
                            stage = 2;
                            Continue();
                            break;
                    }
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "-Previous Page-", "Why farm?", "Livestock?", "Farming progression?", "-Next page-");
                    stage = 4;
                    break;
                case 3:
                    SendOptionsDialogue("Select an option", "Purchase chicken", "Purchase goat", "Purchase sheep", "Purchase cow");
                    stage = 5;
                    break;
                case 4:
                    switch (SelectedOption)
                    {
                        case 0:
                            stage = 0;
                            Continue();
                            break;
                        case 1:
                            Player("What's the point of farming?");
                            Npc("It is important for the town that there are farmers because farming is the only way to obtain secondaries for a solid meal. The town would be nothing without meals.");
                            stage = 14;
                            break;
                        case 2:
                            Player("So you farm livestock?");
                            Npc("Yes, there are two farming methods; Livestock and crops. My brother next door runs the crops gang if you're interested in that.");
                            stage = 17;
                            break;
                        case 3:
                            Player("How do I become a good farmer?");
                            Npc("Both farming livestock and farming crops should give you plenty of credibility as a good farmer, so you could do either... or both!");
                            stage = 21;
                            break;
                        case 4:
                            stage = 24;
                            Continue();
                            break;
                    }
                    break;
                case 5:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("I'd like to purchase a chicken.");
                            Npc("One chicken, that'll be " + chickenPrice + ". Is that alright?");
                            stage = 6;
                            break;
                        case 1:
                            Player("I'd like to purchase a goat.");
                            Npc("One goat, that'll be " + goatPrice + ". Is that alright?");
                            stage = 7;
                            break;
                        case 2:
                            Player("I'd like to purchase a sheep.");
                            Npc("One sheep, that'll be " + sheepPrice + ". Is that alright?");
                            stage = 8;
                            break;
                        case 3:
                            Player("I'd like to purchase a cow.");
                            Npc("One cow, that'll be " + cowPrice + ". Is that alright?");
                            stage = 9;
                            break;
                    }
                    break;
                case 6:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 10;
                    break;
                case 7:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 11;
                    break;
                case 8:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 12;
                    break;
                case 9:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 13;
                    break;
                case 10:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Yes");
                            if (player.InventoryContainer.Contains(384))
                            {
                                int curMoney = player.InventoryContainer.GetItem(384).Amount;
                                if (curMoney >= chickenPrice)
                                {
                                    player.InventoryContainer.Remove(384, chickenPrice);
                                    player.InventoryContainer.Refresh();
                                    //give this homie a chicken
                                    Npc("The chicken will be added to your barn shortly.");
                                }
                                else
                                {
                                    Npc("Looks like you don't have enough money for that.");
                                }
                            }
                            else
                            {
                                Npc("Looks like you don't have any money with you.");
                            }
                            stage = 100;
                            break;
                        case 1:
                            Player("No");
                            stage = 100;
                            Continue();
                            break;
                    }
                    break;
                case 11:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Yes");
                            if (player.InventoryContainer.Contains(384))
                            {
                                int curMoney = player.InventoryContainer.GetItem(384).Amount;
                                if (curMoney >= goatPrice)
                                {
                                    player.InventoryContainer.Remove(384, goatPrice);
                                    player.InventoryContainer.Refresh();
                                    //give this homie a goat
                                    Npc("The goat will be added to your barn shortly.");
                                }
                                else
                                {
                                    Npc("Looks like you don't have enough money for that.");
                                }
                            }
                            else
                            {
                                Npc("Looks like you don't have any money with you.");
                            }
                            stage = 100;
                            break;
                        case 1:
                            Player("No");
                            stage = 100;
                            Continue();
                            break;
                    }
                    break;
                case 12:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Yes");
                            if (player.InventoryContainer.Contains(384))
                            {
                                int curMoney = player.InventoryContainer.GetItem(384).Amount;
                                if (curMoney >= sheepPrice)
                                {
                                    player.InventoryContainer.Remove(384, sheepPrice);
                                    player.InventoryContainer.Refresh();
                                    //give this homie a sheep
                                    Npc("The sheep will be added to your barn shortly.");
                                }
                                else
                                {
                                    Npc("Looks like you don't have enough money for that.");
                                }
                            }
                            else
                            {
                                Npc("Looks like you don't have any money with you.");
                            }
                            stage = 100;
                            break;
                        case 1:
                            Player("No");
                            stage = 100;
                            Continue();
                            break;
                    }
                    break;
                case 13:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Yes");
                            if (player.InventoryContainer.Contains(384))
                            {
                                int curMoney = player.InventoryContainer.GetItem(384).Amount;
                                if (curMoney >= cowPrice)
                                {
                                    player.InventoryContainer.Remove(384, cowPrice);
                                    player.InventoryContainer.Refresh();
                                    //give this homie a cow
                                    Npc("The cow will be added to your barn shortly.");
                                }
                                else
                                {
                                    Npc("Looks like you don't have enough money for that.");
                                }
                            }
                            else
                            {
                                Npc("Looks like you don't have any money with you.");
                            }
                            stage = 100;
                            break;
                        case 1:
                            Player("No");
                            stage = 100;
                            Continue();
                            break;
                    }
                    break;
                case 14:
                    Npc("Through farming you can obtain tomato, corn, lettuce, onion, eggs, milk, cheese, berries and wool. There is no other way of obtaining these.");
                    stage = 15;
                    break;
                case 15:
                    Npc("My brother Jake and I have been wanting to go on a trip for a while now, we want to move to mexico. But we can't just leave the town without finding a good replacement.");
                    stage = 16;
                    break;
                case 16:
                    Npc("I was hoping you could help us out!");
                    stage = 2;
                    break;
                case 17:
                    Npc("Livestock farming is all about taking care of your animals and reaping the rewards every single day. You can buy chickens, goat, sheep and cows and put them in your barn, if you have one.");
                    stage = 18;
                    break;
                case 18:
                    Npc("All you need to do is give the animals hay, and cure them if they become ill. The required materials to do these things can be bought in my store.");
                    stage = 19;
                    break;
                case 19:
                    Npc("Every day that your animals are taken care of means you can reap your rewards the next day. For chickens that means eggs, for goat that means goatmilk");
                    stage = 20;
                    break;
                case 20:
                    Npc("for sheep that means wool, and for cows that means milk. If you don't have your own barn and animals you can just use mine! it's behind the shop.");
                    stage = 2;
                    break;
                case 21:
                    Npc("Both methods have their own unique rewards so it might be smart to do a bit of both. But if you only like farming livestock, thats cool too.");
                    stage = 22;
                    break;
                case 22:
                    Npc("Anyway, if you've done enough farming, either me or my brother can promote you to the new head of farming.");
                    stage = 2;
                    break;
                case 23:
                    Npc("Once you have your own barn you can keep more animals, you can buy the animals from me personally.");
                    stage = 24;
                    break;
                case 24:
                    SendOptionsDialogue("Select an option", "-Previous Page-", "Where to farm ?", "Master farming", "About a quest..", "Goodbye");
                    stage++;
                    break;
                case 25:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Where do I farm livestock?");
                            Npc("You can start off by taking care of my livestock, they're in the barn behind the shop. once you've gotten experienced enough you can get your own barn.");
                            stage = 23;
                            break;
                        case 2:
                            Player("I think I've become a master farmer.");
                            stage = 30;
                            break;
                        case 3:
                            Player("About a quest..");
                            stage = 26;
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
                case 26:
                    if (titoTutorialQuest.Stage < 3 || titoTutorialQuest.Stage > 16)
                    {
                        Npc("I don't have any quests for you");
                        stage = 24;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 27:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Laysee sent me here to get him some milk.");
                            if (titoTutorialQuest.Stage == 3)
                            {
                                Npc("Some milk? You've come to the right place.. But I won't give it for free. I'll give you some milk if you go and do something for me.");
                                stage++;
                            }
                            else if (titoTutorialQuest.Stage >= 4 && titoTutorialQuest.Stage < 15)
                            {
                                Npc("Go and get my mother's spoon from Jake, he nicked it and I want it back. Jake lives next door on the east.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 15 && player.InventoryContainer.Contains(401))
                            {
                                Player("Here's your mother's spoon.");
                                stage = 29;
                            }
                            else if (titoTutorialQuest.Stage == 15 && !player.InventoryContainer.Contains(401))
                            {
                                Npc("It seems you didn't bring the spoon. Go and get it from Jake in the house directly east from here.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 16 && !player.InventoryContainer.Contains(400) && player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the milk, good thing I have some extra.");
                                player.InventoryContainer.Add(400, 1);
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 16 && !player.InventoryContainer.Contains(400) && !player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the milk, good thing I have some extra. You don't seem to have space for it though, make some space and talk to me again.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 16 && player.InventoryContainer.Contains(400))
                            {
                                Npc("You've got the milk, go and take it to Laysee west of here.");
                                stage = 100;
                            }
                            else
                            {
                                Npc("I can't help you with that right now.");
                                stage = 24;
                            }
                            break;
                        case 0:
                            stage = 24;
                            Continue();
                            break;
                    }
                    break;
                case 28:
                    Npc("My mother always told me that I was her favorite son so she gave me the spoon she got from her mother. But Jake got jealous and nicked my spoon, please get it back for me. Jake lives next door.");
                    stage = 100;
                    titoTutorialQuest.SetStage(4);
                    break;
                case 29:
                    Npc("Thanks, heres some milk. Go and take it to Laysee west of here.");
                    player.InventoryContainer.Remove(401, 1);
                    player.InventoryContainer.Add(400, 1);
                    titoTutorialQuest.SetStage(16);
                    stage = 100;
                    break;
                case 30:
                    if (player.skills.GetSkill(SKILLS.FARMING).GetLevel() >= 50)
                    {
                        Npc("It seems you've been a capable master farmer. Me and my brother will be leaving the stores in your hands then. Together with the LIVESTOCK GANG and CROPS GANG.");
                        stage++;
                    }
                    else
                    {
                        Npc("Debatable. Try again when you reach level 50.");
                        stage = 3;
                    }
                    break;
                case 31:
                    SendOptionsDialogue("Select an option", "Yes", "No, not yet");
                    stage++;
                    break;
                case 32:
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
                case 33:
                    Npc("You know where the youth center is, right? It's south of town somewhere in the woods.");
                    stage++;
                    break;
                case 34:
                    Npc("By the time you hire some interns, we'll be out of this place, so I guess this will be goodbye. We're going to mexico!");
                    stage++;
                    break;
                case 35:
                    Player("Goodbye");
                    Npc("See ya");
                    //SET FARMING STATE TO 1
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
            Npc($"LIVESTOCK GANG at your service. How can I help?");
            stage = 0;
            return true;
        }
    }
}
