using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.player.Equipment;
using Assets.Scripts.stats;

namespace Assets.Scripts.gameinterfaces.navigator
{
    public class EquipmentInterface : GameInterface
    {
        public Button HeadSlot;
        public Button AmuletSlot;
        public Button TorsoSlot;
        public Button LegSlot;
        public Button FeetSlot;
        public Button WeaponSlot;
        public Button OffHandSlot;
        public Button AmmoSlot;
        
        public TextMeshProUGUI BonusText;

        private EquipmentSlots equipment;
        private Stats stats;

        public void Refresh(EquipmentSlots slots, Stats stats)
        {
            equipment = slots;
            this.stats = stats;
            Refresh();
        }

        public override void Refresh()
        {
            HeadSlot.image.sprite = equipment.Slots[(int)EquipmentType.HEAD]?.InventoryIcon;
            AmuletSlot.image.sprite = equipment.Slots[(int)EquipmentType.AMULET]?.InventoryIcon;
            TorsoSlot.image.sprite = equipment.Slots[(int)EquipmentType.TORSO]?.InventoryIcon;
            LegSlot.image.sprite = equipment.Slots[(int)EquipmentType.LEGS]?.InventoryIcon;
            FeetSlot.image.sprite = equipment.Slots[(int)EquipmentType.FEET]?.InventoryIcon;
            WeaponSlot.image.sprite = equipment.Slots[(int)EquipmentType.MAINHAND]?.InventoryIcon;
            OffHandSlot.image.sprite = equipment.Slots[(int)EquipmentType.OFFHAND]?.InventoryIcon;
            AmmoSlot.image.sprite = equipment.Slots[(int)EquipmentType.AMMO]?.InventoryIcon;

            BonusText.text = ConstructBonusText(stats);
        }

        private string ConstructBonusText(Stats stats)
        {
            return $"Attack: {stats.Attack} Defence: {stats.Defence}\nPrecision: {stats.Precision} Speed: {stats.Speed}\n Attack Speed: {stats.AttackSpeed} Crit Chance: {stats.CritChance}%";
        }

        public override void Create(Player player)
        {
            this.player = player;
            equipment = player.equipment;
            stats = player.stats;
        }
    }
}
