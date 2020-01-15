using Assets.Scripts.contants;
using System;
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
                        GameConsole.Instance.SendDevMessage($"Set quest ({id}) stage to: {player.GetQuestStage(id).ToString()}");

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
                                        gameManager.SetTime(number);
                                    else
                                        GameConsole.Instance.SendDevMessage($"Invalid number, needs to be between 0 and 1440");
                                }
                                else
                                {
                                    switch (cmd[2])
                                    {
                                        case "morning":
                                            gameManager.SetTime(360);
                                            break;
                                        case "night":
                                            gameManager.SetTime(1380);
                                            break;
                                        case "noon":
                                            gameManager.SetTime(720);
                                            break;
                                        case "evening":
                                            gameManager.SetTime(1040);
                                            break;
                                    }
                                }
                                break;
                            case "get":
                                GameConsole.Instance.SendDevMessage($"{gameManager.gameTime}");

                                break;
                        }
                    }

                    return true;

                case "day":

                    return true;

                case "setstate":

                    if(cmd.Length < 2)
                    {
                        GameConsole.Instance.SendDevMessage($"Incorrect command, use: setstate id state");
                        return false;
                    }
                    gameManager.SetWorldState(Convert.ToInt32(cmd[1]), Convert.ToInt32(cmd[2]));
                    GameConsole.Instance.SendDevMessage($"Set world state: {cmd[1]} to state {cmd[2]}");
                    break;
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
