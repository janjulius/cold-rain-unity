using Assets.Scripts.container;
using Assets.Scripts.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.player.Equipment
{
    class Equipmentslot : MonoBehaviour, IPointerClickHandler
    {
        private ItemSlot parentObject;
        void Awake()
        {
            parentObject = GetComponent<ItemSlot>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Item i = GetComponent<ItemSlot>().getItem();
                print("Left click on " + i);

                if (i != null)
                {
                    print("taking off equipment");
                }
                else
                {
                    print("there's nothing in this slot.");
                }
            }
        }
    }
}
