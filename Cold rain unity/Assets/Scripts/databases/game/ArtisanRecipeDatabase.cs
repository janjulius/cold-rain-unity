using Assets.Scripts.game.consumables;
using Assets.Scripts.game.consumables.consumable;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.databases.game
{
    public class ArtisanRecipeDatabase : CRDatabase
    {
        public List<ArtisanRecipe> recipeList = new List<ArtisanRecipe>();

        public override void Initiate()
        {
            base.Initiate();
        }

        public override void BuildDatabase()
        {
            items = new List<DbElement>
            {
                //green leather
                new ArtisanRecipe(177, 5, -1, 0, 133, 0, 70),
                new ArtisanRecipe(177, 8, -1, 0, 143, 0, 112),
                new ArtisanRecipe(177, 7, -1, 0, 153, 0, 98),
                new ArtisanRecipe(177, 4, -1, 0, 163, 0, 56),
                //turquoise leather
                new ArtisanRecipe(178, 5, -1, 0, 134, 0, 70),
                new ArtisanRecipe(178, 8, -1, 0, 144, 0, 112),
                new ArtisanRecipe(178, 7, -1, 0, 154, 0, 98),
                new ArtisanRecipe(178, 4, -1, 0, 164, 0, 56),
                //blue leather
                new ArtisanRecipe(179, 5, -1, 0, 135, 10, 80),
                new ArtisanRecipe(179, 8, -1, 0, 145, 10, 128),
                new ArtisanRecipe(179, 7, -1, 0, 155, 10, 112),
                new ArtisanRecipe(179, 4, -1, 0, 165, 10, 64),
                //purple leather
                new ArtisanRecipe(180, 5, -1, 0, 136, 10, 80),
                new ArtisanRecipe(180, 8, -1, 0, 146, 10, 128),
                new ArtisanRecipe(180, 7, -1, 0, 156, 10, 112),
                new ArtisanRecipe(180, 4, -1, 0, 166, 10, 64),
                //red leather
                new ArtisanRecipe(181, 5, -1, 0, 137, 20, 90),
                new ArtisanRecipe(181, 8, -1, 0, 147, 20, 144),
                new ArtisanRecipe(181, 7, -1, 0, 157, 20, 126),
                new ArtisanRecipe(181, 4, -1, 0, 167, 20, 72),
                //black leather
                new ArtisanRecipe(182, 5, -1, 0, 138, 30, 100),
                new ArtisanRecipe(182, 8, -1, 0, 148, 30, 160),
                new ArtisanRecipe(182, 7, -1, 0, 158, 30, 140),
                new ArtisanRecipe(182, 4, -1, 0, 168, 30, 80),
                //white leather
                new ArtisanRecipe(183, 5, -1, 0, 139, 40, 130),
                new ArtisanRecipe(183, 8, -1, 0, 149, 40, 220),
                new ArtisanRecipe(183, 7, -1, 0, 159, 40, 190),
                new ArtisanRecipe(183, 4, -1, 0, 169, 40, 100),
                //ruby leather 
                new ArtisanRecipe(183, 5, 407, 1, 140, 50, 150),
                new ArtisanRecipe(183, 8, 407, 1, 150, 50, 240),
                new ArtisanRecipe(183, 7, 407, 1, 160, 50, 210),
                new ArtisanRecipe(183, 4, 407, 1, 170, 50, 120),
                //emerald leather 
                new ArtisanRecipe(183, 5, 408, 1, 141, 50, 150),
                new ArtisanRecipe(183, 8, 408, 1, 151, 50, 240),
                new ArtisanRecipe(183, 7, 408, 1, 161, 50, 210),
                new ArtisanRecipe(183, 4, 408, 1, 171, 50, 120),
                //sapphire leather 
                new ArtisanRecipe(183, 5, 409, 1, 142, 50, 150),
                new ArtisanRecipe(183, 8, 409, 1, 152, 50, 240),
                new ArtisanRecipe(183, 7, 409, 1, 162, 50, 210),
                new ArtisanRecipe(183, 4, 409, 1, 172, 50, 120),
            };
            recipeList = items.Cast<ArtisanRecipe>().ToList();
        }

        public List<ArtisanRecipe> GetItems()
        {
            return recipeList;
        }
    }
}
