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
    class EquipmentSlots : MonoBehaviour
    {
        protected Item HeadSlot { get; set; }
        protected Item TorsoSlot { get; set; }
        protected Item LegSlot { get; set; }
        protected Item FeetSlot { get; set; }
        protected Item AmuletSlot { get; set; }

        protected Item WeaponSlot { get; set; }
        protected Item OffHandSlot { get; set; }

        protected Item AmmoSlot { get; set; }

        public Stats GetStats()
        {
            return HeadSlot.Stats + TorsoSlot.Stats + LegSlot.Stats + FeetSlot.Stats + AmuletSlot.Stats + WeaponSlot.Stats + OffHandSlot.Stats + AmmoSlot.Stats;
        }
    }
}
