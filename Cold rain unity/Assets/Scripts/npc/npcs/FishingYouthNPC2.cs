using Assets.Scripts.dialogue;
using Assets.Scripts.dialogue.dialogues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.npc.npcs
{
    public class FishingYouthNPC2 : FriendlyNPC
    {
        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            dialogue = gameObject.GetComponent<FishingYouthDialogue2>() ?? gameObject.AddComponent<FishingYouthDialogue2>();
            dialogue.Open(null);
        }
    }
}

