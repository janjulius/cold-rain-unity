using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class HunterDialogue : Dialogue
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
                    Player($"{player.name}");
                    stage++;
                    break;
                case 1:
                    Npc("Oh.. I thought you were one of those animal protection pests. How can I help?");
                    stage++;
                    break;
                case 2:
                    SendOptionsDialogue("Select an option", "Browse store", "Animal protection?", "Hunting?", "Goodbye");
                    stage++;
                    break;
                case 3:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("I'd like to have a look at your shop.");
                            OpenShop(ShopConstants.HUNTING_SHOP);
                            stage = 100;
                            Continue();
                            break;
                        case 1:
                            Player("Animal protection pests?");
                            Npc("Exactly, animal protection pests!");
                            stage = 4;
                            break;
                        case 2:
                            Player("Tell me something about hunting.");
                            Npc("What would you like to know?");
                            stage = 9;
                            break;
                        case 3:
                            Player("Goodbye");
                            Npc("See ya");
                            stage = 100;
                            break;
                    } 
                    break;
                case 4:
                    Npc("I've been hunting 'round this town for all my goddamn life and the wildlife has been doing perfectly well regardless! But then the pests appeared.");
                    stage++;
                    break;
                case 5:
                    Npc("They say the amount of wildlife in the area has been reduced by over 70% in the past two years and SOMEHOW they blame that on ME!");
                    stage++;
                    break;
                case 6:
                    Npc("Anyway, they've been making their stupid tv programs and things 'bout the way I do things 'round here and putting up signs claiming its 'Illegal' to hunt.");
                    stage++;
                    break;
                case 7:
                    Npc("I've been quite weary of those rats since they'll get officials involved to punish me for breaking the law regularly or some bollocks like that.");
                    stage++;
                    break;
                case 8:
                    Npc("If I see ya talkin' to any of them animal protection scum I'll consider you a spy. And this store is spy free so you'd be wise to watch out, kid.");
                    stage = 2;
                    break;
                case 9:
                    SendOptionsDialogue("Select an option", "Why hunt?", "Hunting progression", "Where do I hunt?", "Hunting methods", "-back-");
                    stage++;
                    break;
                case 10:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("What's the point of hunting?");
                            Npc("Oh boy where do I begin.. Mother nature is incapable of creating a balanced natural cycle of life and death, and that where the hunter comes in.");
                            stage++;
                            break;
                        case 1:
                            Player("How do I become a good hunter?");
                            Npc("Huntin' Deer, rodents, ducks, geese and birds is what makes you a good hunter. Once you've hunted down plenty of them you can come and talk to me.");
                            stage = 15;
                            break;
                        case 2:
                            Player("Where can I hunt?");
                            Npc("If yer follow the path out of this store all the way west, there'll be a dirt path i've made over the years draggin' me gear 'round. Follow that.");
                            stage = 9;
                            break;
                        case 3:
                            Player("Tell me about hunting methods.");
                            Npc("No.");// Write this shit with accurate information once the hunter skill's functionality has been added to the game.
                            stage = 9;
                            break;
                        case 4:
                            Player("Nevermind");
                            stage = 2;
                            break;
                    }
                    break;
                case 11:
                    Npc("By hunting the right animals at the right times, a hunter can get complete control over his area. Sometimes you need to hunt predators if you want to catch more of their prey.");
                    stage++;
                    break;
                case 12:
                    Npc("Now, I ain't no nerd so none of that crap means a damn to me. I hunt what I want to hunt, when I want to hunt, where I want to hunt.");
                    stage++;
                    break;
                case 13:
                    Npc("You're gonna want to hunt deer if you're after the best meat around, or deer leather. If you're after some easy to catch meat, catch some rodents.");
                    stage++;
                    break;
                case 14:
                    Npc("Now then, Ducks, Geese and birds should provide you with plenty of meat and feathers. And the best part is that any animal you kill should be able to bring some money to yer pockets.");
                    stage = 9;
                    break;
                case 15:
                    Npc("I've been lookin' to leave this town behind as my cover has been blown. I oughtta find me a place where I can get me some peaceful huntin' without animal protection scum 'round watching me every move.");
                    stage = 9;
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
            Npc($"WHO ARE YOU");
            stage = 0;
            return true;
        }
    }
}
