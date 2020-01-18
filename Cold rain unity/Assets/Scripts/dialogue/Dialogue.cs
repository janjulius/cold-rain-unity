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

        protected GameManager gameManager;

        public int SelectedOption = -1;

        public override void Initiate()
        {
            base.Initiate();
            handler = Camera.main.GetComponent<DialogueHandler>();
            gameManager = Camera.main.GetComponent<GameManager>();
            NPC = GetComponent<Entity>();
            if (player == null)
                player = NPC?.facingEntity?.GetComponent<Player>() ?? FindObjectOfType<Player>();
        }

        public override void StartInitiate()
        {
            base.StartInitiate();
            
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

        /// <summary>
        /// continues to the next stage without having to call a specific dialogue
        /// </summary>
        protected void Continue()
        {
            Handle();
        }

        public void SendOptionsDialogue(string title, params string[] options)
        {
            handler?.SendOptionDialogue(title, options);
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

        public void DialogueNoTitle(object message)
        {
            handler.SendDialogues(null, message.ToString());
        }

        protected void OpenShop(int id)
        {
            Camera.main.GetComponent<GameManager>().LoadShop(id);
        }

        public virtual bool Open(object[] args)
        {
            handler.SetCurrentDialogue(this);
            NPC?.Lock();
            return true;
        }
        public abstract void End(object[] args);

        public void End()
        {
            stage = 0;
            NPC?.Unlock();
            handler?.Close();
        }
    }
}
