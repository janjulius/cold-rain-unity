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
            Description = "Go and fetch a package for Tito, it can't be that hard, right?.";
            Rewards = "100 coins\nA plushie of your choice\n150 Artisan experience.";
            return this;
        }

        public override void GiveRewards(Player player)
        {
            player.InventoryContainer.Add(384, 100);
            player.InventoryContainer.Add(0, 1);
            player.InventoryContainer.Add(1, 1);
            player.InventoryContainer.Add(2, 1);
            player.InventoryContainer.Add(3, 1);
            player.skills.GetSkill(SKILLS.ARTISAN).AddExp(150);
        }
    }
}
