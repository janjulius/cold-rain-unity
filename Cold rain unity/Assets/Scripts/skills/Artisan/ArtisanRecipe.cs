using Assets.Scripts.databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.game.consumables.consumable
{
    public class ArtisanRecipe : DbElement
    {
        public int materialId { private set; get; }
        public int materialAmount { private set; get; }
        public int materialId2 { private set; get; }
        public int materialAmount2 { private set; get; }
        public int level { private set; get; }
        public int experience { private set; get; }
        public int resultId { private set; get; }
        
        public ArtisanRecipe(int materialId, int materialAmount, int materialId2, int materialAmount2, int level, int experience, int resultId)
        {
            this.materialId = materialId;
            this.materialAmount = materialAmount;
            this.materialId2 = materialId2;
            this.materialAmount2 = materialAmount2;
            this.level = level;
            this.experience = experience;
            this.resultId = resultId;
        }
    }
}
