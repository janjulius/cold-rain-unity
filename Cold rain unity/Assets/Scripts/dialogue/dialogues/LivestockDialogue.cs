using Assets.Scripts.contants;
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
            switch (stage)
            {
                case 0:
                    SendOptionsDialogue("Select an option", "Browse store", "Buy livestock", "Livestock gang?", "LIVESTOCK GANG!", "Farming?");
                    stage = 1;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("I'd like to have a look at your shop.");
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
                            stage = 100;
                            break;
                        case 3:
                            Player("LIVESTOCK GANG!");
                            Npc("G A N G  G A N G  L I V E S T O C K  G A N G  H O M E  D O G!");
                            stage = 100;
                            break;
                        case 4:
                            Player("Can you tell me something about farming?");
                            Npc("What would you like to hear about?");
                            stage = 2;
                            break;

                    }
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "Why farm?", "Livestock?", "Farming progression?", "Where to farm?", "Goodbye");
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
                            Player("What's the point of farming?");
                            Npc("It is important for the town that there are farmers because farming is the only way to obtain secondaries for a solid meal. The town would be nothing without meals.");
                            stage = 14;
                            break;
                        case 1:
                            Player("So you farm livestock?");
                            Npc("Yes, there are two farming methods; Livestock and crops. My brother next door runs the crops gang if you're interested in that.");
                            stage = 17;
                            break;
                        case 2:
                            Player("How do I become a good farmer?");
                            Npc("Both farming livestock and farming crops should give you plenty of credibility as a good farmer, so you could do either... or both!");
                            stage = 21;
                            break;
                        case 3:
                            Player("Where do I farm livestock?");
                            Npc("You can start off by taking care of my livestock, they're in the barn behind the shop. once you've gotten experienced enough you can get your own barn.");
                            stage = 23;
                            break;
                        case 4:
                            Player("Goodbye");
                            Npc("See ya");
                            stage = 100;
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
                    stage = 2;
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
