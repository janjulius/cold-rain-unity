using Assets.Scripts.game.consumables.consumable;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.managers;
using Assets.Scripts.shops.constants;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.activity.minigame
{
    public class ArtisanFoodActivity : Activity
    {
        int reqTime;
        int timeRemaining;
        int UpdateTimeDelay = 1;

        private int machineBreakingChance = 30;
        private int fireplaceBreakingChance = 30;

        public override void StartActivity(ActivityManager manager, Player player)
        {
            base.StartActivity(manager, player);
            InvokeRepeating("UpdateClock", UpdateTimeDelay, UpdateTimeDelay);
            UpdateClock();
        }

        public override void EndActivity()
        {
            base.EndActivity();
        }

        public IEnumerator RunClock(int time)
        {
            int curTime = time;
            while (WorldStateManager.Instance.GetState(StateConstants.ARTISAN_FIREPLACE_2) == 1)
            {
                curTime -= 1;
                yield return new WaitForSeconds(1);
                if (Random.Range(0, fireplaceBreakingChance) == 1)
                {
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_FIREPLACE_2, 0);
                    GameConsole.Instance.SendConsoleMessage("The fire burned out, relight it.");
                }
            }
        }
        //public void SetArtisanRecipes(ArtisanRecipe[] recipes)
        //{
        //    currentRecipes = recipes;
        //    foreach(var rep in recipes)
        //    {
        //        reqTime += rep.materialAmount * 2;
        //    }
        //    timeRemaining = reqTime;
        //}

        public void UpdateClock()
        {
            if (WorldStateManager.Instance.GetState(StateConstants.ARTISAN_FIREPLACE_1) == 1)
            {
                timeRemaining -= UpdateTimeDelay;
                if (timeRemaining <= 0)
                {
                    CancelInvoke();
                    //RewardPlayer();
                }
                if (Random.Range(0, machineBreakingChance) == 1) //machine
                {
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_MACHINE, 1);
                    GameConsole.Instance.SendConsoleMessage("The machine broke down! Repair it!");
                }
            }
            if (WorldStateManager.Instance.GetState(StateConstants.ARTISAN_FIREPLACE_1) == 1)
            {
                if (Random.Range(0, fireplaceBreakingChance) == 1) //fireplace
                {
                    WorldStateManager.Instance.SetState(StateConstants.ARTISAN_FIREPLACE_1, 0);
                    GameConsole.Instance.SendConsoleMessage("The fire is out, light it again.");
                }
            }
            activityManager.ActivityInterface.SetText($"Time remaining:\n{timeRemaining}");
        }

        //public void RewardPlayer()
        //{
        //    GameConsole.Instance.SendConsoleMessage("You have completed your activity and are awarded: ");
        //    foreach(ArtisanRecipe ar in currentRecipes)
        //    {
        //        player.InventoryContainer.Add(ar.resultId, 1);
        //        GameConsole.Instance.SendConsoleMessage($"{player.InventoryContainer.GetItem(ar.resultId).Name}");
        //        //TODO: player.skills.GetSkill(SKILLS.ARTISAN).AddExp(ar.)
        //    }
        //    EndActivity();
        //}
    }
}
