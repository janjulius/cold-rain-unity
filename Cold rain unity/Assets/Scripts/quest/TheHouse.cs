using Assets.Scripts.managers;
using Assets.Scripts.skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.quest
{
    public class TehHouse : Quest
    {
        public override Quest Initialize()
        {
            Id = 1;
            Name = "The house";
            Description = "Gunther the mayor will give you the house if you can find Santa's sleigh. Apparently Tita, Tito and Titus are hobos that might have answers.";
            Rewards = "Ownership of the house southeast of town.";
            return this;
        }

        public override void GiveRewards(Player player)
        {
            WorldStateManager.Instance.SetState(StateConstants.HOUSE_STATE, 1);
        }
    }
}
