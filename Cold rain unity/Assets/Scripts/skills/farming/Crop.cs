using Assets.Scripts.databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.skills.farming
{
    public class Crop : DbElement
    {
        public int SeedId { private set; get; }
        public int ResultId { private set; get; }
        public int TakesTime { private set; get; }
        public int Experience { private set; get; }
        public int Level { private set; get; }
        public int MaxYield { private set; get; }
        public Sprite[] StageSprites { private set; get; }

        public Crop(int id, string name, int seedId, int resultId, int takesTime, int experience, int level, int maxYield)
        {
            this.Id = id;
            this.Name = name;
            SeedId = seedId;
            ResultId = resultId;
            TakesTime = takesTime;
            Experience = experience;
            Level = level;
            MaxYield = maxYield;
        }

        public void SetSprites(Sprite[] sprites)
        {
            StageSprites = sprites;
        }
    }
}
