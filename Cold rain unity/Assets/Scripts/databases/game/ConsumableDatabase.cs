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
                new Food(218, 267, 385, 391, new ConsumableProperties(11, -1)),
                new Food(219, 267, 385, 391, new ConsumableProperties(8, -1)),
                new Food(220, 267, 385, 391, new ConsumableProperties(5, -1)),
                //bird with corn
                new Food(218, 268, 386, 392, new ConsumableProperties(11, -1)),
                new Food(219, 268, 386, 392, new ConsumableProperties(8, -1)),
                new Food(220, 268, 386, 392, new ConsumableProperties(5, -1)),
                //bird with lettuce
                new Food(218, 269, 387, 393, new ConsumableProperties(11, -1)),
                new Food(219, 269, 387, 393, new ConsumableProperties(8, -1)),
                new Food(220, 269, 387, 393, new ConsumableProperties(5, -1)),
                //bird with onion
                new Food(218, 270, 388, 394, new ConsumableProperties(11, -1)),
                new Food(219, 270, 388, 394, new ConsumableProperties(8, -1)),
                new Food(220, 270, 388, 394, new ConsumableProperties(5, -1)),
                //bird with cheese
                new Food(218, 361, 389, 395, new ConsumableProperties(11, -1)),
                new Food(219, 361, 389, 395, new ConsumableProperties(8, -1)),
                new Food(220, 361, 389, 395, new ConsumableProperties(5, -1)),
                //bird with milk
                new Food(218, 275, 390, 396, new ConsumableProperties(11, -1)),
                new Food(219, 275, 390, 396, new ConsumableProperties(8, -1)),
                new Food(220, 275, 390, 396, new ConsumableProperties(5, -1)),
                //bird with goatmilk
                new Food(218, 276, 390, 396, new ConsumableProperties(11, -1)),
                new Food(219, 276, 390, 396, new ConsumableProperties(8, -1)),
                new Food(220, 276, 390, 396, new ConsumableProperties(5, -1)),

                //fish
                new Food(373, -1, 249, 281, new ConsumableProperties(10, -1)),
                new Food(374, -1, 250, 281, new ConsumableProperties(10, -1)),
                new Food(375, -1, 251, 281, new ConsumableProperties(15, -1)),
                new Food(376, -1, 252, 281, new ConsumableProperties(10, -1)),
                new Food(377, -1, 253, 281, new ConsumableProperties(10, -1)),
                new Food(378, -1, 254, 281, new ConsumableProperties(15, -1)),
                new Food(379, -1, 255, 281, new ConsumableProperties(15, -1)),
                new Food(380, -1, 256, 281, new ConsumableProperties(15, -1)),
                new Food(381, -1, 257, 281, new ConsumableProperties(5, -1)),
                new Food(382, -1, 258, 281, new ConsumableProperties(10, -1)),
                //fish with tomato
                new Food(373, 267, 335, 341, new ConsumableProperties(15, -1)),
                new Food(374, 267, 335, 341, new ConsumableProperties(15, -1)),
                new Food(375, 267, 335, 341, new ConsumableProperties(20, -1)),
                new Food(376, 267, 335, 341, new ConsumableProperties(15, -1)),
                new Food(377, 267, 335, 341, new ConsumableProperties(15, -1)),
                new Food(378, 267, 335, 341, new ConsumableProperties(20, -1)),
                new Food(379, 267, 335, 341, new ConsumableProperties(20, -1)),
                new Food(380, 267, 335, 341, new ConsumableProperties(20, -1)),
                new Food(381, 267, 335, 341, new ConsumableProperties(10, -1)),
                new Food(382, 267, 335, 341, new ConsumableProperties(15, -1)),
                //fish with corn
                new Food(373, 268, 336, 342, new ConsumableProperties(15, -1)),
                new Food(374, 268, 336, 342, new ConsumableProperties(15, -1)),
                new Food(375, 268, 336, 342, new ConsumableProperties(20, -1)),
                new Food(376, 268, 336, 342, new ConsumableProperties(15, -1)),
                new Food(377, 268, 336, 342, new ConsumableProperties(15, -1)),
                new Food(378, 268, 336, 342, new ConsumableProperties(20, -1)),
                new Food(379, 268, 336, 342, new ConsumableProperties(20, -1)),
                new Food(380, 268, 336, 342, new ConsumableProperties(20, -1)),
                new Food(381, 268, 336, 342, new ConsumableProperties(10, -1)),
                new Food(382, 268, 336, 342, new ConsumableProperties(15, -1)),
                //fish with lettuce
                new Food(373, 269, 337, 343, new ConsumableProperties(15, -1)),
                new Food(374, 269, 337, 343, new ConsumableProperties(15, -1)),
                new Food(375, 269, 337, 343, new ConsumableProperties(20, -1)),
                new Food(376, 269, 337, 343, new ConsumableProperties(15, -1)),
                new Food(377, 269, 337, 343, new ConsumableProperties(15, -1)),
                new Food(378, 269, 337, 343, new ConsumableProperties(20, -1)),
                new Food(379, 269, 337, 343, new ConsumableProperties(20, -1)),
                new Food(380, 269, 337, 343, new ConsumableProperties(20, -1)),
                new Food(381, 269, 337, 343, new ConsumableProperties(10, -1)),
                new Food(382, 269, 337, 343, new ConsumableProperties(15, -1)),
                //fish with onion
                new Food(373, 270, 338, 344, new ConsumableProperties(15, -1)),
                new Food(374, 270, 338, 344, new ConsumableProperties(15, -1)),
                new Food(375, 270, 338, 344, new ConsumableProperties(20, -1)),
                new Food(376, 270, 338, 344, new ConsumableProperties(15, -1)),
                new Food(377, 270, 338, 344, new ConsumableProperties(15, -1)),
                new Food(378, 270, 338, 344, new ConsumableProperties(20, -1)),
                new Food(379, 270, 338, 344, new ConsumableProperties(20, -1)),
                new Food(380, 270, 338, 344, new ConsumableProperties(20, -1)),
                new Food(381, 270, 338, 344, new ConsumableProperties(10, -1)),
                new Food(382, 270, 338, 344, new ConsumableProperties(15, -1)),
                //fish with cheese
                new Food(373, 361, 339, 345, new ConsumableProperties(15, -1)),
                new Food(374, 361, 339, 345, new ConsumableProperties(15, -1)),
                new Food(375, 361, 339, 345, new ConsumableProperties(20, -1)),
                new Food(376, 361, 339, 345, new ConsumableProperties(15, -1)),
                new Food(377, 361, 339, 345, new ConsumableProperties(15, -1)),
                new Food(378, 361, 339, 345, new ConsumableProperties(20, -1)),
                new Food(379, 361, 339, 345, new ConsumableProperties(20, -1)),
                new Food(380, 361, 339, 345, new ConsumableProperties(20, -1)),
                new Food(381, 361, 339, 345, new ConsumableProperties(10, -1)),
                new Food(382, 361, 339, 345, new ConsumableProperties(15, -1)),
                //fish with milk
                new Food(373, 275, 340, 346, new ConsumableProperties(15, -1)),
                new Food(374, 275, 340, 346, new ConsumableProperties(15, -1)),
                new Food(375, 275, 340, 346, new ConsumableProperties(20, -1)),
                new Food(376, 275, 340, 346, new ConsumableProperties(15, -1)),
                new Food(377, 275, 340, 346, new ConsumableProperties(15, -1)),
                new Food(378, 275, 340, 346, new ConsumableProperties(20, -1)),
                new Food(379, 275, 340, 346, new ConsumableProperties(20, -1)),
                new Food(380, 275, 340, 346, new ConsumableProperties(20, -1)),
                new Food(381, 275, 340, 346, new ConsumableProperties(10, -1)),
                new Food(382, 275, 340, 346, new ConsumableProperties(15, -1)),
                //fish with goatmilk
                new Food(373, 276, 340, 346, new ConsumableProperties(15, -1)),
                new Food(374, 276, 340, 346, new ConsumableProperties(15, -1)),
                new Food(375, 276, 340, 346, new ConsumableProperties(20, -1)),
                new Food(376, 276, 340, 346, new ConsumableProperties(15, -1)),
                new Food(377, 276, 340, 346, new ConsumableProperties(15, -1)),
                new Food(378, 276, 340, 346, new ConsumableProperties(20, -1)),
                new Food(379, 276, 340, 346, new ConsumableProperties(20, -1)),
                new Food(380, 276, 340, 346, new ConsumableProperties(20, -1)),
                new Food(381, 276, 340, 346, new ConsumableProperties(10, -1)),
                new Food(382, 276, 340, 346, new ConsumableProperties(15, -1)),

                //egg
                new Food(277, -1, 397, 286, new ConsumableProperties(10, -1)),
                new Food(277, 267, 347, 353, new ConsumableProperties(15, -1)),
                new Food(277, 268, 348, 354, new ConsumableProperties(15, -1)),
                new Food(277, 269, 349, 355, new ConsumableProperties(15, -1)),
                new Food(277, 270, 350, 356, new ConsumableProperties(15, -1)),
                new Food(277, 361, 351, 357, new ConsumableProperties(15, -1)),
                new Food(277, 275, 352, 358, new ConsumableProperties(15, -1)),
                new Food(277, 276, 352, 358, new ConsumableProperties(15, -1)),

                //salads
                new Food(277, 267, 359, -1, new ConsumableProperties(10, -1)),
                new Food(277, 268, 359, -1, new ConsumableProperties(10, -1)),
                new Food(277, 269, 359, -1, new ConsumableProperties(10, -1)),
                new Food(277, 270, 359, -1, new ConsumableProperties(10, -1)),

                new Food(361, 267, 360, -1, new ConsumableProperties(10, -1)),
                new Food(361, 268, 360, -1, new ConsumableProperties(10, -1)),
                new Food(361, 269, 360, -1, new ConsumableProperties(10, -1)),
                new Food(361, 270, 360, -1, new ConsumableProperties(10, -1)),

                new Food(362, 267, 360, -1, new ConsumableProperties(10, -1)),
                new Food(362, 268, 360, -1, new ConsumableProperties(10, -1)),
                new Food(362, 269, 360, -1, new ConsumableProperties(10, -1)),
                new Food(362, 270, 360, -1, new ConsumableProperties(10, -1)),
            };
        }

        public bool IsEdible(int id)
        => items.Cast<Food>().ToList().Where(c => c.addedId == id).First() != null;
    }
}
