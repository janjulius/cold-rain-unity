using Assets.Scripts.gameinterfaces.console;
using UnityEngine;

namespace Assets.Scripts.item
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class GroundItem : Node
    {
        private Item item;
        private Player player;
        private SpriteRenderer sprRenderer;

        public void Create(Item item, Player player)
        {
            this.item = item;
            sprRenderer = GetComponent<SpriteRenderer>();
            sprRenderer.sprite = item.InventoryIcon;
            this.player = player;
        }

        private void OnMouseDown()
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 1.1f)
            {
                Console.Instance.SendFilteredConsoleMessage("You need to get closer.");
                Console.Instance.SendDevMessage(Vector2.Distance(player.transform.position, transform.position).ToString());
            }
            else
            {
                if (player.InventoryContainer.HasFreeSlots())
                {
                    Console.Instance.SendFilteredConsoleMessage("You have no room to carry this item.");
                }
                else
                {
                    player.InventoryContainer.Add(item, item.Amount);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
