using Assets.Scripts.quest;
using Assets.Scripts.shops.constants;
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
                    Player("Testing dialogue");
                    stage = 2;
                    break;
                case 1:
                    Npc("Heres my shop");
                    stage = 100;
                    break;
                case 2:
                    if (titoTutorialQuest.IsCompleted())
                        SendOptionsDialogue("Select an option", "Goodbye", "I wanna talk to you", "Open the shop");
                    else if (!titoTutorialQuest.IsStarted())
                        SendOptionsDialogue("Select an option", "Goodbye", "I wanna talk to you", "Open the shop", "Do you have any quests?");
                    else
                        SendOptionsDialogue("Select an option", "Goodbye", "I wanna talk to you", "Open the shop", "About my quest...");
                    stage++;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Npc("Goodbye");
                            stage = 100;
                            break;
                        case 1:
                            Npc("I dont wanna talk to you");
                            stage = 4;
                            break;
                        case 2:
                            stage = 5;
                            Continue();
                            break;
                        case 3:
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
                            else if(!titoTutorialQuest.IsStarted())
                            {
                                stage = 6;
                                Npc("I do, actually perhaps you wanna go ahead and meet all the towns folks and whilst you do that you can go ahead and grab my package?");
                            }
                            else
                            {
                                Npc("No");
                                stage = 100;
                            }
                            break;
                    }
                    break;
                case 4:
                    Player("Bit rude but ok");
                    stage = 100;
                    break;
                case 5:
                    OpenShop(ShopConstants.TEST_SHOP);
                    End();
                    break;
                case 6:
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
