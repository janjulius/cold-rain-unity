using Assets.Scripts.item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.container
{
    public class ItemSlot : MonoBehaviour
    {
        private Item item;
        public Image image;
        public TextMeshProUGUI slotText;
        
        public void SetItem(Item item)
        {
            this.item = item;
            LoadItem();
        }

        private void LoadItem()
        {
            SetImage(item.InventoryIcon);
            SetTextActivity(item.Stackable);
            if (item.Stackable)
                SetText(item.Amount.ToString());
        }

        private void SetImage(Sprite s)
        {
            image.sprite = s;
        }

        private void SetText(string text)
        {
            slotText.text = text;
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
