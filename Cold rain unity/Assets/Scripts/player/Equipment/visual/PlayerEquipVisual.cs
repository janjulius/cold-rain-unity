using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.player.Equipment.visual
{
    public class PlayerEquipVisual : Node
    {
        [Header("0 = Front, 1 = FACE RIGHT, 2 = Back, 3 = FACE LEFT")]
        public Sprite[] EquipmentSprites = new Sprite[4];

        [Header("This is for facing front (the normal stance)")]
        public Vector2 BaseLocation;

        [Header("0 = FACE RIGHT, 1 = Back, 2 = FACE LEFT")]
        public Vector2[] DisplaceLocation;

        [HideInInspector]
        public SpriteRenderer spriteRenderer;
        
        public override void Initiate()
        {
            base.Initiate();
            print("initiated: " + name);
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void UpdateSprite(FaceDirection dir)
        {
            spriteRenderer.sprite = EquipmentSprites?[(int)dir];
            if (dir == FaceDirection.DOWN)
                transform.localPosition = BaseLocation;
            else
                if (DisplaceLocation.Length > 0)
                    transform.localPosition = DisplaceLocation[((int)dir) - 1];
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void SetLayerOrder(int position)
        {
            spriteRenderer.sortingOrder = position;
        }

        public int GetLayerOrder()
        {
            return spriteRenderer.sortingOrder;
        }
    }
}
