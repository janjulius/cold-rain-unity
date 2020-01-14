using Assets.Scripts.quest;
using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class WarriorDialogue1 : Dialogue
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
                    SendOptionsDialogue("Select an option", "Browse store", "What's wrong with archers", "Weaponry", "Progression", "-Next page-");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.WARRION_SHOP_WEAPONRY);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("What's wrong with archers?");
                            Npc("ARCHER BAD.");
                            stage--;
                            break;
                        case 2:
                            Player("What weapons are available to warriors?");
                            Npc("SWORD. DAGGER. GREATXE. SCYTHE AND THERE IS SHIELD. WARRIOR CAN ALSO THROW ROCK.");
                            stage++;
                            break;
                        case 3:
                            Player("How do I become a good warrior?");
                            Npc("GOOD WARRIOR SPEAK TO ME AND THEN FIGHT BIG SLIME IN BASEMENT. WHEN KILL BIG SLIME GOOD WARRIOR BECOME BIG BOSS AROUND.");
                            stage--;
                            break;
                        case 4:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 2:
                    Npc("SWORD IS REGULAR WEAPON. DAGGER VERY FAST BUT ALSO SMALL. GREATAXE VERY BIG AND STRONG BUT SLOW. SCYTHE WEAK BUT FAST AND HIT GOOD. SHIELD BLOCK HIT. ROCK ANNOY ENEMY.");
                    stage = 0;
                    break;
                case 3:
                    SendOptionsDialogue("Select an option", "-Previous Page-", "About a quest..", "Goodbye");
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
                            Player("About a quest..");
                            stage++;
                            break;
                        case 2:
                            Player("Goodbye");
                            Npc("YES BYE");
                            stage = 100;
                            break;
                    }
                    break;
                case 5:
                    if (titoTutorialQuest.IsCompleted() || !titoTutorialQuest.IsStarted() || titoTutorialQuest.Stage < 8)
                    {
                        Npc("NO QUEST FOR YOU");
                        stage = 3;
                    }
                    else if (titoTutorialQuest.Stage >= 8)
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 6:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Your wife sent me to fetch your wedding ring.");
                            if (titoTutorialQuest.Stage == 8)
                            {
                                Npc("WEDDING RING? WEDDING RING EXPENSIVE. WEDDING RING NOT FOR FREE, ONLY TRADE FOR EXPENSIVE ITEM LIKE MARLIN.");
                                stage++;
                            }
                            else
                            {
                                Npc("YOU GET ME MARLIN FROM FINCH EAST OF HERE THEN YOU GET RING.");
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
                    Player("Alright I'll get you a marlin from Finch's fish shop east of here.");
                    titoTutorialQuest.SetStage(9);
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
            Quest titoTutorialQuest = gameManager.GetQuestById(0);
            if (player.Combatstate == Combatstate.ARCHER)
            {
                if (titoTutorialQuest.Stage >= 8)
                {
                    stage = 6;
                }
                else
                {
                    Npc("BACK OFF SMARTASS.");
                    stage = 100;
                }
            }
            else
            {
                Npc($"HELLO THERE. YOU ARE NOT ARCHER! I HELP?");
                stage = 0;
            }
            return true;
        }
    }
}
