using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.gameinterfaces.skills
{
    public class SkillSlot : Node
    {
        public Image SkillImage;
        public TextMeshProUGUI SkillText;
        public TextMeshProUGUI LevelText;

        public void Refresh(string levelText)
        {
            LevelText.text = levelText;
        }
    }
}
