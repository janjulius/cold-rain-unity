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
                //deer meats
                new Food(191, -1, 184, 280, new ConsumableProperties(10, -1)),
                new Food(192, -1, 185, 280, new ConsumableProperties(15, -1)),
                new Food(193, -1, 186, 280, new ConsumableProperties(15, -1)),
                new Food(194, -1, 187, 280, new ConsumableProperties(20, -1)),
                new Food(195, -1, 188, 280, new ConsumableProperties(20, -1)),
                new Food(196, -1, 189, 280, new ConsumableProperties(25, -1)),
                new Food(197, -1, 190, 280, new ConsumableProperties(30, -1)),
                //deer with tomato
                new Food(191, 267, 287, 293, new ConsumableProperties(15, -1)),
                new Food(192, 267, 287, 293, new ConsumableProperties(20, -1)),
                new Food(193, 267, 287, 293, new ConsumableProperties(20, -1)),
                new Food(194, 267, 287, 293, new ConsumableProperties(25, -1)),
                new Food(195, 267, 287, 293, new ConsumableProperties(25, -1)),
                new Food(196, 267, 287, 293, new ConsumableProperties(30, -1)),
                new Food(197, 267, 287, 293, new ConsumableProperties(35, -1)),
                //deer with corn
                new Food(191, 268, 288, 294, new ConsumableProperties(15, -1)),
                new Food(192, 268, 288, 294, new ConsumableProperties(20, -1)),
                new Food(193, 268, 288, 294, new ConsumableProperties(20, -1)),
                new Food(194, 268, 288, 294, new ConsumableProperties(25, -1)),
                new Food(195, 268, 288, 294, new ConsumableProperties(25, -1)),
                new Food(196, 268, 288, 294, new ConsumableProperties(30, -1)),
                new Food(197, 268, 288, 294, new ConsumableProperties(35, -1)),
                //deer with lettuce
                new Food(191, 269, 289, 295, new ConsumableProperties(15, -1)),
                new Food(192, 269, 289, 295, new ConsumableProperties(20, -1)),
                new Food(193, 269, 289, 295, new ConsumableProperties(20, -1)),
                new Food(194, 269, 289, 295, new ConsumableProperties(25, -1)),
                new Food(195, 269, 289, 295, new ConsumableProperties(25, -1)),
                new Food(196, 269, 289, 295, new ConsumableProperties(30, -1)),
                new Food(197, 269, 289, 295, new ConsumableProperties(35, -1)),
                //deer with onion
                new Food(191, 270, 290, 296, new ConsumableProperties(15, -1)),
                new Food(192, 270, 290, 296, new ConsumableProperties(20, -1)),
                new Food(193, 270, 290, 296, new ConsumableProperties(20, -1)),
                new Food(194, 270, 290, 296, new ConsumableProperties(25, -1)),
                new Food(195, 270, 290, 296, new ConsumableProperties(25, -1)),
                new Food(196, 270, 290, 296, new ConsumableProperties(30, -1)),
                new Food(197, 270, 290, 296, new ConsumableProperties(35, -1)),
                //deer with cheese
                new Food(191, 361, 291, 297, new ConsumableProperties(15, -1)),
                new Food(192, 361, 291, 297, new ConsumableProperties(20, -1)),
                new Food(193, 361, 291, 297, new ConsumableProperties(20, -1)),
                new Food(194, 361, 291, 297, new ConsumableProperties(25, -1)),
                new Food(195, 361, 291, 297, new ConsumableProperties(25, -1)),
                new Food(196, 361, 291, 297, new ConsumableProperties(30, -1)),
                new Food(197, 361, 291, 297, new ConsumableProperties(35, -1)),
                //deer with milk
                new Food(191, 275, 292, 298, new ConsumableProperties(15, -1)),
                new Food(192, 275, 292, 298, new ConsumableProperties(20, -1)),
                new Food(193, 275, 292, 298, new ConsumableProperties(20, -1)),
                new Food(194, 275, 292, 298, new ConsumableProperties(25, -1)),
                new Food(195, 275, 292, 298, new ConsumableProperties(25, -1)),
                new Food(196, 275, 292, 298, new ConsumableProperties(30, -1)),
                new Food(197, 275, 292, 298, new ConsumableProperties(35, -1)),
                //deer with goatmilk
                new Food(191, 276, 289, 298, new ConsumableProperties(15, -1)),
                new Food(192, 276, 289, 298, new ConsumableProperties(20, -1)),
                new Food(193, 276, 289, 298, new ConsumableProperties(20, -1)),
                new Food(194, 276, 289, 298, new ConsumableProperties(25, -1)),
                new Food(195, 276, 289, 298, new ConsumableProperties(25, -1)),
                new Food(196, 276, 289, 298, new ConsumableProperties(30, -1)),
                new Food(197, 276, 289, 298, new ConsumableProperties(35, -1)),

                //duck breasts
                new Food(200, -1, 198, 282, new ConsumableProperties(8, -1)),
                new Food(201, -1, 199, 282, new ConsumableProperties(5, -1)),
                //duck with tomato
                new Food(200, 267, 299, 305, new ConsumableProperties(13, -1)),
                new Food(201, 267, 299, 305, new ConsumableProperties(10, -1)),
                //duck with corn
                new Food(200, 268, 300, 306, new ConsumableProperties(13, -1)),
                new Food(201, 268, 300, 306, new ConsumableProperties(10, -1)),
                //duck with lettuce
                new Food(200, 269, 301, 307, new ConsumableProperties(13, -1)),
                new Food(201, 269, 301, 307, new ConsumableProperties(10, -1)),
                //duck with onion
                new Food(200, 270, 302, 308, new ConsumableProperties(13, -1)),
                new Food(201, 270, 302, 308, new ConsumableProperties(10, -1)),
                //duck with cheese
                new Food(200, 361, 303, 309, new ConsumableProperties(13, -1)),
                new Food(201, 361, 303, 309, new ConsumableProperties(10, -1)),
                //duck with milk
                new Food(200, 275, 304, 310, new ConsumableProperties(13, -1)),
                new Food(201, 275, 304, 310, new ConsumableProperties(10, -1)),
                //duck with goatmilk
                new Food(200, 276, 304, 310, new ConsumableProperties(13, -1)),
                new Food(201, 276, 304, 310, new ConsumableProperties(10, -1)),

                //goose breasts
                new Food(205, -1, 202, 283, new ConsumableProperties(16, -1)),
                new Food(206, -1, 203, 283, new ConsumableProperties(12, -1)),
                new Food(207, -1, 204, 283, new ConsumableProperties(8, -1)),
                //goose with tomato
                new Food(205, 267, 311, 317, new ConsumableProperties(21, -1)),
                new Food(206, 267, 311, 317, new ConsumableProperties(17, -1)),
                new Food(207, 267, 311, 317, new ConsumableProperties(13, -1)),
                //goose with corn
                new Food(205, 268, 312, 318, new ConsumableProperties(21, -1)),
                new Food(206, 268, 312, 318, new ConsumableProperties(17, -1)),
                new Food(207, 268, 312, 318, new ConsumableProperties(13, -1)),
                //goose with lettuce
                new Food(205, 269, 313, 319, new ConsumableProperties(21, -1)),
                new Food(206, 269, 313, 319, new ConsumableProperties(17, -1)),
                new Food(207, 269, 313, 319, new ConsumableProperties(13, -1)),
                //goose with onion
                new Food(205, 270, 314, 320, new ConsumableProperties(21, -1)),
                new Food(206, 270, 314, 320, new ConsumableProperties(17, -1)),
                new Food(207, 270, 314, 320, new ConsumableProperties(13, -1)),
                //goose with cheese
                new Food(205, 361, 315, 321, new ConsumableProperties(21, -1)),
                new Food(206, 361, 315, 321, new ConsumableProperties(17, -1)),
                new Food(207, 361, 315, 321, new ConsumableProperties(13, -1)),
                //goose with milk
                new Food(205, 275, 316, 322, new ConsumableProperties(21, -1)),
                new Food(206, 275, 316, 322, new ConsumableProperties(17, -1)),
                new Food(207, 275, 316, 322, new ConsumableProperties(13, -1)),
                //goose with goatmilk
                new Food(205, 276, 316, 322, new ConsumableProperties(21, -1)),
                new Food(206, 276, 316, 322, new ConsumableProperties(17, -1)),
                new Food(207, 276, 316, 322, new ConsumableProperties(13, -1)),

                //rabbit
                new Food(211, -1, 209, 284, new ConsumableProperties(8, -1)),
                new Food(212, -1, 210, 284, new ConsumableProperties(16, -1)),
                //rabbit with tomato
                new Food(211, 267, 323, 329, new ConsumableProperties(13, -1)),
                new Food(212, 267, 323, 329, new ConsumableProperties(21, -1)),
                //rabbit with corn
                new Food(211, 268, 324, 330, new ConsumableProperties(13, -1)),
                new Food(212, 268, 324, 330, new ConsumableProperties(21, -1)),
                //rabbit with lettuce
                new Food(211, 269, 325, 331, new ConsumableProperties(13, -1)),
                new Food(212, 269, 325, 331, new ConsumableProperties(21, -1)),
                //rabbit with onion
                new Food(211, 270, 326, 332, new ConsumableProperties(13, -1)),
                new Food(212, 270, 326, 332, new ConsumableProperties(21, -1)),
                //rabbit with cheese
                new Food(211, 361, 327, 333, new ConsumableProperties(13, -1)),
                new Food(212, 361, 327, 333, new ConsumableProperties(21, -1)),
                //rabbit with milk
                new Food(211, 275, 328, 334, new ConsumableProperties(13, -1)),
                new Food(212, 275, 328, 334, new ConsumableProperties(21, -1)),
                //rabbit with goatmilk
                new Food(211, 276, 328, 334, new ConsumableProperties(13, -1)),
                new Food(212, 276, 328, 334, new ConsumableProperties(21, -1)),

                //bird breast
                new Food(218, -1, 215, 285, new ConsumableProperties(11, -1)),
                new Food(219, -1, 216, 285, new ConsumableProperties(8, -1)),
                new Food(220, -1, 217, 285, new ConsumableProperties(5, -1)),
                //bird with tomato
                new Food(218, 267, 215, 285, new ConsumableProperties(11, -1)),
                new Food(219, 267, 216, 285, new ConsumableProperties(8, -1)),
                new Food(220, 267, 217, 285, new ConsumableProperties(5, -1)),
                //bird with corn
                //bird with lettuce
                //bird with onion
                //bird with cheese
                //bird with milk
                //bird with goatmilk

                //fish
                //fish with tomato
                //fish with corn
                //fish with lettuce
                //fish with onion
                //fish with cheese
                //fish with milk
                //fish with goatmilk

                //egg

                //salads
                
            };
        }
    }
}
