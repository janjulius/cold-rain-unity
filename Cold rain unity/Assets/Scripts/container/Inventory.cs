using Assets.Scripts.container;
using Assets.Scripts.contants;
using Assets.Scripts.item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ContainerDisplay
{
    public GameObject SlotPrefab;

    private ItemSlot[] Slots = new ItemSlot[Constants.INVENTORY_SIZE];
    
    public override void Create(Player player)
    {
        base.Create(player);
        myContainer = player.InventoryContainer;
        for(int i = 0; i < Slots.Length; i++)
        {
            GameObject slot = Instantiate(SlotPrefab, Vector2.zero, Quaternion.identity, transform);
            Slots[i] = slot.GetComponent<ItemSlot>();
        }
    }

    public ItemSlot[] getSlots()
    {
        return Slots;
    }

    public override void Refresh(Container container)
    {
        base.Refresh(container);
        Item[] containerItems = container.GetItems();
        for(int i = 0; i < Slots.Length; i++)
        {
            if(containerItems[i] != null)
            {
                Slots[i].SetItem(containerItems[i]);
            } else
            {
                Slots[i].Reset();
            }
        }

    }
}

