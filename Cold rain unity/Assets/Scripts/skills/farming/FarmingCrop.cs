using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.skills.farming
{
    public class FarmingCrop : Node, SavingModule
    {
        private int stage;
        public SpriteRenderer CropSprite;

        public void UpdateStage()
        {

        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

}
