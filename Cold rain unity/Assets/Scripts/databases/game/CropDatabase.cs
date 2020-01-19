using Assets.Scripts.skills.farming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.databases.game
{
    public class CropDatabase : CRDatabase
    {

        List<Crop> CropList = new List<Crop>();

        public override void BuildDatabase()
        {
            items = new List<DbElement>
            {
                //       seed res  time exp lvl yield
                new Crop(0, "Onion", 266, 270, 60, 100, 0, 10), //onion
                new Crop(1, "Tomato", 263, 267, 420, 210, 0, 20), //tomato
                new Crop(2, "Corn", 264, 268, 320, 150, 0, 15), //corn
                new Crop(3, "Lettuce", 265, 269, 210, 90, 0, 10), //lettuce
            };
            CropList = items.Cast<Crop>().ToList();

            for (int i = 0; i < items.Count; i++)
            {
                Sprite[] sprites = new Sprite[5];
                for(int j = 0; j < 5; j++)
                {
                    sprites[j] = Resources.Load<Sprite>($"Crops/{i}/crop_{i}_{j}");
                }
                CropList[i].SetSprites(sprites);
            }
        }
        
        public Crop GetCropBySeed(int id)
        {
            return CropList.Where(c => c.SeedId == id).FirstOrDefault();
        }

        public Crop GetCropById(int id)
        {
            return CropList.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool IsSeed(int id)
        {
            return CropList.Where(c => c.SeedId == id).FirstOrDefault() != null;
        }
    }
}
