using Assets.Scripts.shops.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.dialogue.dialogues
{
    class LivestockStoreDialogue : Dialogue
    {
        public override void Initiate()
        {
            base.Initiate();
        }

        public override void Handle()
        {
            base.Handle();
            switch (stage)
            {
                case 0:
                    SendOptionsDialogue("Select an option", "Browse store", "Purchase chicken", "Purchase goat", "Purchase sheep", "Purchase cow");
                    stage = 1;
                    break;
                case 1:
                    switch (SelectedOption)
                    {
                        case 0:
                            OpenShop(ShopConstants.LIVESTOCK_SHOP);
                            stage = 100;
                            break;
                        case 1:
                            stage = 2;
                            Continue();
                            break;
                        case 2:
                            stage = 3;
                            Continue();
                            break;
                        case 3:
                            stage = 4;
                            Continue();
                            break;
                        case 4:
                            stage = 5;
                            Continue();
                            break;
                    }
                    End();
                    break;
                case 2:
                    Npc("One chicken, that'll be 250, is that alright?");
                    stage = 6;
                    break;
                case 3:
                    Npc("One goat, that'll be 800, is that alright?");
                    stage = 7;
                    break;
                case 4:
                    Npc("One sheep, that'll be 1000, is that alright?");
                    stage = 8;
                    break;
                case 5:
                    Npc("One cow, that'll be 1500, is that alright?");
                    stage = 9;
                    break;
                case 6:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 10;
                    break;
                case 7:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 11;
                    break;
                case 8:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 12;
                    break;
                case 9:
                    SendOptionsDialogue("Select an option", "Yes", "No");
                    stage = 13;
                    break;
                case 10:
                    switch (SelectedOption)
                    {
                        case 0:
                            //remove money add chicken
                            break;
                        case 1:
                            stage = 100;
                            Continue();
                            break;
                    }
                    break;
                case 11:
                    switch (SelectedOption)
                    {
                        case 0:
                            //remove money add goat
                            break;
                        case 1:
                            stage = 100;
                            Continue();
                            break;
                    }
                    break;
                case 12:
                    switch (SelectedOption)
                    {
                        case 0:
                            //remove money add sheep
                            break;
                        case 1:
                            stage = 100;
                            Continue();
                            break;
                    }
                    break;
                case 13:
                    switch (SelectedOption)
                    {
                        case 0:
                            //remove money add cow
                            break;
                        case 1:
                            stage = 100;
                            Continue();
                            break;
                    }
                    break;
                case 100:
                    End();
                    break;
            }
        }

        public override void End(object[] args)
        {
            throw new NotImplementedException();
        }

        public override bool Open(object[] args)
        {
            base.Open(args);
            Npc($"What would you Like to do?");
            stage = 0;
            return true;
        }
    }
}
