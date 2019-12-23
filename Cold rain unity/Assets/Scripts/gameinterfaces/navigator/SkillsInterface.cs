using Assets.Scripts.gameinterfaces.skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.gameinterfaces.navigator
{
    public class SkillsInterface : GameInterface
    {
        public GameObject slotPrefab;
        private SkillSlot[] savedSlots;
        private Skills skills;
        
        //public void Refresh(Skills skills)
        //{
        //    this.skills = skills;
        //    Refresh();
        //}

        public override void Create(Player player)
        {
            this.player = player;
            this.skills = player.skills;

            savedSlots = new SkillSlot[skills.skills.Length];
            for (int i = 0; i < skills.skills.Length; i++)
            {
                GameObject slot = Instantiate(slotPrefab, Vector2.zero, Quaternion.identity, transform);
                savedSlots[i] = slot.GetComponent<SkillSlot>();
                savedSlots[i].SkillText.text = skills.skills[i].Name;
                //savedSlots[i].SkillImage
            }
            Refresh();
        }

        public override void Refresh()
        {
            for(int i = 0; i < savedSlots.Length; i++)
            {
                savedSlots[i].Refresh(skills.skills[i].GetLevel().ToString());
            }
        }
    }
}
