using Assets.Scripts.gameinterfaces.dialogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.dialogue
{
    public abstract class Dialogue : Node
    {
        protected int stage = -1;

        protected Entity NPC;
        protected Player player;

        private DialogueHandler handler;
        //private DialogueUIHandler handler;

        public override void Initiate()
        {
            base.StartInitiate();
            handler = Camera.main.GetComponent<DialogueHandler>();
            NPC = GetComponent<Entity>();
            if (player == null)
                player = NPC?.facingEntity?.GetComponent<Player>() ?? FindObjectOfType<Player>();
            handler.SetCurrentDialogue(this);
        }

        public void Setup(Player player)
        {
            this.player = player;
        }

        public virtual void Handle()
        {
            if (handler == null)
                handler = Camera.main.GetComponent<DialogueHandler>();
            if (stage == -1)
                handler.Open();
        }

        public void Player(object message)
        {
            handler.SendDialogues(player, message.ToString());
        }

        internal int GetStage()
        {
            return stage;
        }

        public void Npc(object message)
        {
            handler.SendDialogues(NPC, message.ToString());
        }

        protected void OpenShop(int id)
        {
            Camera.main.GetComponent<GameManager>().LoadShop(id);
        }
        
        public abstract bool Open(object[] args);
        public abstract void End(object[] args);

        public void End() => handler?.Close();

    }
}
