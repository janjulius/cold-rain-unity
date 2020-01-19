using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.game.time
{
    public class GameClock : Node
    {
        [SerializeField] public int GameTime { private set; get; }
        [SerializeField] public int Day { private set; get; } = 0;
        /// <summary>
        /// The amount of seconds delay when the time gets updated again
        /// </summary>
        private int UpdateTimeDelay = 5;
        public TextMeshProUGUI TimeText;
        public TextMeshProUGUI DayText;
        
        public override void Initiate()
        {
            base.Initiate();
            DontDestroyOnLoad(this);
        }

        public void StartClock()
        {
            SetDayText();
            InvokeRepeating(nameof(UpdateClock), UpdateTimeDelay, UpdateTimeDelay);
            UpdateClock();
        }

        #region Clock/time/day

        public void UpdateClock()
        {
            GameTime += UpdateTimeDelay;
            SetClockText();
            if (GameTime > 1440)
            {
                GameTime = 0;
                Day++;
                SetDayText();
            }
        }

        private void SetClockText()
        {
            int hrs = (int)GameTime / 60;
            int mins = (int)GameTime - (hrs * 60);
            TimeText.text = $"{(hrs >= 24 ? "00" : hrs.ToString())}:{(mins < 10 ? "0" : "")}{mins}";
        }

        private void SetDayText()
        {
            DayText.text = $"Day {Day}";
        }

        public void SetTime(int time)
        {
            GameTime = time;
            SetClockText();
        }

        public void SetDay(int day)
        {
            this.Day = day;
            SetDayText();
        }

        public void IncreaseTime(int time)
        {
            int newTime = GameTime + time;
            if (newTime > 1440)
            {
                SetDay(Day + (int)Mathf.Floor(time / 1440));
                newTime -= 1440;
            }
            SetTime(newTime);
        }

        #endregion

    }
}
