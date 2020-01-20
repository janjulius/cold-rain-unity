using Assets.Scripts.quest;
using System;

namespace Assets.Scripts.dialogue.dialogues
{
    class TitaDialogue : Dialogue
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
                    Player("Hello there!");
                    stage++;
                    break;
                case 1:
                    Npc("What do you want");
                    stage++;
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "I want to talk to you", "Goodbye");
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
