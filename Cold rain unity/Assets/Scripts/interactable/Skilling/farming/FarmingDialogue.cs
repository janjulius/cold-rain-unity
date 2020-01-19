using Assets.Scripts.databases.game;
using Assets.Scripts.dialogue;
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
                    SendOptionsDialogue("What would you like to do?", "Plant", "Water", "Compost");
                    stage++;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            if (farmingCrop.CurrentCrop == null)
                            {
                                List<string> res = new List<string>();
                                res.Add("Cancel.");
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
                                SendOptionsDialogue("What would you like to plant?", res.ToArray());
                                stage = 2;
                            }
                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                    }
                    break;
                case 2:
                    switch (SelectedOption)
                    {
                        case 0: //cancel
                            stage = 100;
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            Plant(SelectedOption);
                            break;
                            
                    }
                    break;
                case 100:
                    End();
                    break;
                    
            }
        }

        private void Plant(int selectedOption)
        {
            if(player.InventoryContainer.Remove(availSeeds[selectedOption + 1]))
            {
                farmingCrop.Plant(cropDatabase.GetCropBySeed(availSeeds[selectedOption + 1].Id));
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
