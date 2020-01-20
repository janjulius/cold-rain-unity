using Assets.Scripts.databases.game;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.managers.skilling;
using Assets.Scripts.saving;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.skills.farming
{
    public class FarmingCrop : Node, SavingModule
    {
        [Header("NEEDS TO BE UNIQUE")]
        public int Id;
        private int stage;
        public Crop CurrentCrop;
        public SpriteRenderer CropSprite;

        private int TimeDone;
        private int DayDone;

        public List<FarmingTime> stageTimes = new List<FarmingTime>();

        private GameManager gameManager;
        private CropDatabase cropDatabase;
        public bool IsWatered { private set; get; }
        public bool IsComposted { private set; get; }

        public override void Initiate()
        {
            base.Initiate();
            FarmingManager.Instance.Register(this);
            gameManager = Camera.main.GetComponent<GameManager>();
            cropDatabase = gameObject.GetComponent<CropDatabase>();
            Load();
            CheckForGrowing(gameManager.GameClock.Day, gameManager.GameClock.GameTime);
        }

        public void Plant(Crop crop)
        {
            this.CurrentCrop = crop;
            GameConsole.Instance.SendDevMessage($"Planting crop: {crop.Name}");
            for (int i = 0; i < 5; i++)
            {
                stageTimes.Add(GetTimeAndDay((crop.TakesTime / 5) * i + 1));
                GameConsole.Instance.SendDevMessage($"Time set to {stageTimes.Last().Day} at {stageTimes.Last().Time}");
            }
            TimeDone = stageTimes.Last().Time;
            DayDone = stageTimes.Last().Day;
            FarmingManager.Instance.Register(this);
        }

        internal string GetStatus()
        {
            if (CurrentCrop != null)
            {
                return $"There is currently something growing in this patch, it is at stage {stage}/5. {(IsComposted ? "There is compost on the patch." : "")} {(IsWatered ? "The patch is watered." : "")}";
            }
            return "There is currently nothing growing in this patch.";
        }

        public void SetStage(int s)
        {
            if (!IsWatered && stage < 5)
            {
                if (UnityEngine.Random.Range(0, 5) == 1)
                {
                    GameConsole.Instance.SendConsoleMessage($"Your {CurrentCrop.Name.ToLower()} plant has perished, it was too dry.");
                    ResetCrop();
                }
            }
            stage = s;
            if(CropSprite != null)
                CropSprite.sprite = CurrentCrop?.StageSprites[s - 1];
        }

        public void CheckForGrowing(int day, int time)
        {
            if (CurrentCrop != null)
            {
                if (day > DayDone || (DayDone == day && time >= TimeDone))
                {
                    SetStage(5);
                }
                else
                {
                    for (int st = 0; st < stageTimes.Count; st++)
                    {
                        if (stageTimes[st].Day >= day && stageTimes[st].Time >= time)
                        {
                            if (stage != st)
                                SetStage(st);
                            return;
                        }
                    }
                }
            }
        }

        public FarmingTime GetTimeAndDay(int timeIncrease)
        {
            int day = gameManager.GameClock.Day;
            int time = gameManager.GameClock.GameTime;
            bool dayIncr = false;
            if ((time + timeIncrease) > 1440)
            {
                day++;
                dayIncr = true;
            }
            if (dayIncr)
            {
                time += timeIncrease - 1440;
            }
            else
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
            ResetCrop();
            CurrentCrop = null;
        }

        private void ResetCrop()
        {
            FarmingManager.Instance.Unregister(this);
            CurrentCrop = null;
            CropSprite.sprite = null;
            stage = 0;
        }

        public bool CanHarvest()
        {
            return stage >= 5;
        }

        public bool FullyGrown()
        {
            return stage >= 5;
        }

        public void WaterPlant()
        {
            IsWatered = true;
        }

        public void CompostPlant()
        {
            IsComposted = true;
        }

        public void Load()
        {
            print("Loading crop");
            stage = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}stage"), 0);

            for (int i = 0; i < stageTimes.Count; i++)
            {
                stageTimes[i].Day = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-{i}day"), 0);
                stageTimes[i].Time = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-{i}time"), 0);
            }

            TimeDone = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-timedone"), 0);
            DayDone = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-daydone"), 0);

            cropDatabase = cropDatabase ?? FindObjectOfType<CropDatabase>();
            CurrentCrop = cropDatabase.GetCropById(PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"crop"), 0));

            IsWatered = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-watered"), 0) != 0;
            IsComposted = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-composted"), 0) != 0;
        }

        public void Save()
        {
            print("saving crop");
            PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-stage"), stage);

            for (int i = 0; i < stageTimes.Count; i++)
            {
                PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-{i}day"), stageTimes[i].Day);
                PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-{i}time"), stageTimes[i].Time);
            }
            PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-timedone"), TimeDone);
            PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-daydone"), DayDone);

            PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-crop"), CurrentCrop.Id);

            PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-watered"), IsWatered ? 1 : 0);
            PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, $"{Id}-composted"), IsComposted ? 1 : 0);
        }
    }

    public class FarmingTime
    {
        public int Day;
        public int Time;

        public FarmingTime(int day, int time)
        {
            Day = day;
            Time = time;
        }
    }

}
