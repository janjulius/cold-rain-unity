using Assets.Scripts.gameinterfaces.skills;
using Assets.Scripts.skills;
using UnityEngine;

namespace Assets.Scripts.gameinterfaces.navigator
{
    public class SkillsInterface : GameInterface
    {
        public GameObject slotPrefab;
        private SkillSlot[] savedSlots;
        private Skills skills;
        public GameObject InformationPanel;

        //public void Refresh(Skills skills)
        //{
        //    this.skills = skills;
        //    Refresh();
        //}

        public override void StartInitiate()
        {
            base.StartInitiate();
            Refresh();
        }

        public override void Create(Player player)
        {
            this.player = player;
            this.skills = player.skills;

            savedSlots = new SkillSlot[skills.skills.Length];
            for (int i = 0; i < skills.skills.Length; i++)
            {
                GameObject slot = Instantiate(slotPrefab, Vector2.zero, Quaternion.identity, transform);
                savedSlots[i] = slot.GetComponent<SkillSlot>();
                savedSlots[i].Load(skills.GetSkill(i), InformationPanel);
                savedSlots[i].SkillImage.sprite = Resources.Load<Sprite>($"Skills/{i}");
            }
            Refresh();
        }

        public override void Refresh()
        {
            for (int i = 0; i < savedSlots.Length; i++)
            {
                savedSlots[i].Refresh();
            }
        }

        private void OnEnable()
        {
            if (skills != null)
            {
                foreach (Skill s in skills?.skills)
                {
                    s.LevelUp += Refresh;
                }
            }
        }

        private void OnDisable()
        {
            if (skills != null)
            {
                foreach (Skill s in skills?.skills)
                {
                    s.LevelUp -= Refresh;
                }
            }
        }
    }
}
