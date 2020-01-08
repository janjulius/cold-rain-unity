using Assets.Scripts.container;
using Assets.Scripts.databases.game;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.gameinterfaces.shop;
using Assets.Scripts.item;
using Assets.Scripts.shops;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightClickMenuController : Node, IPointerClickHandler
{
    public Button sampleButton;
    private List<RightClickMenuItem> contextMenuItems;
    private ItemSlot parentObject;
    private Player player;
    private GameManager gameManager;
    
    public override void Initiate()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
        player = gameManager.player;
        contextMenuItems = new List<RightClickMenuItem>();
        parentObject = GetComponent<ItemSlot>();
        
        //contextMenuItems.Add(new RightClickMenuItem("Use", sampleButton, use));
        //contextMenuItems.Add(new RightClickMenuItem("Examine", sampleButton, examine));
        //contextMenuItems.Add(new RightClickMenuItem("Drop", sampleButton, drop));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemSlot slot = GetComponent<ItemSlot>();
        Item item = slot.getItem();
        GameInterface parentInterface = GetComponentInParent<GameInterface>();
        ConstructContextMenu(slot, item, parentInterface, player.IsInShop);
        if (item != null)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                RightClickMenu.Instance.CreateContextMenu(contextMenuItems,
                    eventData.pointerPress.transform.position);
                //new Vector2(this.GetComponent<RectTransform>().position.x ,
                //this.GetComponent<RectTransform>().position.y ) );
                print($"{slot.transform.position} { eventData.pointerPress.transform.position}");
               //print($"{ parentInterface.name} = {this.GetComponent<RectTransform>().position.x} + {parentInterface.GetComponent<RectTransform>().position.x}" +
               //    $"{this.GetComponent<RectTransform>().position.y} + {parentInterface.GetComponent<RectTransform>().position.y}) ");
            }

            if (eventData.button == PointerEventData.InputButton.Left)
            {

            }
        }
    }

    private void ConstructContextMenu(ItemSlot slot, Item item, GameInterface parentInterface, bool isInShop)
    {
        ClearContextMenu();
        if (isInShop)
        {
            contextMenuItems.Add(new RightClickMenuItem($"Value {item.Name}", sampleButton, ValueAction));
            if (parentInterface is ShopInterface)
            {
                contextMenuItems.Add(new RightClickMenuItem($"Buy 1 {item.Name}", sampleButton, BuyOneAction));
                contextMenuItems.Add(new RightClickMenuItem($"Buy 5 {item.Name}", sampleButton, BuyFiveAction));
                contextMenuItems.Add(new RightClickMenuItem($"Buy 10 {item.Name}", sampleButton, BuyTenAction));
                contextMenuItems.Add(new RightClickMenuItem($"Buy All {item.Name}", sampleButton, BuyAllAction));
            }
            else
            {
                contextMenuItems.Add(new RightClickMenuItem($"Sell 1 {item.Name}", sampleButton, SellOneAction));
                contextMenuItems.Add(new RightClickMenuItem($"Sell 5 {item.Name}", sampleButton, SellFiveAction));
                contextMenuItems.Add(new RightClickMenuItem($"Sell 10 {item.Name}", sampleButton, SellTenAction));
                contextMenuItems.Add(new RightClickMenuItem($"Sell All {item.Name}", sampleButton, SellAllAction));
            }
        }
        else
        {
            if(parentInterface is Inventory)
            {
                if (item.Equipable)
                    contextMenuItems.Add(new RightClickMenuItem($"Equip {item.Name}", sampleButton, EquipAction));
                if (gameManager.GetComponent<ConsumableDatabase>().IsEdible(item.Id)) //try to keep this as low as possible
                    contextMenuItems.Add(new RightClickMenuItem($"Consume {item.Name}", sampleButton, ConsumeAction));

                contextMenuItems.Add(new RightClickMenuItem($"Use {item.Name}", sampleButton, UseAction));
                contextMenuItems.Add(new RightClickMenuItem($"Drop {item.Name}", sampleButton, DropAction));
            }
        }
        contextMenuItems.Add(new RightClickMenuItem($"Examine {item.Name}", sampleButton, ExamineAction));
    }

    private void ConstructContextMenu(ItemSlot slot, Item item, GameInterface parentInterface)
    {
        ConstructContextMenu(slot, item, parentInterface, false);
    }

    private void ClearContextMenu()
    {
        contextMenuItems.Clear();
    }

    private void ExamineAction(Image obj)
    {
        Assets.Scripts.gameinterfaces.console.GameConsole.Instance.SendConsoleMessage(GetComponent<ItemSlot>().getItem().Examine);
        CloseMenu();
    }

    private void DropAction(Image obj)
    {
        print("dropping " + GetComponent<ItemSlot>().getItem());
        
        ItemSlot slot = GetComponent<ItemSlot>();
        gameManager.CreateGroundItem(slot.getItem(), player.transform);
        slot.GetParentContainer().Remove(slot.getItem());
        CloseMenu();
    }

    private void UseAction(Image obj)
    {
        print("using " + GetComponent<ItemSlot>().getItem());
        ItemSlot slot = GetComponent<ItemSlot>();
        slot.GetParentContainer().Remove(slot.getItem());
        CloseMenu();
    }

    private void EquipAction(Image obj)
    {
        Item item = GetComponent<ItemSlot>().getItem();
        var reqResult = item.Requirements.MeetsRequirements(player);
        if (reqResult)
        {
            player.equipment.Equip(item);
        }
        CloseMenu();
    }

    private void ValueAction(Image obj)
    {
        CloseMenu();
        ItemSlot slot = GetComponent<ItemSlot>();
        ShopInterface si = gameManager.ShopInterface;
        Shop shop = si.Shop;
        Item item = slot.getItem();
        bool isInShop = slot.ContainerDisplay is ShopInterface;

        GameConsole.Instance.SendFilteredConsoleMessage(
            $"This shop will " + (isInShop ? "sell" : "buy") + $" {item.Name} for " + (isInShop ? shop.GetShopSellPrice(item.Price) : shop.GetShopBuyPrice(item.Price)) + ".");
    }

    private void SellOneAction(Image obj) => SellX(1);
    private void SellFiveAction(Image obj) => SellX(5);
    private void SellTenAction(Image obj) => SellX(10);
    private void SellAllAction(Image obj) => SellX(int.MaxValue);

    private void SellX(int amnt)
    {
        CloseMenu();
        int amount = amnt;
        ItemSlot slot = GetComponent<ItemSlot>();
        Item item = slot.getItem();
        ShopInterface si = gameManager.ShopInterface;
        Shop shop = si.Shop;

        amount = amount > item.Amount ? item.Amount : amount;
        
        int coinsAmnt = shop.GetShopSellPrice(item.Price) * amount;

        slot.GetParentContainer().Remove(item.Id, amount);
    }

    private void BuyOneAction(Image obj) => BuyX(1);
    private void BuyFiveAction(Image obj) => BuyX(5);
    private void BuyTenAction(Image obj) => BuyX(10);
    private void BuyAllAction(Image obj) => BuyX(int.MaxValue);

    private void BuyX(int amnt)
    {
        CloseMenu();
        ItemSlot slot = GetComponent<ItemSlot>();
        int amount = amnt;
        ShopInterface si = gameManager.ShopInterface;
        Shop shop = si.Shop;
        Item item = slot.getItem();

        //check if the amount goes over the shop stock, if so set it to that value
        if (amount > item.Amount)
            amount = item.Amount;

        //now that we have the amount, check if the player can afford this.
        if (player.InventoryContainer.Contains(384))
        {
            Item playerCoins = player.InventoryContainer.GetItem(384);
            //check if the player has enough money for a singular item, if not we can just stop here
            if (playerCoins.Amount < shop.GetShopBuyPrice(item.Price))
            {
                GameConsole.Instance.SendConsoleMessage("You don't have enough money.");
                return;
            }
            //get the maximum amount purchaseable
            int canBuyAmount = (int)Math.Floor((double)(playerCoins.Amount / shop.GetShopBuyPrice(item.Price)));
            //if trying to buy more than can afford, set the amount to the max
            if (amount > canBuyAmount)
                amount = canBuyAmount;

            //set the amount the the player free inventoryslots
            if (player.InventoryContainer.GetFreeSlots() < amount)
            {
                amount = player.InventoryContainer.GetFreeSlots();
                GameConsole.Instance.SendConsoleMessage("You don't have enough inventory space.");
            }

            //remove the coins and transfer item from teh shop to the plaeyr
            if (player.InventoryContainer.Remove(384, amount * shop.GetShopBuyPrice(item.Price))) {
                shop.DepleteItem(item.Id, amount);
                player.GiveItem(item.Id, amount);
            }

        }
        GameConsole.Instance.SendConsoleMessage("You don't have any money.");
    }

    private void ConsumeAction(Image obj)
    {
        throw new NotImplementedException();
    }

    private void SetUpAction(Image obj)
    {
        throw new NotImplementedException();
    }

    private void CloseMenu()
    {
        RightClickMenu.Instance.HideContextMenu();
    }
}