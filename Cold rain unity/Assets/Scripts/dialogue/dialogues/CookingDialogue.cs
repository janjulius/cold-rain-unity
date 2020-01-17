using Assets.Scripts.quest;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class CookingDialogue : Dialogue
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
                    Player("For sure, oldie. I've got a question for you.");
                    stage++;
                    break;
                case 1:
                    Npc("Ask away.");
                    stage++;
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "Why cook?", "Ingredients?", "Meals?", "How to train?", "-next page-");
                    stage++;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("What's the point of cooking?");
                            Npc("Well, cooking is the only way to prepare food. Food is great because it revitalizes you instantly when you aren't feeling too well.");
                            stage = 4;
                            break;
                        case 1:
                            Player("Where do I get ingredients?");
                            Npc("Let me start by telling you what the commonly used ingredients are.");
                            stage = 6;
                            break;
                        case 2:
                            Player("What are meals?");
                            Npc("You can make meals when you get yourself a proper kitchen. Meals are a combination of certain foods, but the right combination is greater than the sum of its parts.");
                            stage = 11;
                            break;
                        case 3:
                            Player("How do I become a better cook?");
                            Npc("All you need to become a good cook is experience. In the beginning it might be a little rough as you'll find yourself burning food often, but as you progress that'll improve a lot!");
                            stage = 13;
                            break;
                        case 4:
                            stage = 14;
                            Continue();
                            break;
                    }
                    break;
                case 4:
                    Npc("Food is mostly important for staying alive during combat. Whenever the people from the combat guild go down into their dungeon they always bring plenty of food.");
                    stage++;
                    break;
                case 5:
                    Npc("If you are planning on joining the combat guild you should definitely look into obtaining some food, it's quite essential.");
                    stage = 2;
                    break;
                case 6:
                    Npc("There's fish and meat. Fish can ofcourse be obtained though fishing and meat can be obtained through hunting. Fish and meat come in many sizes that determine how much it will heal.");
                    stage++;
                    break;
                case 7:
                    Npc("There's also vegetables and other secondaries that can be obtained through farming, these are: tomato, corn, lettuce, onion, cheese, goatcheese and milk.");
                    stage++;
                    break;
                case 8:
                    Npc("These secondaries heal little when eaten, but they are required to make a meal. When they are used in a meal they will heal significantly more than before.");
                    stage++;
                    break;
                case 9:
                    Npc("Fish and meat work in a similar way, they can be cooked and eaten for a bit of health, but they will heal a lot more when they are combined into a meal.");
                    stage++;
                    break;
                case 10:
                    Npc("Last but not least, theres eggs. Eggs can be obtain through livestock farming and function similar to meat. The good thing about eggs is that you get them daily from keeping chickens so you don't have to go out of your way.");
                    stage = 2;
                    break;
                case 11:
                    Npc("Meals are generally made with two components; Meat/Fish and a secondary. The reason why meals are amazing is because they truly bring out the value of the components.");
                    stage++;
                    break;
                case 12:
                    Npc("For instance, eating a marlin and a tomato heals significantly less than a meal made by combining the two.");
                    stage = 2;
                    break;
                case 13:
                    Npc("You should start off with just cooking raw meat, and when you think you've gained enough experience you can get yourself a kitchen and start cooking proper meals.");
                    stage = 2;
                    break;
                case 14:
                    SendOptionsDialogue("Select an option", "-Previous page-", "Where to cook?", "Progression", "About a quest..", "-Next page-");
                    stage++;
                    break;
                case 15:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Where can I cook?");
                            Npc("You can cook in your own house when you have one. Once you've become exerienced enough you can even buy a kitchen upgrade and really get cooking.");
                            stage = 14;
                            break;
                        case 2:
                            Player("When can I be called master chef?");
                            Npc("When you've reached the highest possible skill in cooking you can be called master chef. You'll never burn a meal again.");
                            stage = 14;
                            break;
                        case 3:
                            Player("About a quest..");
                            stage++;
                            break;
                        case 4:
                            stage = 19;
                            Continue();
                            break;
                            Player("Goodbye");
                            Npc("So long");
                            stage = 100;
                            break;
                        case 0:
                            stage = 2;
                            Continue();
                            break;
                    }
                    break;
                case 16:
                    if (titoTutorialQuest.Stage < 6 || titoTutorialQuest.Stage > 13)
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
                            Player("Gunther sent me get him an answer to his love letter.");
                            if (titoTutorialQuest.Stage == 6)
                            {
                                Npc("Ugh I was hoping he'd just forget about it if I don't answer. Alright I'll write him an answer, could you go and fetch me a lovely poem from Susan in the meantime? she's a great poet.");
                                stage = 100;
                                titoTutorialQuest.SetStage(7);
                            }
                            else if (titoTutorialQuest.Stage >= 7 && titoTutorialQuest.Stage < 12)
                            {
                                Npc("I'll write an answer for Gunter if you go and fetch me a poem from Susan. She runs the archery section of the combat guild east from here.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 12 && player.InventoryContainer.Contains(404))
                            {
                                Player("Here's a poem written by Susan.");
                                stage = 18;
                            }
                            else if (titoTutorialQuest.Stage == 12 && !player.InventoryContainer.Contains(404))
                            {
                                Npc("It seems you lost the poem.. could you please go back to Susan?");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 13 && !player.InventoryContainer.Contains(403) && player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the reply letter, good thing I made an extra. Here you go.");
                                player.InventoryContainer.Add(403, 1);
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 13 && !player.InventoryContainer.Contains(403) && !player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the reply letter, good thing I made an extra. You don't seem to have space for it though, make some space and talk to me again.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 13 && player.InventoryContainer.Contains(403))
                            {
                                Npc("You've got my letter, go and bring it to Gunter north east of here.");
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
                    Npc("I appreciate it. I just finished the reply letter, here you go. Go and bring it to Gunther north east of here");
                    player.InventoryContainer.Remove(404, 1);
                    player.InventoryContainer.Add(403, 1);
                    titoTutorialQuest.SetStage(13);
                    stage = 100;
                    break;
                case 19:
                    SendOptionsDialogue("Select an option", "-Previous page-", "Master chef", "Goodbye");
                    stage++;
                    break;
                case 20:
                    switch (SelectedOption)
                    {
                        case 0:
                            stage = 14;
                            Continue();
                            break;
                        case 1:
                            Player("I think I am a real master chef now.");
                            stage++;
                            break;
                        case 2:
                            Player("Goodbye");
                            Npc("So long");
                            stage = 100;
                            break;
                    }
                    break;
                case 21:
                    if (player.skills.GetSkill(SKILLS.COOKING).GetLevel() >= 50)
                    {
                        Npc("You've become quite the master chef indeed.");
                        stage++;
                    }
                    else
                    {
                        Npc("I don't think so quite yet. Perhaps try again when you reach level 50.");
                        stage = 19;
                    }
                    break;
                case 22:
                    Npc("I'll Teach you a little trick then, I learned it from my husband before he passed away.");
                    //Make transition for dramatic effect
                    //SET COOKINGSTATE TO 1
                    stage++;
                    break;
                case 23:
                    Npc("Alright, if you keep this trick in mind you'll never burn a piece of food again.");
                    stage++;
                    break;
                case 24:
                    Npc("And thank you a lot for being our town's master chef, it really means a lot to me.");
                    stage++;
                    break;
                case 25:
                    Player("Yeah no problem.");
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
            Npc($"Hello there young one, can I help you?");
            stage = 0;
            return true;
        }
    }
}
