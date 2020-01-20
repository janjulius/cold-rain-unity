using Assets.Scripts.dialogue;
using Assets.Scripts.dialogue.dialogues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.npc.npcs
{
    public class TitusNPC : FriendlyNPC
    {
        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            dialogue = gameObject.GetComponent<TitusDialogue>() ?? gameObject.AddComponent<TitusDialogue>();
            dialogue.Open(null);
        }
    }
}
