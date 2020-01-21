using Assets.Scripts.contants;
using Assets.Scripts.databases;
using Assets.Scripts.item;
using Assets.Scripts.logger;
using Assets.Scripts.managers;
using System;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.gameinterfaces.console
{
    public static class CommandHandler
    {
        public static bool ProcessCommand(GameManager gameManager, string command)
        {
            Player player = gameManager.player;
            if (command.Length == 0)
                return false;
            string[] cmd = command.Replace(Constants.COMMAND_PREFIX, "").ToLower().Split(' ');
            if (cmd.Length == 0)
                return false;
            if (Constants.DEVELOPER_MODE && ProcessDevModeCommand(gameManager, player, cmd))
                return true;
            return ProcessDefaultCommand(gameManager, player, cmd);
        }
        
        private static bool ProcessDevModeCommand(GameManager gameManager, Player player, string[] cmd)
        {
            try
            {
                switch (cmd[0])
                {
                    case "resetall":
                        PlayerPrefs.DeleteAll();
                        GameConsole.Instance.SendDevMessage("All playerprefs reset succesfully.");
                        return true;

                    case "tp":
                        {
                            if (cmd.Length < 2)
                            {
                                GameConsole.Instance.SendDevMessage("Invalid format, requires: tp x y");
                                return false;
                            }
                            float x = (float)Convert.ToDouble(cmd[1]);
                            float y = (float)Convert.ToDouble(cmd[2]);
                            player.SetLocation(x, y);
                            return true;
                        }
                    case "give":
                    case "item":
                        {
                            if (cmd.Length < 3)
                            {
                                GameConsole.Instance.SendDevMessage("Invalid format, requires: item id amnt");
                                return false;
                            }
                            int id = Convert.ToInt32(cmd[1]);
                            int quant = Convert.ToInt32(cmd[2]);
                            player.InventoryContainer.Add(id, quant);
                            return true;
                        }

                    case "itemn":
                        {
                            StringBuilder sb = new StringBuilder();
                            for (int i = 1; i < cmd.Length; i++)
                            {
                                sb.Append(cmd[i]);
                                sb.Append(" ");
                            }
                            string search = sb.ToString().TrimEnd(' ');
                            ItemDatabase itemdb = gameManager.gameObject.GetComponent<ItemDatabase>();
                            Item res = itemdb.GetItemByName(search);
                            if (res == null)
                                return false;
                            GameConsole.Instance.SendDevMessage($"Spawned: {res.Name}, id: {res.Id}");
                            player.InventoryContainer.Add(res.Id, 1);
                            return true;
                        }


                    case "setqueststage":
                        {
                            if (cmd.Length < 2)
                            {
                                GameConsole.Instance.SendDevMessage("Invalid format, requires: queststage id stage");
                                return false;
                            }
                            int id = Convert.ToInt32(cmd[1]);
                            int stage = Convert.ToInt32(cmd[2]);
                            player.SetQuestStage(id, stage);
                            GameConsole.Instance.SendDevMessage($"Set quest ({id}) stage to: {player.GetQuestStage(id).ToString()}");

                            return true;
                        }

                    case "getqueststage":
                        {
                            if (cmd.Length < 1)
                            {
                                GameConsole.Instance.SendDevMessage("Command requires an id e.g: getqueststage 1");
                                return false;
                            }
                            int id = Convert.ToInt32(cmd[1]);
                            GameConsole.Instance.SendDevMessage($"quest ({id}) stage is: {player.GetQuestStage(id).ToString()}");

                            return true;
                        }

                    case "time":
                        {
                            if (cmd.Length < 1)
                            {
                                GameConsole.Instance.SendDevMessage("Insufficient parameters.");
                                return false;
                            }
                            switch (cmd[1])
                            {
                                case "set":
                                    int number = 0;
                                    bool canParse = Int32.TryParse(cmd[2], out number);
                                    if (canParse)
                                    {
                                        if (number > 0 && number < 1440)
                                            gameManager.GameClock.SetTime(number);
                                        else
                                            GameConsole.Instance.SendDevMessage($"Invalid number, needs to be between 0 and 1440");
                                    }
                                    else
                                    {
                                        switch (cmd[2])
                                        {
                                            case "morning":
                                                gameManager.GameClock.SetTime(360);
                                                break;
                                            case "night":
                                                gameManager.GameClock.SetTime(1380);
                                                break;
                                            case "noon":
                                                gameManager.GameClock.SetTime(720);
                                                break;
                                            case "evening":
                                                gameManager.GameClock.SetTime(1040);
                                                break;
                                        }
                                    }
                                    break;
                                case "get":
                                    GameConsole.Instance.SendDevMessage($"{gameManager.GameClock.GameTime}");

                                    break;
                            }
                        }

                        return true;

                    case "day":

                        return true;

                    case "setworldstate":

                        if (cmd.Length < 2)
                        {
                            GameConsole.Instance.SendDevMessage($"Incorrect command, use: setstate id state");
                            return false;
                        }
                        gameManager.SetWorldState(Convert.ToInt32(cmd[1]), Convert.ToInt32(cmd[2]));
                        GameConsole.Instance.SendDevMessage($"Set world state: {cmd[1]} to state {cmd[2]}");
                        return true;
                    case "getworldstate":

                        GameConsole.Instance.SendDevMessage(WorldStateManager.Instance.GetState(Convert.ToInt32(cmd[1])).ToString());

                        return true;
                    case "setlevel":
                        if (cmd.Length < 2)
                        {
                            GameConsole.Instance.SendDevMessage($"Incorrect command, use: setlevel id level");
                            return false;
                        }
                        player.skills.GetSkill(Convert.ToInt32(cmd[1])).SetLevel(Convert.ToInt32(cmd[2]));
                        return true;
                    case "farming":
                        player.InventoryContainer.Add(259, 1);
                        player.InventoryContainer.Add(260, 1);
                        player.InventoryContainer.Add(262, 1);
                        player.InventoryContainer.Add(261, 1);
                        player.InventoryContainer.Add(266, 10);
                        player.InventoryContainer.Add(263, 10);
                        player.InventoryContainer.Add(264, 10);
                        player.InventoryContainer.Add(265, 10);

                        return true;
                    case "home":
                        player.LoadIntoScene(2, new Vector2(0, 10));
                        return true;
                }
            }
            catch(Exception e)
            {
                CrLogger.Log("CommandHandler", e.StackTrace, CrLogger.LogType.ERROR);
            }
            
            GameConsole.Instance.SendDevMessage("Command not recognized.");
            return false;
        }

        private static bool ProcessDefaultCommand(GameManager gameManager, Player player, string[] cmd)
        {
            return false;
        }

    }
}
