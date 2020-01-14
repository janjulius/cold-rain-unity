using Assets.Scripts.contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.gameinterfaces.console
{
    public static class CommandHandler
    {
        public static bool ProcessCommand(Player player, string command)
        {
            if (command.Length == 0)
                return false;
            string[] cmd = command.Replace(Constants.COMMAND_PREFIX, "").ToLower().Split(' ');
            if (cmd.Length == 0)
                return false;
            if (Constants.DEVELOPER_MODE && ProcessDevModeCommand(player, cmd))
                return true;
            return ProcessDefaultCommand(player, cmd);
        }



        private static bool ProcessDevModeCommand(Player player, string[] cmd)
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
            }


            GameConsole.Instance.SendDevMessage("Command not recognized.");
            return false;
        }

        private static bool ProcessDefaultCommand(Player player, string[] cmd)
        {
            return false;
        }

    }
}
