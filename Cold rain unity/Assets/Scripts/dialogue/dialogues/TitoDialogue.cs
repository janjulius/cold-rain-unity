using Assets.Scripts.quest;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class TitoDialogue : Dialogue
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
                    Player("Hello there!");
                    stage++;
                    break;
                case 1:
                    Npc("What do you want");
                    stage++;
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "I want to talk to you", "About a quest..", "Goodbye");
                    stage++;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("I want to talk to you.");
                            Npc("I dont wanna talk to you");
                            stage = 100;
                            break;
                        case 1:
                            Player("About a quest..");
                            stage = 5;
                            break;
                        case 2:
                            Player("Goodbye");
                            Npc("Bye bye");
                            stage = 100;
                            break;

                    }
                    break;
                case 4:
                    Player("Bit rude but ok");
                    stage = 100;
                    break;
                case 5:
                    if (titoTutorialQuest.IsCompleted())
                    {
                        Npc("I don't have any quests for you");
                        stage = 2;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 6:
                    switch (SelectedOption)
                    {
                        case 0:
                            stage = 2;
                            Continue();
                            break;
                        case 1:
                            if (!titoTutorialQuest.IsStarted())
                            {
                                stage = 7;
                                Npc("You could go fetch a package for me? I know it's not much of a quest but it should keep you busy for a little bit.");
                                break;
                            }
                            if (titoTutorialQuest.Stage > 0 && titoTutorialQuest.Stage < 19)
                            {
                                if (titoTutorialQuest.Stage < 18)
                                {
                                    stage = 100;
                                    Npc("Glad you are helping, please get my package from the hunter, he lives south west from here.");
                                }
                                else if (titoTutorialQuest.Stage == 18 && player.InventoryContainer.Contains(398))
                                {
                                    Npc("Ah there's my package, thanks");
                                    titoTutorialQuest.Finish();
                                    player.InventoryContainer.Remove(398, 1);
                                    stage = 100;
                                }
                                else if (titoTutorialQuest.Stage == 18 && !player.InventoryContainer.Contains(398))
                                {
                                    Npc("You forgot to bring my package.. whatever I don't need it anyway.");
                                    titoTutorialQuest.Finish();
                                    stage = 100;
                                }
                            }
                            else
                            {
                                Npc("I can't help you with that right now.");
                                stage = 2;
                            }
                            break;
                    }
                    break;
                case 7:
                    gameManager.ProposeQuest(0);
                    End();
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
            Npc($"Hello! My name is {NPC.EntityName}.");
            stage = 0;
            return true;
        }
    }
}
