using Assets.Scripts.container;
using Assets.Scripts.databases.game;
using Assets.Scripts.gameinterfaces.shop;
using Assets.Scripts.item;
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
                else if (gameManager.GetComponent<ConsumableDatabase>().IsEdible(item.Id)) //try to keep this as low as possible
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
        Item item = GetComponent<ItemSlot>().getItem();
    }

    private void SellOneAction(Image obj) => SellX(1);
    private void SellFiveAction(Image obj) => SellX(5);
    private void SellTenAction(Image obj) => SellX(10);
    private void SellAllAction(Image obj) => SellX(int.MaxValue);

    private void SellX(int amnt)
    {

    }

    private void BuyOneAction(Image obj) => BuyX(1);
    private void BuyFiveAction(Image obj) => BuyX(5);
    private void BuyTenAction(Image obj) => BuyX(10);
    private void BuyAllAction(Image obj) => BuyX(int.MaxValue);

    private void BuyX(int amnt)
    {

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