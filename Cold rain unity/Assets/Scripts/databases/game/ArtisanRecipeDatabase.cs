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
            CallSelf = false;
            base.Initiate();
        }

        public override void BuildDatabase()
        {
            items = new List<DbElement>
            {
                //green leather
                new ArtisanRecipe(177, 5, -1, 0, 133),
                new ArtisanRecipe(177, 8, -1, 0, 143),
                new ArtisanRecipe(177, 7, -1, 0, 153),
                new ArtisanRecipe(177, 4, -1, 0, 163),
                //turquoise leather
                new ArtisanRecipe(178, 5, -1, 0, 134),
                new ArtisanRecipe(178, 8, -1, 0, 144),
                new ArtisanRecipe(178, 7, -1, 0, 154),
                new ArtisanRecipe(178, 4, -1, 0, 164),
                //blue leather
                new ArtisanRecipe(179, 5, -1, 0, 135),
                new ArtisanRecipe(179, 8, -1, 0, 145),
                new ArtisanRecipe(179, 7, -1, 0, 155),
                new ArtisanRecipe(179, 4, -1, 0, 165),
                //purple leather
                new ArtisanRecipe(180, 5, -1, 0, 136),
                new ArtisanRecipe(180, 8, -1, 0, 146),
                new ArtisanRecipe(180, 7, -1, 0, 156),
                new ArtisanRecipe(180, 4, -1, 0, 166),
                //red leather
                new ArtisanRecipe(181, 5, -1, 0, 137),
                new ArtisanRecipe(181, 8, -1, 0, 147),
                new ArtisanRecipe(181, 7, -1, 0, 157),
                new ArtisanRecipe(181, 4, -1, 0, 167),
                //black leather
                new ArtisanRecipe(182, 5, -1, 0, 138),
                new ArtisanRecipe(182, 8, -1, 0, 148),
                new ArtisanRecipe(182, 7, -1, 0, 158),
                new ArtisanRecipe(182, 4, -1, 0, 168),
                //white leather
                new ArtisanRecipe(183, 5, -1, 0, 139),
                new ArtisanRecipe(183, 8, -1, 0, 149),
                new ArtisanRecipe(183, 7, -1, 0, 159),
                new ArtisanRecipe(183, 4, -1, 0, 169),
                //ruby leather 
                new ArtisanRecipe(183, 5, 407, 1, 140),
                new ArtisanRecipe(183, 8, 407, 1, 150),
                new ArtisanRecipe(183, 7, 407, 1, 160),
                new ArtisanRecipe(183, 4, 407, 1, 170),
                //emerald leather 
                new ArtisanRecipe(183, 5, 408, 1, 141),
                new ArtisanRecipe(183, 8, 408, 1, 151),
                new ArtisanRecipe(183, 7, 408, 1, 161),
                new ArtisanRecipe(183, 4, 408, 1, 171),
                //sapphire leather 
                new ArtisanRecipe(183, 5, 409, 1, 142),
                new ArtisanRecipe(183, 8, 409, 1, 152),
                new ArtisanRecipe(183, 7, 409, 1, 162),
                new ArtisanRecipe(183, 4, 409, 1, 172),
            };
            recipeList = items.Cast<ArtisanRecipe>().ToList();
        }

        public List<ArtisanRecipe> GetItems()
        {
            return recipeList;
        }
    }
}
