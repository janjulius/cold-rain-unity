using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.game.consumables.consumable
{
    public class Food : Consumable
    {
        int rawId;
        int addedId;
        int cookedId;
        int burntId;
        ConsumableProperties properties;

        public Food(int rawId, int addedId, int cookedId, int burntId, ConsumableProperties properties)
        {
            this.rawId = rawId;
            this.addedId = addedId;
            this.cookedId = cookedId;
            this.burntId = burntId;
            this.properties = properties;
        }

        public int GetCharges()
        {
            switch (rawId)
            {
                case 191: //green deer meat
                case 205: //canada goose breast
                    return 1;
                case 192: //torquoise deer meat
                    return 2;
                case 193: //blue deer meat
                    return 3;
                case 194: // purple deer meat
                    return 4;
                case 195: // red deer meat
                    return 5;
                case 196: //black deer meat
                    return 6;
                case 197: //white deer meat
                    return 7;
            }
            return 0;
        }
    }
}
