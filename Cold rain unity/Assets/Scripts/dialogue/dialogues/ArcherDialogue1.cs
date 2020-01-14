using Assets.Scripts.quest;
using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class ArcherDialogue1 : Dialogue
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
                    SendOptionsDialogue("Select an option", "Browse store", "What's wrong with warriors", "Weaponry", "Progression", "-Next page-");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.ARCHER_SHOP_WEAPONRY);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("What's wrong with warriors?");
                            Npc("Hah! are you mocking me? Warriors are inferior to archers in any imaginable way. Those simpleminded buffoons probably can't even wipe their own ass.");
                            stage++;
                            break;
                        case 2:
                            Player("What weapons are available to archers?");
                            Npc("There's regular bows, crossbows, short bows, long bows, chakras and shields. There's also arrows and bolts, arrows are used with the bows, short bows and long bows. Bolts are used with the crossbows.");
                            stage = 6;
                            break;
                        case 3:
                            Player("How do I become a good archer?");
                            Npc("When you think you've truly grasped the art of archery and have refined your skills, you can come and see me. I can set you up for a fight with the giant slime.");
                            stage = 12;
                            break;
                        case 4:
                            stage = 13;
                            Continue();
                            break;
                    }
                    break;
                case 2:
                    Npc("For decades now the warriors and have been competing with us for the guild leadership. We tried a civilized method inspired by the ancient greeks, democratic voting. Unfortunately we tied.");
                    stage++;
                    break;
                case 3:
                    Npc("Then we tried it their way and had a competition in slaying monsters. That didn't end well either because the warriors forgot to count.");
                    stage++;
                    break;
                case 4:
                    Npc("In the end both parties agreed that whichever side manages to kill the giant slime first, obtains guild leadership. And so far, no one has managed to do so.");
                    stage++;
                    break;
                case 5:
                    Npc("Perhaps, if you decide to become an archer, with our guidance you can become strong enough to take on the slime and claim that leadership.");
                    stage = 0;
                    break;
                case 6:
                    Npc("You should consider bows as the regular weapon, i'll describe the other weapons compared to the bow.");
                    stage++;
                    break;
                case 7:
                    Npc("The crossbow shoots rather slow and at a short range, but the bolts have a lot bigger impact on hit. The crossbow also only takes up one hand, so a shield can be used with the crossbow.");
                    stage++;
                    break;
                case 8:
                    Npc("The shortbow has a short range, but it can shoot arrows fast. The longbow is quite the opposite, it has a long range but it can't shoot very fast.");
                    stage++;
                    break;
                case 9:
                    Npc("Chakras are a bit of a special case, I learnt about them on my travels and quite fancy them.");
                    stage++;
                    break;
                case 10:
                    Npc("Chakras are throwable weapons that don't go very far and don't deal an impressive amount of damage, but you can throw them at an incredible speed and they are likely to hit a weak spot.");
                    stage++;
                    break;
                case 11:
                    Npc("Lastly, there's shields. Shields can be worn in combination with a crossbow or chakras, a shield provides you a ton of defense which can come in handy with those short range weapons.");
                    stage = 0;
                    break;
                case 12:
                    Npc("If you manage to defeat the giant slime, we will obtain leadership over the guild with you at the top.");
                    stage = 0;
                    break;
                case 13:
                    SendOptionsDialogue("Select an option", "-Previous page-", "About a quest..", "Goodbye");
                    stage++;
                    break;
                case 14:
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
                            Npc("It fare thee well");
                            stage = 100;
                            break;
                    }
                    break;
                case 15:
                    if (titoTutorialQuest.IsCompleted() || !titoTutorialQuest.IsStarted() || titoTutorialQuest.Stage < 7)
                    {
                        Npc("I don't have any quests for you");
                        stage = 13;
                    }
                    else if (titoTutorialQuest.Stage >= 7)
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 16:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Clara sent me to fetch her a poem written by you.");
                            if (titoTutorialQuest.Stage == 7)
                            {
                                Npc("Alas, I forgot. I was ment to write her a poem. I will write a poem right now, could you do me a favor in the meantime and fetch my husband's ring?");
                                stage++;
                            }
                            else
                            {
                                Npc("I'm writing the poem, go and fetch my husband's marriage ring. His name is Sword and he runs the warrior section in this building.");
                                stage = 100;
                            }
                            break;
                        case 0:
                            stage = 13;
                            Continue();
                            break;
                    }
                    break;
                case 17:
                    Npc("The man's dumber than a fish so I can hardly imagine he is emotionally invested in the marriage ring and we could really use some extra money. Sword, my husband, runs the warrior section in this building.");
                    titoTutorialQuest.SetStage(8);
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
            if (player.Combatstate == Combatstate.WARRIOR)
            {
                if (titoTutorialQuest.Stage >= 7)
                {
                    stage = 16;
                }
                else
                {
                    Npc("Shoo, get away, ape.");
                    stage = 100;
                }
            }
            else
            {
                Npc($"Splendid, you're not a warrior. How can I be of service?");
                stage = 0;
            }
            return true;
        }
    }
}
