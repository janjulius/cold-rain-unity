using System;
using UnityEngine;

namespace Assets.Scripts.logger
{
    public class CrLogger
    {
        public static void Log(object caller, string message)
            => Log(caller, message, LogType.DEFAULT);

        public static void Log(object caller, string message, LogType type)
        {
            string msg = ConstructMessage(caller, message, type);
            switch (type)
            {
                case LogType.WARNING:
                    Debug.LogWarning(msg);
                    break;
                case LogType.ERROR:
                    Debug.LogError(msg);
                    break;
                default:
                    Debug.Log(msg);
                    break;
            }
        }

        private static string ConstructMessage(object caller, string message, LogType type)
            => $"[{caller}] {message}";

        public enum LogType
        {
            DEFAULT,
            WARNING,
            ERROR
        }
    }
}
