using Assets.Scripts.shops.constants;
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
            switch (stage)
            {
                case 0:
                    SendOptionsDialogue("Select an option", "Browse store", "Crops gang?", "CROPS GANG!", "Farming?", "Goodbye");
                    stage = 1;
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
                            Player("Goodbye");
                            Npc("See ya");
                            stage = 100;
                            break;
                    }
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "Why farm?", "Crops?", "Farming progression?", "Where to farm?", "Goodbye");
                    stage = 3;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("What's the point of farming?");
                            Npc("It is important for the town that there are farmers because farming is the only way to obtain secondaries for a solid meal. The town would be nothing without meals.");
                            stage = 4;
                            break;
                        case 1:
                            Player("So you farm crops?");
                            Npc("Yes, there are two farming methods; Livestock and crops. My brother next door runs the livestock gang if you're interested in that.");
                            stage = 7;
                            break;
                        case 2:
                            Player("How do I become a good farmer?");
                            Npc("Both farming livestock and farming crops should give you plenty of credibility as a good farmer, so you could do either... or both!");
                            stage = 11;
                            break;
                        case 3:
                            Player("Where do I farm crops?");
                            Npc("You can start off by using my greenhouse, it's behind the shop. once you've gotten experienced enough you can get your own greenhouse.");
                            stage = 13;
                            break;
                        case 4:
                            Player("Goodbye");
                            Npc("See ya");
                            stage = 100;
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
            Npc($"CROPS GANG at your service, how can I help?");
            stage = 0;
            return true;
        }
    }
}
