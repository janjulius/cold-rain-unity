using Assets.Scripts.activity.minigame;
using Assets.Scripts.gameinterfaces.activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.managers
{
    public class ActivityManager : Node
    {
        public ActivityInterface ActivityInterface;
        public Activity Activity { set; get; }

        public override void Initiate()
        {
            base.Initiate();
            DontDestroyOnLoad(this);
        }

    }
}
