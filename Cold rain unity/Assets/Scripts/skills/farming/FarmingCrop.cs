using Assets.Scripts.game.time;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.managers.skilling;
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
        public Crop CurrentCrop;
        public SpriteRenderer CropSprite;

        private int TimeDone;
        private int DayDone;

        public List<FarmingTime> stageTimes = new List<FarmingTime>();

        private GameManager gameManager;

        public override void StartInitiate()
        {
            base.StartInitiate();
            FarmingManager.Instance.Register(this);
            gameManager = Camera.main.GetComponent<GameManager>();
        }

        public void Plant(Crop crop)
        {
            this.CurrentCrop = crop;
            TimeDone = crop.TakesTime;
            for (int i = 0; i < 5; i++)
            {
                stageTimes.Add(GetTimeAndDay(crop.TakesTime / (Math.Abs(i - 5))));
            }
        }

        internal string GetStatus()
        {
            if(CurrentCrop != null)
            {
                return $"There is currently something growing in this patch, it is at stage {stage}/5.";
            }
            return "There is currently nothing growing in this patch.";
        }

        public void SetStage(int s)
        {
            stage = s;
            CropSprite.sprite = CurrentCrop.StageSprites[s];
        }

        public void CheckForGrowing(int day, int time)
        {
            if(DayDone >= day && TimeDone >= time)
            {
                SetStage(5);
            }
            else
            {
                for(int st = 0; st < stageTimes.Count; st++)
                {
                    if(stageTimes[st].Day >= day && stageTimes[st].Time >= time)
                    {
                        SetStage(st);
                        return;
                    }
                }
            }
        }

        public FarmingTime GetTimeAndDay(int timeIncrease)
        {
            int day = gameManager.GameClock.Day;
            int time = gameManager.GameClock.GameTime;
            bool dayIncr = false;
            if((time + timeIncrease) > 1440)
            {
                day++;
                dayIncr = true;
            }
            if (dayIncr)
            {
                time += timeIncrease - 1440;
            } else
            {
                time += timeIncrease;
            }
            return new FarmingTime(day, time);
        }

        public void Harvest()
        {
            if (stage != 5)
            {
                GameConsole.Instance.SendConsoleMessage($"The plant is not fully grown, currently at stage {stage}/5");
            }
            CurrentCrop = null;
        }

        public void Load()
        {

        }

        public void Save()
        {

        }
    }

    public class FarmingTime {
        public int Day;
        public int Time;

        public FarmingTime(int day, int time)
        {
            Day = day;
            Time = time;
        }
    }

}
