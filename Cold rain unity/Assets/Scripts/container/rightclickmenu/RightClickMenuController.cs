using Assets.Scripts.container;
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
    //private MainMenuManager mm;
    //private ChatManager cm;

    void Awake()
    {
        contextMenuItems = new List<RightClickMenuItem>();
        parentObject = GetComponent<ItemSlot>();
        //mm = FindObjectOfType<MainMenuManager>();

        Action<Image> use = new Action<Image>(UseAction);
        Action<Image> examine = new Action<Image>(ExamineAction);
        Action<Image> drop = new Action<Image>(DropAction);
        
        contextMenuItems.Add(new RightClickMenuItem("Use", sampleButton, use));
        contextMenuItems.Add(new RightClickMenuItem("Examine", sampleButton, examine));
        contextMenuItems.Add(new RightClickMenuItem("Drop", sampleButton, drop));

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //mm.AtopSocialLeftBar();
            print("Right click on rightclickmenucontroller");
            //print(ItemSlot.getItem());
            RightClickMenu.Instance.CreateContextMenu(contextMenuItems,
                new Vector2(parentObject.GetComponent<RectTransform>().offsetMin.x,
                parentObject.GetComponent<RectTransform>().offsetMin.y));
        }
    }

    private void ExamineAction(Image obj)
    {
        throw new NotImplementedException();
    }

    private void DropAction(Image obj)
    {
        throw new NotImplementedException();
    }

    private void UseAction(Image obj)
    {
        throw new NotImplementedException();
    }
}