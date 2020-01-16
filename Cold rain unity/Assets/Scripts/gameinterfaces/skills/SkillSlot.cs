using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Assets.Scripts.skills;
using Assets.Scripts.math;

namespace Assets.Scripts.gameinterfaces.skills
{
    public class SkillSlot : Node
    {
        public Image SkillImage;
        public TextMeshProUGUI SkillText;
        public TextMeshProUGUI LevelText;
        private GameObject informationPanel;

        private Skill skill;

        public void Load(Skill skill, GameObject informationPanel)
        {
            this.skill = skill;
            this.informationPanel = informationPanel;
        }

        public void MouseEnter()
        {
            informationPanel.SetActive(true);
            var rect = informationPanel.GetComponent<RectTransform>();
            informationPanel.transform.position = transform.position - new Vector3(-(rect.sizeDelta.x / 2), rect.sizeDelta.y / 2 + GetComponent<RectTransform>().sizeDelta.y, 0);
            TextMeshProUGUI txt = informationPanel.GetComponentInChildren<TextMeshProUGUI>();
            txt.text = $"Current Exp: {skill.GetExp()}\nNext level: {ProgressCalculator.GetExperienceByLevel(skill.GetLevel() + 1) - skill.GetExp()}";
        }

        public void MouseExit()
        {
            informationPanel.SetActive(false);
        }

        public void Refresh()
        {
            SkillText.text = skill.Name;
            LevelText.text = skill.GetLevel().ToString();
        }
    }
}
