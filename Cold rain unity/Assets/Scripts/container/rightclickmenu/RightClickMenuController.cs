using Assets.Scripts.container;
using Assets.Scripts.item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightClickMenuController : MonoBehaviour, IPointerClickHandler
{
    public Button sampleButton;
    private List<RightClickMenuItem> contextMenuItems;
    private ItemSlot parentObject;
    private Player player;

    void Awake()
    {
        player = Camera.main.GetComponent<GameManager>().player;
        contextMenuItems = new List<RightClickMenuItem>();
        parentObject = GetComponent<ItemSlot>();

        Action<Image> use = new Action<Image>(UseAction);
        Action<Image> examine = new Action<Image>(ExamineAction);
        Action<Image> drop = new Action<Image>(DropAction);

        contextMenuItems.Add(new RightClickMenuItem("Use", sampleButton, use));
        contextMenuItems.Add(new RightClickMenuItem("Examine", sampleButton, examine));
        contextMenuItems.Add(new RightClickMenuItem("Drop", sampleButton, drop));

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Item i = GetComponent<ItemSlot>().getItem();
        if (i != null)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                print("Right click on " + i);
                if (i.Equipable)
                {
                    Action<Image> equip = new Action<Image>(EquipAction);
                    RightClickMenuItem equipitem = new RightClickMenuItem("Equip", sampleButton, equip);

                    if (contextMenuItems.Count <4)
                    {
                        contextMenuItems.Add(equipitem);
                    }
                }
                //else if (i.Consumable)
                //{
                //    Action<Image> eat = new Action<Image>(ConsumeAction);
                //    RightClickMenuItem eatitem = new RightClickMenuItem("Eat", sampleButton, eat);

                //    if (contextMenuItems.Count < 4)
                //    {
                //        contextMenuItems.Add(eatitem);
                //    }
                //}
                
                RightClickMenu.Instance.CreateContextMenu(contextMenuItems,
                    eventData.position);
            }

            if (eventData.button == PointerEventData.InputButton.Left)
            {
                print("Left click on " + i);
                if (i.Equipable)
                    EquipAction(GetComponent<ItemSlot>().image);
                //else if(i.Consumable)
                //    ConsumeAction(GetComponent<ItemSlot>().image);
                else
                    UseAction(GetComponent<ItemSlot>().image);
            }
        }
    }

    private void ExamineAction(Image obj)
    {
        print(GetComponent<ItemSlot>().getItem().Examine);
        CloseMenu();
    }

    private void DropAction(Image obj)
    {
        print("dropping " + GetComponent<ItemSlot>().getItem());
        // GetComponent<ItemSlot>().SetItem(null);

        ItemSlot slot = GetComponent<ItemSlot>();
        slot.GetParentContainer().Remove(slot.getItem());
        CloseMenu();
    }

    private void UseAction(Image obj)
    {
        print("using " + GetComponent<ItemSlot>().getItem());
        //GetComponent<ItemSlot>().SetItem(null);
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
            //equip
            player.equipment.Equip(item);
        }

        //Item item = GetComponent<ItemSlot>().getItem();
        //if (item.Requirements)
        //EquipmentType equiptype = .EquipmentType;
        //
        //print(equiptype);
    }

    private void ConsumeAction(Image obj)
    {
        throw new NotImplementedException();
    }

    private void CloseMenu()
    {
        RightClickMenu.Instance.HideContextMenu();
    }
}