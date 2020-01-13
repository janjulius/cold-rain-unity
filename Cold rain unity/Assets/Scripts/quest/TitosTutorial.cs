using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.quest
{
    public class TitosTutorial : Quest
    {
        public override Quest Initialize()
        {
            Id = 0;
            Name = "Tito's tutorial";
            Description = "Tito will tell you to meet the locals of the town.";
            Rewards = "100 coins\nA plushie of your choice\n150 Artisan experience.";
            return this;
        }

        public override void GiveRewards(Player player)
        {
            player.InventoryContainer.Add(384, 100);
            player.skills.GetSkill(SKILLS.ARTISAN).AddExp(150);
        }
    }
}
