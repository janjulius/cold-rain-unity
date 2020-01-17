using Assets.Scripts.managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.activity.minigame
{
    public class Activity : Node
    {
        public bool IsRunning = false;
        protected ActivityManager activityManager;
        protected Player player;

        public virtual void StartActivity(ActivityManager manager, Player player)
        {
            activityManager = manager;
            this.player = player;
            activityManager.ActivityInterface.SetActive(true);
            IsRunning = true;
        }

        public virtual void EndActivity()
        {
            activityManager.ActivityInterface.SetActive(false);
            IsRunning = false;
        }
    }
}
