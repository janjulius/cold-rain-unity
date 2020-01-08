using Assets.Scripts.container;
using Assets.Scripts.item;
using Assets.Scripts.shops;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.gameinterfaces.shop
{
    public class ShopInterface : ContainerDisplay
    {
        public TextMeshProUGUI titleText;
        public GameObject ItemHolder;
        
        public GameObject ShopSlotPrefab;

        public Shop Shop { private set; get; }

        private List<GameObject> shopSlots = new List<GameObject>();

        public void Load(Shop shop, Player player)
        {
            Clear();
            this.Shop = shop;
            this.player = this.player ?? player;
            titleText.text = shop.Title;
            
            foreach (Item i in shop.Container.GetItems())
            {
                GameObject slot = Instantiate(ShopSlotPrefab, Vector2.zero, Quaternion.identity, ItemHolder.transform);
                ItemSlot itemSlot = slot.GetComponent<ItemSlot>();
                itemSlot.SetItem(i);
                shopSlots.Add(slot);
            }
            gameObject.SetActive(true);
            player.IsInShop = gameObject.activeSelf;
        }

        public void Close()
        {
            Clear();
            if (player != null)
                player.IsInShop = false;
            gameObject.SetActive(false);
        }

        public void Clear()
        {
            shopSlots.ForEach(s => Destroy(s.gameObject));
            shopSlots.Clear();
        }

        public override void Create(Player player)
        {
            throw new System.NotImplementedException();
        }

        public override void Refresh()
        {
            throw new System.NotImplementedException();
        }
    }
}
