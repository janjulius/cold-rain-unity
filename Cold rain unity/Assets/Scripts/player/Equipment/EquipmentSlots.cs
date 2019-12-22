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
    public class EquipmentSlots : MonoBehaviour
    {
        public Item HeadSlot { get; protected set; }
        public Item TorsoSlot { get; protected set; }
        public Item LegSlot { get; protected set; }
        public Item FeetSlot { get; protected set; }
        public Item AmuletSlot { get; protected set; }
        
        public Item WeaponSlot { get; protected set; }
        public Item OffHandSlot { get; protected set; }
        
        public Item AmmoSlot { get; protected set; }

        public Stats GetStats()
        {
            return HeadSlot.Stats + TorsoSlot.Stats + LegSlot.Stats + FeetSlot.Stats + AmuletSlot.Stats + WeaponSlot.Stats + OffHandSlot.Stats + AmmoSlot.Stats;
        }
    }
}
