using Assets.Scripts.databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.quest
{
    public class Quest
    {
        public string Name { private set; get; }
        public int Stage { private set; get; }
        
        public void Finish(params string[] rewards)
        {

        }

        public void SetStage(int stage)
        {

        }

        public bool IsStarted() {
            return Stage >= 0 && Stage <= 100;
        }
    }
}
