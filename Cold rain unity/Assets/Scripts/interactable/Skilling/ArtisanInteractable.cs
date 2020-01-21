using Assets.Scripts.activity.minigame;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.managers;
using Assets.Scripts.managers.skilling;
using Assets.Scripts.skills;
using Assets.Scripts.skills.Artisan;
using System;
using UnityEngine;

namespace Assets.Scripts.interactable.Skilling
{
    public class ArtisanInteractable : Interactable
    {
        SkillingInterfaceManager skillingInterfaceManager;
        Player player;
        ArtisanFoodActivity foodActivity;
        GameManager manager;
        public ArtisanInteractableType interactableType;
        private readonly int berryAmount = 3;
        private readonly int milkAmount = 1;
        private readonly int cheeseAmount = 1;
        private readonly int jamExp = 100;
        private readonly int milkExp = 100;
        private readonly int cheeseExp = 100;

        public override void Initiate()
        {
            base.Initiate();
            skillingInterfaceManager = Camera.main.GetComponent<GameManager>().skillingInterfaceManager;
        }

        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            player = (Player)sender;
            manager = Camera.main.GetComponent<GameManager>();
            foodActivity = manager.ActivitiesObject.GetComponent<ArtisanFoodActivity>();
            switch (interactableType)
            {
                case ArtisanInteractableType.LEATHER:
                    skillingInterfaceManager.OpenArtisanInterface(player);
                    break;
                case ArtisanInteractableType.MACHINE:
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_MACHINE, 0);
                    break;
                case ArtisanInteractableType.FIREPLACE_1:
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_FIREPLACE_1, 1);
                    break;
                case ArtisanInteractableType.FIREPLACE_2:
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_FIREPLACE_2, 1);
                    break;
                case ArtisanInteractableType.JAM_START:
                    if (player.InventoryContainer.Contains(271))
                    {
                        if (player.InventoryContainer.GetAmount(271) >= berryAmount)
                        {
                            player.InventoryContainer.Remove(271, berryAmount);
                            WorldStateManager.Instance.SetState(StateConstants.ARTISAN_JAM_IDLE, 1);
                            foodActivity.StartJamActivity(player);
                            GameConsole.Instance.SendConsoleMessage("You put some berries in the machine.");
                        }
                        else
                        {
                            GameConsole.Instance.SendConsoleMessage("You don't have enough berries to make jam.");
                        }
                    }
                    else
                    {
                        GameConsole.Instance.SendConsoleMessage("You don't have any berries.");
                    }
                    break;
                case ArtisanInteractableType.JAM_DONE:
                    player.InventoryContainer.Add(363, 1);
                    player.skills.GetSkill(SKILLS.ARTISAN).AddExp(jamExp);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_JAM_DONE, 0);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_JAM_IDLE, 0);
                    break;
                case ArtisanInteractableType.MILK_START:
                    GetComponent<MilkBarrel>().Open(new object[] { foodActivity });
                    break;
                case ArtisanInteractableType.MILK_DONE:
                    player.InventoryContainer.Add(410, 1);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_MILK_DONE, 0);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_MILK_IDLE, 0);
                    player.skills.GetSkill(SKILLS.ARTISAN).AddExp(milkExp);
                    break;
                case ArtisanInteractableType.GOAT_MILK_DONE:
                    player.InventoryContainer.Add(411, 1);
                    player.skills.GetSkill(SKILLS.ARTISAN).AddExp(milkExp);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_GOAT_MILK_DONE, 0);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_MILK_IDLE, 0);
                    break;
                case ArtisanInteractableType.CHEESE_START:
                    GetComponent<CheeseShelf>().Open(new object[] { foodActivity });
                    break;
                case ArtisanInteractableType.CHEESE_DONE:
                    player.InventoryContainer.Add(361, 1);
                    player.skills.GetSkill(SKILLS.ARTISAN).AddExp(cheeseExp);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_CHEESE_DONE, 0);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_CHEESE_IDLE, 0);
                    break;
                case ArtisanInteractableType.GOAT_CHEESE_DONE:
                    player.InventoryContainer.Add(362, 1);
                    player.skills.GetSkill(SKILLS.ARTISAN).AddExp(cheeseExp);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_GOAT_CHEESE_DONE, 0);
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_CHEESE_IDLE, 0);
                    break;
            }
        }

        public void HandleMilk(int milkType)
        {
            switch (milkType)
            {
                case 0:
                    if (player.InventoryContainer.Contains(275))
                    {
                        if (player.InventoryContainer.GetAmount(275) >= milkAmount)
                        {
                            player.InventoryContainer.Remove(275, milkAmount);
                            WorldStateManager.Instance.SetState(StateConstants.ARTISAN_MILK_IDLE, 1);
                            foodActivity.StartMilkActivity(player, milkType);
                            GameConsole.Instance.SendConsoleMessage("You put some milk in the barrel.");
                        }
                        else
                        {
                            GameConsole.Instance.SendConsoleMessage("You don't have enough milk to make unripe cheese.");
                        }
                    }
                    else
                    {
                        GameConsole.Instance.SendConsoleMessage("You don't have any milk.");
                    }
                    break;
                case 1:
                    if (player.InventoryContainer.Contains(276))
                    {
                        if (player.InventoryContainer.GetAmount(276) >= milkAmount)
                        {
                            player.InventoryContainer.Remove(276, milkAmount);
                            WorldStateManager.Instance.SetState(StateConstants.ARTISAN_MILK_IDLE, 1);
                            foodActivity.StartMilkActivity(player, milkType);
                            GameConsole.Instance.SendConsoleMessage("You put some milk in the barrel.");
                        }
                        else
                        {
                            GameConsole.Instance.SendConsoleMessage("You don't have enough goat milk to make unripe goat cheese.");
                        }
                    }
                    else
                    {
                        GameConsole.Instance.SendConsoleMessage("You don't have any goat milk.");
                    }
                    break;
            }
        }
        public void HandleCheese(int cheeseType)
        {
            switch (cheeseType)
            {
                case 0:
                    if (player.InventoryContainer.Contains(410))
                    {
                        if (player.InventoryContainer.GetAmount(410) >= cheeseAmount)
                        {
                            player.InventoryContainer.Remove(410, cheeseAmount);
                            WorldStateManager.Instance.SetState(StateConstants.ARTISAN_CHEESE_IDLE, 1);
                            foodActivity.StartCheeseActivity(player, cheeseType);
                            GameConsole.Instance.SendConsoleMessage("You put some cheese on the shelf.");
                        }
                        else
                        {
                            GameConsole.Instance.SendConsoleMessage("You don't have enough unripe cheese to make cheese.");
                        }
                    }
                    else
                    {
                        GameConsole.Instance.SendConsoleMessage("You don't have any unripe cheese.");
                    }
                    break;
                case 1:
                    if (player.InventoryContainer.Contains(411))
                    {
                        if (player.InventoryContainer.GetAmount(411) >= cheeseAmount)
                        {
                            player.InventoryContainer.Remove(411, cheeseAmount);
                            WorldStateManager.Instance.SetState(StateConstants.ARTISAN_CHEESE_IDLE, 1);
                            foodActivity.StartCheeseActivity(player, cheeseType);
                            GameConsole.Instance.SendConsoleMessage("You put some goat cheese on the shelf.");
                        }
                        else
                        {
                            GameConsole.Instance.SendConsoleMessage("You don't have enough unripe goat cheese to make goat cheese.");
                        }
                    }
                    else
                    {
                        GameConsole.Instance.SendConsoleMessage("You don't have any unripe goat cheese.");
                    }
                    break;
            }
        }
    }

    [Flags]
    public enum ArtisanInteractableType
    {
        LEATHER = (1 << 0),
        JAM_START = (1 << 1),
        MILK_START = (1 << 2),
        CHEESE_START = (1 << 3),
        JAM_DONE = (1 << 4),
        MILK_DONE = (1 << 5),
        GOAT_MILK_DONE = (1 << 6),
        CHEESE_DONE = (1 << 7),
        GOAT_CHEESE_DONE = (1 << 8),
        FIREPLACE_1 = (1 << 9),
        FIREPLACE_2 = (1 << 10),
        MACHINE = (1 << 11)
    }
}
