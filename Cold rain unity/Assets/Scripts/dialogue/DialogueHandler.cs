using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.gameinterfaces.dialogue;
using UnityEngine;

namespace Assets.Scripts.dialogue
{
    public class DialogueHandler : Node
    {
        public DialogueUIHandler handler;
        public Dialogue CurrentDialogue;
        //public void SendDialogues(Entity entity, string message) => SendDialogues(entity, new string[] { message });

        public override void StartInitiate()
        {
            base.StartInitiate();
            handler = Camera.main.GetComponent<GameManager>().DialogeUIHandler;
            handler.gameObject.SetActive(false);
        }

        public void SendDialogues(Entity entity, string message)
        {
            if(!handler.gameObject.activeSelf)
                Open();
            if (entity != null)
                handler.SetSenderText(entity.EntityName);
            else
                handler.SetSenderText("");
            handler.SetDialogueText(message);
            Console.Instance.SendFilteredConsoleMessage($"{entity?.EntityName}: {message}");
        }

        internal void SetCurrentDialogue(Dialogue dialogue)
        {
            CurrentDialogue = dialogue;
        }

        public void Close()
        {
            handler.gameObject.SetActive(false);
        }

        public void Open()
        {
            handler.gameObject.SetActive(true);
        }

        public void Advance()
        {
            CurrentDialogue.Handle();
        }
    }
}
