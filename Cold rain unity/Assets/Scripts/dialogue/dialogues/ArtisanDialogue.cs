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
            switch (stage)
            {
                case 0:
                    SendOptionsDialogue("Select an option", "Wheelchair?", "What is an artisan?", "Progression", "Where can I work?", "-next page-");
                    stage++;
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
                    SendOptionsDialogue("Select an option", "How do I make cheese?", "How do I make jam?", "How do I make leather armor?", "Goodbye", "-previous page-");
                    stage++;
                    break;
                case 4:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("How do I make cheese?");
                            Npc("You don't"); //write this when artisan has been fully worked out.
                            break;
                        case 1:
                            Player("How do I make jam?");
                            Npc("You don't"); //write this when artisan has been fully worked out.
                            break;
                        case 2:
                            Player("How do I make leather armor?");
                            Npc("You don't"); //write this when artisan has been fully worked out.
                            break;
                        case 3:
                            Player("Goodbye");
                            Npc("Oh, you're leaving?");
                            stage = 100;
                            break;
                        case 4:
                            stage = 0;
                            Continue();
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
            Npc("Watch your toes around these wheels. Im reckless.");
            stage = 0;
            return true;
        }
    }
}
