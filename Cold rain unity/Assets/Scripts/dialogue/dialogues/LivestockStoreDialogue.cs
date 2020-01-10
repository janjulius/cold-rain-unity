using Assets.Scripts.contants;
using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class LivestockStoreDialogue : Dialogue
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
                    SendOptionsDialogue("Select an option", "Browse store", "Purchase chicken", "Purchase goat", "Purchase sheep", "Purchase cow");
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
                            Player("I'd like to purchase a chicken.");
                            Npc("One chicken, that'll be " + chickenPrice + ". Is that alright?");
                            stage = 6;
                            break;
                        case 2:
                            Player("I'd like to purchase a goat.");
                            Npc("One goat, that'll be " + goatPrice + ". Is that alright?");
                            stage = 7;
                            break;
                        case 3:
                            Player("I'd like to purchase a sheep.");
                            Npc("One sheep, that'll be " + sheepPrice + ". Is that alright?");
                            stage = 8;
                            break;
                        case 4:
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
            Npc($"What would you Like to do?");
            stage = 0;
            return true;
        }
    }
}
