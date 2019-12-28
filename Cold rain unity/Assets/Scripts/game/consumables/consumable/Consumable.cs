using Assets.Scripts.databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.game.consumables.consumable
{
    public class Consumable : DbElement
    {
        Consumable consumable;

        public Consumable()
        {
        }

        public Consumable(Consumable consumable)
        {
            this.consumable = consumable;
        }
    }
}
