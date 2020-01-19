using Assets.Scripts.databases.game;
using Assets.Scripts.dialogue;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.item;
using Assets.Scripts.skills.farming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.interactable.Skilling.farming
{
    public class FarmingDialogue : Dialogue
    {
        private FarmingCrop farmingCrop;
        private CropDatabase cropDatabase;

        private List<Item> availSeeds = new List<Item>();

        public override void Handle()
        {
            base.Handle();
            switch (stage)
            {
                case 0:
                    if(farmingCrop != null)
                        SendOptionsDialogue("What would you like to do?", "Plant", "Water", "Compost", "Harvest", "Nothing.");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            List<string> res = new List<string>();
                            res.Add("Cancel.");
                            if (farmingCrop.CurrentCrop == null)
                            {
                                player.InventoryContainer.GetItems().ToList().ForEach(i =>
                                {
                                    if (i != null)
                                    {
                                        if (cropDatabase.IsSeed(i.Id) && availSeeds.Count < 3)
                                        {
                                            availSeeds.Add(i);
                                        }
                                    }
                                });
                                res.AddRange(availSeeds.Select(i => i.Name));
                            }
                            SendOptionsDialogue("What would you like to plant?", res.ToArray());
                            stage = 2;
                            break;
                        case 1:
                            stage = 3;
                            break;
                        case 2:
                            stage = 4;
                            break;
                        case 3:
                            End();
                            if (farmingCrop.CanHarvest())
                            {
                                DialogueNoTitle("You harvest the crop.");
                                RewardPlayer();
                                farmingCrop.Harvest();
                            }
                            else
                            {
                                DialogueNoTitle("This crop is not ready to be harvested " + farmingCrop.GetStatus());
                            }
                            break;
                        case 4:
                            End();
                            break;
                    }
                    break;
                case 2:
                    switch (SelectedOption)
                    {
                        case 0: //cancel
                            End();
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            if (player.InventoryContainer.Contains(259) && player.InventoryContainer.Contains(260))
                            {
                                DialogueNoTitle("You plant the seed.");
                                Plant(SelectedOption);
                            }
                            else
                            {
                                DialogueNoTitle("You need a seed dibber and a spade to plant seeds.");
                            }
                            End();
                            break;
                            
                    }
                    break;
                case 3: //water plant
                    End();
                    if (farmingCrop.IsWatered)
                    {
                        DialogueNoTitle("The plant is already sufficiently watered, this would not be a good idea.");
                        break;
                    }
                    if (player.InventoryContainer.Contains(262))
                    {
                        farmingCrop.WaterPlant();
                        DialogueNoTitle("You water the plant.");
                    }
                    else
                    {
                        DialogueNoTitle("You need a watering can to do this.");
                    }

                    break;

                case 4:
                    stage = 100;
                    if(farmingCrop.IsComposted)
                    {
                        DialogueNoTitle("There is already compost on this patch.");
                        break;
                    }
                    if (player.InventoryContainer.Remove(261, 1))
                    {
                        farmingCrop.CompostPlant();
                        DialogueNoTitle("You put compost on the patch.");
                    }
                    else
                    {
                        DialogueNoTitle("You need compost to do this.");
                    }
                    break;
                case 100:
                    End();
                    break;
                    
            }
        }

        private void RewardPlayer()
        {
            int amnt = UnityEngine.Random.Range(1, farmingCrop.CurrentCrop.MaxYield);
            player.InventoryContainer.Add(farmingCrop.CurrentCrop.ResultId, amnt);
            player.skills.GetSkill(SKILLS.FARMING).AddExp(farmingCrop.CurrentCrop.Experience * amnt);
        }

        private void Plant(int selectedOption)
        {
            GameConsole.Instance.SendDevMessage("Attempting to plant seed");
            if(player.InventoryContainer.Remove(availSeeds[selectedOption - 1]))
            {
                farmingCrop.Plant(cropDatabase.GetCropBySeed(availSeeds[selectedOption - 1].Id));
            }
        }

        public override void End(object[] args)
        {

        }

        public override bool Open(object[] args)
        {
            base.Open(args);
            availSeeds.Clear();

            farmingCrop = (FarmingCrop)args[0];
            cropDatabase = (CropDatabase)args[1];
            DialogueNoTitle(farmingCrop.GetStatus());
            stage = 0;
            return true;
        }


    }
}
