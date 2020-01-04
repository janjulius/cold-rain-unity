using Assets.Scripts.gameinterfaces.console;
using System.Collections.Generic;

namespace Assets.Scripts.skills
{
    public class SkillRequirement
    {
        private Dictionary<int, int> requirements = new Dictionary<int, int>();

        public SkillRequirement()
        {

        }

        public SkillRequirement(int skillId, int levelRequirement)
        {
            Require(skillId, levelRequirement);
        }

        public void Require(int skillId, int levelRequirement)
        {
            requirements.Add(skillId, levelRequirement);
        }

        /// <summary>
        /// Compares skills with given skills and returns true if all skills are higher
        /// </summary>
        /// <param name="skills"></param>
        /// <returns>Skill that is not met else null</returns>
        public bool MeetsRequirements(Player player)
        {
            return MeetsRequirements(player.skills);
        }

        /// <summary>
        /// Compares skills with given skills and returns true if all skills are higher
        /// </summary>
        /// <param name="skills"></param>
        /// <returns>Skill that is not met else null</returns>
        public bool MeetsRequirements(Skills fSkills)
        {
            foreach(KeyValuePair<int, int> entry in requirements)
            {
                if(fSkills.GetSkill(entry.Key).GetLevel() < entry.Value)
                {
                    Console.Instance.SendFilteredConsoleMessage($"You don't meet the requirements to do this, you need a {fSkills.GetSkill(entry.Key).Name} level of at least {entry.Value}.");
                    return false;
                }
            }
            return true;
        }
    }
}
