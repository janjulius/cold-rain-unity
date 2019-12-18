using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue
{
    public abstract class Dialogue
    {
        protected int stage = -1;

        protected Entity NPC;
        protected Player player;

        private DialogueHandler handler;
        
        public void Setup(Player player)
        {
            this.player = player;
        }

        public virtual void Handle()
        {

        }

        public void Player(object message)
        {
            handler.SendDialogues(player, message.ToString());
        }

        public void Npc(object message)
        {
            handler.SendDialogues(NPC, message.ToString());
        }

        public abstract bool Open(object[] args);
        public abstract void End(object[] args);

        public void End() => handler?.Close();

    }
}
