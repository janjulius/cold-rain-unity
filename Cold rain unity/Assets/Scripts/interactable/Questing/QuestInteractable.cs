using Assets.Scripts.gameinterfaces.console;
using System;

namespace Assets.Scripts.interactable.Questing
{
    public class QuestInteractable : Interactable
    {
        Player player;
        public QuestInteractableType interactableType;

        public override void Initiate()
        {
            base.Initiate();
        }

        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            player = (Player)sender;
            print("interactabletype " + interactableType);
            switch (interactableType)
            {
                case QuestInteractableType.TREES:
                    if (!player.InventoryContainer.Contains(412))
                    {
                        print("Adding sleigh");
                        player.InventoryContainer.Add(412, 1);
                        GameConsole.Instance.SendConsoleMessage("YOU FOUND SANTA'S SLEIGH!!!");
                    }
                    else
                    {
                        print("Already have sleigh");
                        GameConsole.Instance.SendConsoleMessage("YOU ALREADY FOUND SANTA'S SLEIGH!!! GO BRING IT TO GUNTHER THE MAYOR.");
                    }
                    break;
            }
        }
    }
    
    public enum QuestInteractableType
    {
        TREES
    }
}
