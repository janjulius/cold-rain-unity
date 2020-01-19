using System;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.managers;
using Assets.Scripts.shops.constants;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.activity.minigame
{
    public class ArtisanFoodActivity : Activity
    {
        private int fireplaceBreakingChance = 30;
        int UpdateTimeDelay = 1;
        int jamTime = 10;
        int milkTime = 10;
        int cheeseTime = 10;
        bool jamIsRunning;
        bool milkIsRunning;
        bool cheeseIsRunning;
        int SelectedMilkType;
        int SelectedCheeseType;

        public void StartJamActivity(Player player)
        {
            IsRunning = true;
            jamIsRunning = true;
            InvokeRepeating("RunJamClock", UpdateTimeDelay, UpdateTimeDelay);
            RunJamClock();
        }

        public void StartMilkActivity(Player player, int milkType)
        {
            IsRunning = true;
            milkIsRunning = true;
            SelectedMilkType = milkType;
            InvokeRepeating("RunMilkClock", UpdateTimeDelay, UpdateTimeDelay);
            RunMilkClock();
        }

        public void StartCheeseActivity(Player player, int cheeseType)
        {
            IsRunning = true;
            cheeseIsRunning = true;
            SelectedCheeseType = cheeseType;
            InvokeRepeating("RunCheeseClock", UpdateTimeDelay, UpdateTimeDelay);
            RunCheeseClock();
        }

        private void checkRunning()
        {
            if (jamIsRunning == false && milkIsRunning == false && cheeseIsRunning == false)
            {
                IsRunning = false;
                WorldStateManager.Instance.SetState(StateConstants.ARTISAN_FIREPLACE_2, 0);
                GameConsole.Instance.SendConsoleMessage("The fire burned out, relight it.");
            }
        }

        public void RunJamClock()
        {
            if (WorldStateManager.Instance.GetState(StateConstants.ARTISAN_FIREPLACE_2) == 1)
            {
                if (jamTime <= 0)
                {
                    CancelInvoke();
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_JAM_DONE, 1);
                    jamTime = 10;
                    jamIsRunning = false;
                    checkRunning();
                }
                jamTime -= 1;
                if (UnityEngine.Random.Range(0, fireplaceBreakingChance) == 1)
                {
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_FIREPLACE_2, 0);
                    GameConsole.Instance.SendConsoleMessage("The fire burned out, relight it.");
                }
            }
        }

        public void RunMilkClock()
        {
            if (WorldStateManager.Instance.GetState(StateConstants.ARTISAN_FIREPLACE_2) == 1)
            {
                if (milkTime <= 0)
                {
                    CancelInvoke();
                    switch (SelectedMilkType)
                    {
                        case 0:
                            WorldStateManager.Instance.SetState(StateConstants.ARTISAN_MILK_DONE, 1);
                            break;
                        case 1:
                            WorldStateManager.Instance.SetState(StateConstants.ARTISAN_GOAT_MILK_DONE, 1);
                            break;
                    }
                    milkTime = 10;
                    milkIsRunning = false;
                    checkRunning();
                }
                milkTime -= 1;
                if (UnityEngine.Random.Range(0, fireplaceBreakingChance) == 1)
                {
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_FIREPLACE_2, 0);
                    GameConsole.Instance.SendConsoleMessage("The fire burned out, relight it.");
                }
            }
        }

        public void RunCheeseClock()
        {
            if (cheeseTime <= 0)
            {
                CancelInvoke();
                switch (SelectedCheeseType)
                {
                    case 0:
                        WorldStateManager.Instance.SetState(StateConstants.ARTISAN_CHEESE_DONE, 1);
                        break;
                    case 1:
                        WorldStateManager.Instance.SetState(StateConstants.ARTISAN_GOAT_CHEESE_DONE, 1);
                        break;
                }
                cheeseTime = 10;
                cheeseIsRunning = false;
                checkRunning();
            }
            cheeseTime -= 1;
        }
    }
}
