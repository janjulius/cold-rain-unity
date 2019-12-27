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

    void Awake()
    {
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
                if (i.Equipable)
                {
                    Action<Image> equip = new Action<Image>(UseAction);
                    RightClickMenuItem equipclick = new RightClickMenuItem("Equip", sampleButton, equip);
                    if (contextMenuItems[0] != equipclick)
                        contextMenuItems.Insert(0, equipclick);
                }
                print("Right click on " + i);
                RightClickMenu.Instance.CreateContextMenu(contextMenuItems,
                    eventData.position);
            }

            if (eventData.button == PointerEventData.InputButton.Left)
            {
                print("Left click on " + i);
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
        // GetComponent<ItemSlot>().SetItem(null);\

        ItemSlot slot = GetComponent<ItemSlot>();
        slot.GetParentContainer().Remove(slot.getItem());
        CloseMenu();
    }

    private void UseAction(Image obj)
    {
        print("using " + GetComponent<ItemSlot>().getItem());
        GetComponent<ItemSlot>().SetItem(null);
        CloseMenu();
    }

    private void CloseMenu()
    {
        RightClickMenu.Instance.HideContextMenu();
    }
}