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
        public ContainerDisplay ContainerDisplay { private set; get; }

        public override void StartInitiate()
        {
            base.StartInitiate();
            ContainerDisplay = GetComponentInParent<ContainerDisplay>();
            if(ContainerDisplay != null)
                parentContainer = ContainerDisplay.GetContainer();
            if (slotText == null)
                slotText = GetComponentInChildren<TextMeshProUGUI>();
            if (image == null)
                image = GetComponent<Image>();
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
                SetImage(item.InventoryIcon ?? emptyImage);
                SetTextActivity(item.Amount > 1);
                if (item.Amount > 1)
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
