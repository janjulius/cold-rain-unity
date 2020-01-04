using Assets.Scripts.item;
using Assets.Scripts.stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.player.Equipment
{
    public class EquipmentSlots : Node
    {
        //public Item HeadSlot { get; protected set; }
        //public Item TorsoSlot { get; protected set; }
        //public Item LegSlot { get; protected set; }
        //public Item FeetSlot { get; protected set; }
        //public Item AmuletSlot { get; protected set; }
        //
        //public Item WeaponSlot { get; protected set; }
        //public Item OffHandSlot { get; protected set; }
        //
        //public Item AmmoSlot { get; protected set; }

        public Item[] Slots {
            protected set;
            get; }


        private Player player;

        public override void Initiate()
        {
            base.Initiate();
            UpdateSlots();
            player = GetComponent<Player>();
        }


        public Stats GetStats()
        {
            Stats r = new Stats();

            for(int i = 1; i < Slots.Length; i++)
            {
                if(Slots[i] != null)
                    r += Slots[i].Stats;
            }
            return r;

            //return HeadSlot.Stats + TorsoSlot.Stats + LegSlot.Stats + FeetSlot.Stats + AmuletSlot.Stats + WeaponSlot.Stats + OffHandSlot.Stats + AmmoSlot.Stats;
        }

        /// <summary>
        /// Equips an item and returns an item if it was already in the slot
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Item Equip(Item item)
        {
            EquipmentType et = item.EquipmentType;
            var slot = GetSlot(et);
            var prev = slot;
            slot = item;
            player.InventoryContainer.Remove(slot);
            SetSlot(et, slot);
            if (prev != null)
                player.InventoryContainer.Add(prev, prev.Amount);

            player.SetEquipmentAppearance(et, slot);
            
            RefreshSlots();
            return prev;
        }

        public void Unequip(EquipmentType eqSlot)
        {
            var slot = GetSlot(eqSlot);
            if (slot != null)
                player.InventoryContainer.Add(slot, slot.Amount);
            SetSlot(eqSlot, null);
            player.SetEquipmentAppearance(eqSlot, null);
            RefreshSlots();
        }

        public void Unequip(int id)
        {
            Unequip((EquipmentType)id);
        }

        private Item GetSlot(EquipmentType eqSlot)
        {
            return Slots[(int)eqSlot];
        }

        public void SetSlot(EquipmentType eqSlot, Item item)
        {
            Slots[(int)eqSlot] = item;
        }

        private void UpdateSlots()
        {
            Slots = new Item[9];
        }

        private void RefreshSlots()
        {
            player.equipment = this;
            player.RefreshEquipmentInterface(GetStats());
        }
    }
}
