using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class FriendDialogue : Dialogue
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
                    SendOptionsDialogue("Select an option", "What's going on?", "What should I do?", "Where do I sleep?", "Goodbye");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("What's going on?");
                            Npc("You passed out, don't you remember what happened?");
                            stage++; 
                            break;
                        case 1:
                            Player("What should I do?");
                            Npc("Well, I think you should start by talking to the mayor, the mayor lives in the big house, two houses east from here.");
                            stage = 13;
                            break;
                        case 2:
                            Player("Where can I sleep?");
                            Npc("You can sleep at my place ofcourse, you can use the bed in the right side of the house.");
                            stage = 14;
                            break;
                        case 3:
                            Player("Goodbye");
                            Npc("See ya");
                            stage = 100;
                            break;
                    }
                    break;
                case 2:
                    Player("I don't remember what happened... I don't remember anything at all actually");
                    stage++;
                    break;
                case 3:
                    Npc("Well, you must atleast remember your name, right?");
                    stage++;
                    break;
                case 4:
                    Player("No I don't..");
                    stage++;
                    break;
                case 5:
                    Npc("Come on, think! I know you must atleast remember your name..");
                    stage++;
                    break;
                case 6:
                    SendOptionsDialogue("What was your name?", "John", "Jane");
                    stage++;
                    break;
                case 7:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("My name is John");
                            player.SetEntityName("John");
                            break;
                        case 1:
                            Player("My name is Jane");
                            player.SetEntityName("Jane");
                            break;
                    }
                    stage++;
                    break;
                case 8:
                    Npc($"That's right, {player.EntityName}. Now, I guess I'll give you a summary of what happened.");
                    stage++;
                    break;
                case 9:
                    Npc("We were friends in highschool, but we lost contact when highschool ended, we both went our own ways. I went here, and you went to college.");
                    stage++;
                    break;
                case 10:
                    Npc("But then suddenly you called me up a week ago, you said college was a mistake and you were in huge trouble. So you asked me if you could stay here for a while.");
                    stage++;
                    break;
                case 11:
                    Npc("Ofcourse I said yes. When you came here yesterday evening you were completely burned out and just went to sleep before even saying hello properly.");
                    stage++;
                    break;
                case 12:
                    Npc("So I don't really know what was going on in your life that much, but I know you're here now. And I'm sure you can find your place in this lovely village.");
                    stage = 0;
                    break;
                case 13:
                    Npc("There's a big old house south east of town, it's not being used right now but maybe the mayor is willing to let you use it! you should go and ask him about it.");
                    stage = 0;
                    break;
                case 14:
                    Npc("But you could also go talk to the mayor, he lives two houses east from here. He might be willing to let you use the old house south east of town. You could sleep there too.");
                    stage = 0;
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
            Npc($"What's up?");
            stage = 0;
            return true;
        }
    }
}
