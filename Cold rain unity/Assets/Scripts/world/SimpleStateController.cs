using Assets.Scripts.managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.world
{
    public class SimpleStateController : Statelistener
    {
        public EnableTrigger[] triggers;

        public override void OnUpdateState(int newVal)
        {
            foreach (EnableTrigger et in triggers)
            {
                foreach (var go in et.GameObjects)
                {
                    go?.SetActive(false);
                }
            }

            foreach (EnableTrigger et in triggers)
            {
                if (et.EnableAt == newVal)
                {
                    foreach (var go in et.GameObjects)
                    {
                        go?.SetActive(true);
                    }
                    break;
                }
            }
        }
    }
    
    [Serializable]
    public class EnableTrigger
    {
        public int EnableAt;
        public GameObject[] GameObjects;
    }
}
