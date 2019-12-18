using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue
{
    class DialogueHandler
    {

        public void SendDialogues(Entity entity, string message) => SendDialogues(entity, new string[] { message });

        public void SendDialogues(Entity entity, string[] messages)
        {
            //TODO: send the message
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {

        }
    }
}
