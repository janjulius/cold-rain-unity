using Assets.Scripts.quest;
using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class FishingDialogue : Dialogue
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
                    SendOptionsDialogue("Select an option", "Browse shop", "Why fish?", "How to fish", "Where to fish?", "-Next page-");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.FISHING_SHOP);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("What's the point of fishing?");
                            Npc("Seriously? Fishing is how you get fish.");
                            stage = 100;
                            break;
                        case 2:
                            Player("How do I fish?");
                            Npc("You buy a fishing rod, harpoon, or arrow on a rope and some bait from me, then you find a good spot, and then you start fishing.");
                            stage = 2;
                            break;
                        case 3:
                            Player("Where can I fish?");
                            Npc("You either go fishing in the ocean right outside this house, or you walk to the lake in the hunting area.");
                            stage = 100;
                            break;
                        case 4:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 2:
                    Npc("Regular bait will suffice for catching fish, but grubs and worms really lure the fish in. Harpoon/arrow fishing is a very quick way to catch fish but it also costs a lot of bait.");
                    stage = 100;
                    break;
                case 3:
                    SendOptionsDialogue("Select an option", "-Previous page-", "Progression", "About a quest..", "Goodbye");
                    stage++;
                    break;
                case 4:
                    switch (SelectedOption)
                    {
                        case 0:
                            stage = 0;
                            Continue();
                            break;
                        case 1:
                            Player("How do I become a better fisher?");
                            Npc("Just catch as many fish as you can, gradually you should become a better fisher. Once you're good enough you can come and relieve me of this post, I need to retire.");
                            stage = 100;
                            break;
                        case 2:
                            Player("About a quest..");
                            stage++;
                            break;
                        case 3:
                            Player("Goodbye");
                            Npc("Finally");
                            stage = 100;
                            break;
                    }
                    break;
                case 5:
                    if (titoTutorialQuest.IsCompleted() || !titoTutorialQuest.IsStarted() || titoTutorialQuest.Stage < 9)
                    {
                        Npc("Nope");
                        stage = 3;
                    }
                    else if (titoTutorialQuest.Stage >= 9)
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 6:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Sword really wants a marlin.");
                            if (titoTutorialQuest.Stage == 9)
                            {
                                Npc("Will you leave me alone if I give you a rotten marlin I've kept in the back and forgot about for a few months?.");
                                stage++;
                            }
                            else
                            {
                                Npc("I gave you a marlin for Sword, get out of here already.");
                                stage = 100;
                            }
                            break;
                        case 0:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 7:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage++;
                    break;
                case 8:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Yes");
                            if (player.InventoryContainer.Contains(406)){
                                Npc("You already have my marlin...");
                                stage = 100;
                            }
                            else if (player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("Alright here you go.");
                                player.InventoryContainer.Add(406, 1);
                                titoTutorialQuest.SetStage(10);
                                stage = 100;
                            }
                            else
                            {
                                Npc("You can't hold the marlin, make some space first.");
                                stage = 100;
                            }
                            break;
                        case 1:
                            Player("No");
                            Npc("Then you don't get a marlin.");
                            stage = 3;
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
        Npc($"What do you want.");
        stage = 0;
        return true;
    }
}
}
