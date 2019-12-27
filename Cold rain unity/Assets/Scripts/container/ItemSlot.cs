using System;
using Assets.Scripts.item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.container
{
    public class ItemSlot : Node
    {
        private Item item;
        private Container parentContainer;
        public Image image;
        public TextMeshProUGUI slotText;
        public Sprite emptyImage;

        public override void StartInitiate()
        {
            base.StartInitiate();
            parentContainer = GetComponentInParent<ContainerDisplay>().GetContainer();
        }

        public void SetItem(Item item)
        {
            this.item = item;
            LoadItem();
        }

        public Item getItem()
        {
            return item;
        }

        private void LoadItem()
        {
            if (item == null)
            {
                SetImage(emptyImage);
                SetTextActivity(false);
            }
            else
            {
                SetImage(item.InventoryIcon);
                SetTextActivity(item.Stackable);
                if (item.Stackable)
                    SetText(item.Amount.ToString());
            }
        }

        internal void Reset()
        {
            item = null;
            LoadItem();
        }

        private void SetImage(Sprite s)
        {
            image.sprite = s;
        }

        private void SetText(string text)
        {
            slotText.text = text;
        }

        public Container GetParentContainer()
        {
            return parentContainer;
        }

        private void SetText(int text) => SetText(text.ToString());

        /// <summary>
        /// Sets active state of slotText to s
        /// </summary>
        /// <param name="s"></param>
        private void SetTextActivity(bool s) =>
            slotText.gameObject.SetActive(s);
    }
}
