using Assets.Scripts.quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class MayorDialogue : Dialogue
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
                    SendOptionsDialogue("Select an option", "Hello", "About a quest..", "Goodbye");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Hello");
                            Npc("Good day");
                            stage--;
                            break;
                        case 1:
                            Player("About a quest..");
                            stage++;
                            break;
                        case 2:
                            Player("Goodbye");
                            Npc("Farewell");
                            stage = 100;
                            break;
                    }
                    break;
                case 2:
                    if (titoTutorialQuest.Stage < 5 || titoTutorialQuest.Stage > 14)
                    {
                        Npc("I don't have any quests for you");
                        stage = 0;
                    }
                    else
                    {
                        SendOptionsDialogue("Select an option", "Previous page", "Tito's tutorial");
                        stage++;
                    }
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 1:
                            Player("Jake sent me to get a permit for growing tomatoes.");
                            if (titoTutorialQuest.Stage == 5)
                            {
                                Npc("Yuck tomatoes!? Hmm, I might despise tomatoes but what I despise even more is being ignored. I sent clara a love letter but she hasn't replied yet. Get me an answer and I'll get you a permit.");
                                stage = 100;
                                titoTutorialQuest.SetStage(6);
                            }
                            else if (titoTutorialQuest.Stage >= 6 && titoTutorialQuest.Stage < 13)
                            {
                                Npc("Go and get me an answer from Clara, she lives in the house south west of here.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 13 && player.InventoryContainer.Contains(403))
                            {
                                Player("Here's a reply from Clara.");
                                stage = 4;
                            }
                            else if (titoTutorialQuest.Stage == 13 && !player.InventoryContainer.Contains(403))
                            {
                                Npc("It seems you lost the letter.. go get a new one from Clara");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 14 && !player.InventoryContainer.Contains(402) && player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the permit. You're lucky I always make a backup.");
                                player.InventoryContainer.Add(402, 1);
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 14 && !player.InventoryContainer.Contains(402) && !player.InventoryContainer.HasFreeSlots())
                            {
                                Npc("It seems you have lost the permit. You're lucky I always make a backup. You don't seem to have space for it though, make some space and talk to me again.");
                                stage = 100;
                            }
                            else if (titoTutorialQuest.Stage == 14 && player.InventoryContainer.Contains(402))
                            {
                                Npc("You've got your permit. Scram, back to where you came from north east of here.");
                                stage = 100;
                            }
                            else
                            {
                                Npc("I can't help you with that right now.");
                                stage = 0;
                            }
                            break;
                        case 0:
                            stage = 0;
                            Continue();
                            break;
                    }
                    break;
                case 4:
                    Npc("Thanks, here's your permit. Go and bring it to Jake north east of here.");
                    player.InventoryContainer.Remove(403, 1);
                    player.InventoryContainer.Add(402, 1);
                    titoTutorialQuest.SetStage(14);
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
            Npc($"You are speaking to the one and only {NPC.EntityName}.");
            stage = 0;
            return true;
        }
    }
}
