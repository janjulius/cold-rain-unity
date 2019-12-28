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
                case 191: //green deer 
                case 201: //tufted duck 
                case 211: //rabbit
                case 220: //corncrake
                case 381: //red drum
                    return 1;
                case 192: //turquoise deer 
                case 200: //mallard duck 
                case 207: //pinkfoot goose 
                case 219: //woodpigeon
                    return 2;
                case 193: //blue deer 
                case 206: //greylag goose 
                case 212: //hare
                case 218: //pheasant
                case 376: //walleye
                case 377: //muskellunge
                case 382: //salmon
                    return 3;
                case 194: //purple deer 
                case 205: //canada goose 
                    return 4;
                case 195: //red deer
                case 375: //catfish
                case 378: //tuna
                case 379: //tarpon
                case 380: //marlin
                    return 5;
                case 196: //black deer 
                    return 6;
                case 197: //white deer 
                    return 7;
            }
            return 0;
        }
    }
}
