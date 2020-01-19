using Assets.Scripts.databases.game;
using Assets.Scripts.interactable.Skilling.farming;
using Assets.Scripts.skills.farming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.managers.skilling
{
    public class FarmingManager : Node
    {
        private FarmingManager() { }
        public static FarmingManager Instance;

        public GameManager GameManager;

        private List<FarmingCrop> RegisteredCrops = new List<FarmingCrop>();

        public override void Initiate()
        {
            base.Initiate();
            Instance = this;
            DontDestroyOnLoad(this);
            GameManager = GameManager ?? Camera.main.GetComponent<GameManager>();
        }

        public void Register(FarmingCrop crop)
        {
            RegisteredCrops.Add(crop);
        }

        public void CheckCrops()
        {
            foreach(FarmingCrop c in RegisteredCrops)
            {
                c.CheckForGrowing(GameManager.GameClock.Day, GameManager.GameClock.GameTime);
            }
        }

        public void StartDialogue(FarmingCrop crop)
        {
            FarmingDialogue dial = GetComponent<FarmingDialogue>();
            dial.Open(new object[] { crop, GameManager.GetComponent<CropDatabase>() });
        }
    }
}
