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
                    { }
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
