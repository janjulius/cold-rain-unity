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
        public Image HeadSlot;
        public Image AmuletSlot;
        public Image TorsoSlot;
        public Image LegSlot;
        public Image FeetSlot;
        public Image WeaponSlot;
        public Image OffHandSlot;
        public Image AmmoSlot;
        
        public TextMeshProUGUI BonusText;

        public void Refresh(EquipmentSlots equipment, Stats stats)
        {
            HeadSlot.sprite = equipment.HeadSlot?.InventoryIcon;
            AmuletSlot.sprite = equipment.AmuletSlot?.InventoryIcon;
            TorsoSlot.sprite = equipment.TorsoSlot?.InventoryIcon;
            LegSlot.sprite = equipment.LegSlot?.InventoryIcon;
            FeetSlot.sprite = equipment.FeetSlot?.InventoryIcon;
            WeaponSlot.sprite = equipment.WeaponSlot?.InventoryIcon;
            OffHandSlot.sprite = equipment.OffHandSlot?.InventoryIcon;
            AmmoSlot.sprite = equipment.AmmoSlot?.InventoryIcon;

            BonusText.text = ConstructBonusText(stats);
        }

        private string ConstructBonusText(Stats stats)
        {
            return $"Attack: {stats.Attack} Defence: {stats.Defence}\nPrecision: {stats.Precision} Speed: {stats.Speed}\n Attack Speed: {stats.AttackSpeed} Crit Chance: {stats.CritChance}%";
        }

        public override void Create()
        {
            //throw new NotImplementedException();
        }

        public override void Refresh()
        {
            //throw new NotImplementedException();
        }
    }
}
