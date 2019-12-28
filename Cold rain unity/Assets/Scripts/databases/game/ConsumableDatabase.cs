using Assets.Scripts.game.consumables;
using Assets.Scripts.game.consumables.consumable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.databases.game
{
    public class ConsumableDatabase : CRDatabase
    {
        public override void BuildDatabase()
        {
            items = new List<DbElement>
            {
                new Food(0, 0, 0, 0, new ConsumableProperties(12, -1))
            };
        }
    }
}
