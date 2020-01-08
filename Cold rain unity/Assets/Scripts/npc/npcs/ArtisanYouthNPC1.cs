using Assets.Scripts.dialogue;
using Assets.Scripts.dialogue.dialogues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.npc.npcs
{
    public class ArtisanYouthNPC1 : FriendlyNPC
    {
        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            dialogue = gameObject.GetComponent<ArtisanYouthDialogue1>() ?? gameObject.AddComponent<ArtisanYouthDialogue1>();
            dialogue.Open(null);
        }
    }
}
