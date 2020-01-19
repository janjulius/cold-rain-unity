using Assets.Scripts.managers;
using Assets.Scripts.quest;
using Assets.Scripts.shops.constants;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class ArtisanDialogue : Dialogue
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
                    if (WorldStateManager.Instance.GetState(StateConstants.ARTISAN_NPC_STATE) == 1)
                    {
                        Npc("I told you to find an intern in the youth center south of town, Remember?");
                        stage = 100;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Wheelchair?", "What is an artisan?", "Progression", "Where can I work?", "-next page-");
                        stage++;
                    } 
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("How did you end up in that wheelchair?");
                            Npc("I had a stroke when I thought about the future of this town with this mayor. Since then my legs have been paralyzed.");
                            stage--;
                            break;
                        case 1:
                            Player("What does an artisan do?");
                            Npc("An artisan can do a large variety of things, but in my case I make leather armor for the archers, I make cheese and I make jam. Each one of those net me a nice profit.");
                            stage--;
                            break;
                        case 2:
                            Player("Can I become a master artisan?");
                            Npc("If you spend enough time in the workshop, anyone can become a master artisan. When you do believe you've become a master artisan please come and see me.");
                            stage++;
                            break;
                        case 3:
                            Player("Where can I work?");
                            Npc("You can work in my workshop in the back. the big machine in the right side is where you process leather. On the left side you can make cheese and jam.");
                            stage--;
                            break;
                        case 4:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 2:
                    Npc("Being an artisan in a wheelchair is very difficult, I've been waiting for someone that can take my post so I can finally stop doing this exhausing work.");
                    stage = 0;
                    break;
                case 3:
                    SendOptionsDialogue("Select an option", "-previous page-", "How to work the machines", "Master artisan", "About a quest", "Goodbye");
                    stage++;
                    break;
                case 4:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("How do I work the machines?");
                            stage++;
                            break;
                        case 3:
                            Player("About a quest..");
                            stage = 7;
                            break;
                        case 2:
                            Player("I think I've become a master artisan!");
                            stage = 10;
                            break;
                        case 4:
                            Player("Goodbye");
                            Npc("Oh, you're leaving..");
                            stage = 100;
                            break;
                        case 0:
                            stage = 0;
                            Continue();
                            break;
                    }
                    break;
                case 5:
                    SendOptionsDialogue("Select an option", "How to make cheese", "How to make jam", "How to make leather armor", "-previous page-");
                    stage++;
                    break;
                case 6:
                    switch (SelectedOption){
                        case 0:
                            Player("How do I make cheese?");
                            Npc("You can make cheese and jam at the same time in the smaller room in the back. You need some milk if you're going to make cheese. If you'd like to make some jam at the same time you should bring some berries.");
                            stage = 23;
                            break;
                        case 1:
                            Player("How do I make jam?");
                            Npc("You can make jam and cheese at the same time in the smaller room in the back. For jam you're just going to need a few berries. If you want to make cheese you should also bring some milk.");
                            stage = 21;
                            break;
                        case 2:
                            Player("How do I make leather armor?");
                            Npc("Do you see the big machine in the main room? That machine does all the work really. All you need to do is gather the materials neccesary to craft the armor that you want and bring it here.");
                            stage = 16;
                            break;
                        case 3:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 7:
                    if (titoTutorialQuest.Stage < 2 || titoTutorialQuest.Stage > 17)
                    {
                        Npc("I don't have any quests for you");
                        stage = 3;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 8:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Harold sent me here to borrow your ladder.");
                            if (titoTutorialQuest.Stage == 2)
                            {
                                Npc("Ah, Harold knows I don't lend out my ladder for free though. Blake runs the livestock shop east of here, if you can get me some of his milk I'll let you use my ladder.");
                                stage = 100;
                                titoTutorialQuest.SetStage(3);
                            }
                            else if (titoTutorialQuest.Stage >= 3 && titoTutorialQuest.Stage < 16)
                            {
                                Npc("Get me some milk from Blake's livestock shop east of here if you want to borrow my ladder.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 16 && player.InventoryContainer.Contains(400))
                            {
                                Player("Here's some milk.");
                                stage = 9;
                            }
                            else if (titoTutorialQuest.Stage == 16 && !player.InventoryContainer.Contains(400))
                            {
                                Npc("It seems you didn't me any milk. Go and get some from blake in the house east from here.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 17 && !player.InventoryContainer.Contains(399) && player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the ladder, good thing it found it's way back to me. Here you go.");
                                player.InventoryContainer.Add(399, 1);
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 17 && !player.InventoryContainer.Contains(399) && !player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the ladder, good thing it found it's way back to me. You don't seem to have space for it though, make some space and talk to me again.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 17 && player.InventoryContainer.Contains(399))
                            {
                                Npc("You've got my ladder, go and take it to Harold south of here.");
                                stage = 100;
                            }
                            else
                            {
                                Npc("I can't help you with that right now.");
                                stage = 3;
                            }
                            break;
                        case 0:
                            stage = 3;
                            Continue();
                            break;
                    }
                    break;
                case 9:
                    Npc("Thanks, heres the ladder. Go and bring it to Harold south of here.");
                    player.InventoryContainer.Remove(400, 1);
                    player.InventoryContainer.Add(399, 1);
                    titoTutorialQuest.SetStage(17);
                    stage = 100;
                    break;
                case 10:
                    if (player.skills.GetSkill(SKILLS.ARTISAN).GetLevel() >= 50)
                    {
                        Npc("You've become quite the master artisan. I'll be leaving the store in your hands then.");
                        stage++;
                    }
                    else
                    {
                        Npc("I beg to differ. Try again when you reach level 50 though!");
                        stage = 3;
                    }
                    break;
                case 11:
                    SendOptionsDialogue("Select an option", "Yes", "No, not yet");
                    stage++;
                    break;
                case 12:
                    switch (SelectedOption)
                    {
                        case 0:
                            Npc("Alright, I think you haven't got the time to run this shop on your own though, why don't you go find an intern in the youth center?");
                            stage++;
                            break;
                        case 1:
                            Npc("Oh... Well, please hurry! I'm struggling out here.");
                            stage = 3;
                            break;
                    }
                    break;
                case 13:
                    Npc("You know where the youth center is, right? It's south of town somewhere in the woods.");
                    stage++;
                    break;
                case 14:
                    Npc("By the time you hire one of them, I'll be out of this place, so I guess this will be goodbye. I'm moving to a facility that can properly take care of me.");
                    stage++;
                    break;
                case 15:
                    Player("Goodbye");
                    Npc("See ya");
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_NPC_STATE, 1);
                    stage = 100;
                    break;
                case 16:
                    Npc("When you bring the required materials to craft what you need, you should interact with the table to the left of the machine. On the table you can make a list of things you want to make.");
                    stage++;
                    break;
                case 17:
                    Npc("When the list is complete you can start the machine. The machine will be running for a certain amount of time depending on how much armor you are making.");
                    stage++;
                    break;
                case 18:
                    Npc("The fire in the back of the room needs to be running if you want to keep the machine going. The machine will pause when the fire isn't burning, so try to keep it going.");
                    stage++;
                    break;
                case 19:
                    Npc("While the machine is running it could also break.. it does quite commonly actually. It can't make progress while it broken, but all you need to do to fix it is walk over to the right spot and fix it.");
                    stage++;
                    break;
                case 20:
                    Npc("Once you've kept the machine running long enough you will get the armor you selected at the table at the start, and that'll be the end of it.");
                    stage = 5;
                    break;
                case 21:
                    Npc("The jam machine is in the left corner. When the machine is idle, you should be able to tell when that is, you can put some berries in it. The machine won't work without power so keep the fire close to it lit as much as possible.");
                    stage++;
                    break;
                case 22:
                    Npc("The machine only takes about ten seconds, while the fire is on, to mash the berries together and put them in a little pot. You can grab the jam from the little basket next to the machine once it's done.");
                    stage = 5;
                    break;
                case 23:
                    Npc("Making cheese has multiple stages. You start off by putting some milk in the big barrel, while it is powered, for about ten seconds. You can then collect unripened cheese from the barrel.");
                    stage++;
                    break;
                case 24:
                    Npc("Then you can bring the unripened cheese to the shelves close to the fire. It should also take around ten seconds to ripen the cheese. Once it's ripened you can grab your delicious cheese.");
                    stage++;
                    break;
                case 25:
                    Npc("I should mention that the cheese will ripen regardless of the fire, unlike the machine's that stop working when the fire is off. Also, making goat cheese is the exact same as normal cheese but you need to use goat milk.");
                    stage = 5;
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
            Npc("Watch your toes around these wheels. Im reckless.");
            stage = 0;
            return true;
        }
    }
}
