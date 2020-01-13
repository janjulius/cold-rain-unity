using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class FishingDialogue : Dialogue
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
                    SendOptionsDialogue("Select an option","Browse shop", "Why fish?", "How to fish", "Where to fish?", "Progression");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            Player("I'd like to have a look at your shop");
                            OpenShop(ShopConstants.FISHING_SHOP);
                            stage = 100;
                            break;
                        case 1:
                            Player("What's the point of fishing?");
                            Npc("Seriously? Fishing is how you get fish.");
                            stage = 100;
                            break;
                        case 2:
                            Player("How do I fish?");
                            Npc("You buy a fishing rod, harpoon, or arrow on a rope and some bait from me, then you find a good spot, and then you start fishing.");
                            stage = 2; 
                            break;
                        case 3:
                            Player("Where can I fish?");
                            Npc("You either go fishing in the ocean right outside this house, or you walk to the lake in the hunting area.");
                            stage = 100;
                            break;
                        case 4:
                            Player("How do I become a better fisher?");
                            Npc("Just catch as many fish as you can, gradually you should become a better fisher. Once you're good enough you can come and relieve me of this post, I need to retire.");
                            stage = 100;
                            break;
                    }
                    break;
                case 2:
                    Npc("Regular bait will suffice for catching fish, but grubs and worms really lure the fish in. Harpoon/arrow fishing is a very quick way to catch fish but it also costs a lot of bait.");
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
            Npc($"What do you want.");
            stage = 0;
            return true;
        }
    }
}
