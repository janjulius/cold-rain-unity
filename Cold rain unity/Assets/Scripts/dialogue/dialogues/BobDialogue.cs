using Assets.Scripts.contants;
using Assets.Scripts.managers;
using Assets.Scripts.quest;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class BobDialogue : Dialogue
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
                    Player("Bob.... the builder....?");
                    stage++;
                    break;
                case 1:
                    Npc("Yes, Bob the builder. Do you need any buildin'?");
                    stage++;
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "Kitchen", "Fishing expansion", "Barn", "Greenhouse", "Goodbye");
                    stage++;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("Build me a kitchen");
                            stage++;
                            break;
                        case 1:
                            Player("Build me a darkroom for the leeches and grubs");
                            stage = 5;
                            break;
                        case 2:
                            Player("Build me a barn");
                            stage = 6;
                            break;
                        case 3:
                            Player("Build me a greenhouse");
                            stage = 7;
                            break;
                        case 4:
                            Player("Goodbye");
                            Npc("Bye bye");
                            stage = 100;
                            break;

                    }
                    break;
                case 4:
                    if(Constants.DEVELOPER_MODE || player.skills.GetSkill(SKILLS.COOKING).GetLevel() >= 10)
                    {
                        if (WorldStateManager.Instance.GetState(skills.StateConstants.KITCHEN) == 0)
                        {

                            WorldStateManager.Instance.SetState(skills.StateConstants.KITCHEN, 1);
                            Npc("Sure thing buddy.");
                        }
                        else
                        {
                            Npc("I already have.");
                        }
                    }
                    else
                    {
                        Npc("You need to be atleast level 10 cooking for that.");
                    }
                    stage = 2;
                    break;
                case 5:
                    if (Constants.DEVELOPER_MODE || player.skills.GetSkill(SKILLS.FISHING).GetLevel() >= 10)
                    {
                        if (WorldStateManager.Instance.GetState(skills.StateConstants.FISHING_EXPANSION) == 0) {
                            WorldStateManager.Instance.SetState(skills.StateConstants.FISHING_EXPANSION, 1);
                            Npc("Sure thing buddy.");
                        }
                        else
                        {
                            Npc("I already have.");
                        }
                    }
                    else
                    {
                        Npc("You need to be atleast level 10 fishing for that.");
                    }
                    stage = 2;
                    break;
                case 6:
                    if (Constants.DEVELOPER_MODE || player.skills.GetSkill(SKILLS.FARMING).GetLevel() >= 10)
                    {
                        if (WorldStateManager.Instance.GetState(skills.StateConstants.LIVESTOCK_EXPANSION) == 0) {
                            WorldStateManager.Instance.SetState(skills.StateConstants.LIVESTOCK_EXPANSION, 1);
                            Npc("Sure thing buddy.");
                        }
                        else
                        {
                            Npc("I already have.");
                        }
                    }
                    else
                    {
                        Npc("You need to be atleast level 10 farming for that.");
                    }
                    stage = 2;
                    break;
                case 7:
                    if (Constants.DEVELOPER_MODE || player.skills.GetSkill(SKILLS.FARMING).GetLevel() >= 10)
                    {
                        if (WorldStateManager.Instance.GetState(skills.StateConstants.CROPS_EXPANSION) == 0) {
                            WorldStateManager.Instance.SetState(skills.StateConstants.CROPS_EXPANSION, 1);
                            Npc("Sure thing buddy.");
                        }
                        else
                        {
                            Npc("I already have.");
                        }
                    }
                    else
                    {
                        Npc("You need to be atleast level 10 farming for that.");
                    }
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
            Npc($"Hello! My name is {NPC.EntityName}. I am the builder.");
            stage = 0;
            return true;
        }
    }
}
