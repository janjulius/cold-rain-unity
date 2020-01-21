using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.logger
{
    public class CrLogger
    {
        public static List<string> logs = new List<string>();

        public static void Log(object caller, string message)
            => Log(caller, message, LogType.DEFAULT);

        public static void Log(object caller, string message, LogType type)
        {
            string msg = ConstructMessage(caller, message, type);
            switch (type)
            {
                case LogType.WARNING:
                    //Debug.LogWarning(msg);
                    logs.Add($"{DateTime.Now.ToString("h: mm:ss")} [WARNING] {msg}");
                    break;
                case LogType.ERROR:
                    //Debug.LogError(msg);
                    logs.Add($"{DateTime.Now.ToString("h: mm:ss tt")} [ERROR] {msg}");
                    break;
                case LogType.DEVELOPER:
                    //Debug.Log(msg);
                    logs.Add($"{DateTime.Now.ToString("h: mm:ss tt")} [DEVELOPER] {msg}");
                    break;
                case LogType.FILTERED:
                    logs.Add($"{DateTime.Now.ToString("h: mm:ss tt")} [FILTERED] {msg}");
                    break;
                case LogType.CONSOLE:
                    logs.Add($"{DateTime.Now.ToString("h: mm:ss tt")} [CONSOLE] {msg}");
                    break;
                default:
                    //Debug.Log(msg);
                    logs.Add($"{DateTime.Now.ToString("h: mm:ss tt")} [DEFAULT] {msg}");
                    break;
            }
        }

        private static string ConstructMessage(object caller, string message, LogType type)
            => $"[{caller}] {message}";

        public enum LogType
        {
            DEFAULT,
            WARNING,
            ERROR,
            DEVELOPER,
            FILTERED,
            CONSOLE
        }
    }
}
