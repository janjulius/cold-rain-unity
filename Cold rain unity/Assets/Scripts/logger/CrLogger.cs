using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.logger
{
    public class CrLogger : ILogger
    {
        public static List<string> logs = new List<string>();

        public ILogHandler logHandler { get; set; }
        public bool logEnabled { get; set; }
        public UnityEngine.LogType filterLogType { get; set; }

        public static void Log(object caller, string message) => Log(caller, message, LogType.DEFAULT);

        public static void Log(object caller, string message, LogType type)
        {
            string msg = ConstructMessage(caller, message, type);
            switch (type)
            {
                case LogType.WARNING:
                    logs.Add($"{GetTimeAndDate()} {msg}");
                    break;
                case LogType.ERROR:
                    logs.Add($"{GetTimeAndDate()} {msg}");
                    break;
                case LogType.DEVELOPER:
                    logs.Add($"{GetTimeAndDate()} {msg}");
                    break;
                case LogType.FILTERED:
                    logs.Add($"{GetTimeAndDate()} {msg}");
                    break;
                case LogType.CONSOLE:
                    logs.Add($"{GetTimeAndDate()} {msg}");
                    break;
                default:
                    logs.Add($"{GetTimeAndDate()} {msg}");
                    break;
            }
        }

        private static string ConstructMessage(object caller, string message, LogType type)
            => $"[{type.ToString()}] [{caller}] {message}";

        private static string ConstructMessage(object caller, string message, LogType type, UnityEngine.Object context)
             => $"[{type.ToString()}] [{caller}] {message} CTX: {context.name}";

        private static string ConstructMessage(object caller, string message, UnityEngine.LogType logtype)
            => $"[{logtype.ToString()}] [{caller}] {message}";

        private static string ConstructMessage(object caller, string message, UnityEngine.LogType logtype, UnityEngine.Object context)
            => $"[{logtype.ToString()}] [{caller}] {message} CTX: {context.name}";

        public void LogError(string tag, object message) => logs.Add($"{GetTimeAndDate()} {ConstructMessage(tag, message.ToString(), LogType.ERROR)}");
        public void LogError(string tag, object message, UnityEngine.Object context) => logs.Add($"{GetTimeAndDate()} {ConstructMessage(tag, message.ToString(), LogType.ERROR)} CTX: {context.ToString()}");

        public void LogException(Exception exception) => logs.Add($"{GetTimeAndDate()} {ConstructMessage(exception.ToString(), exception.StackTrace.ToString(), LogType.EXCEPTION)}");
        public void LogException(Exception exception, UnityEngine.Object context) => logs.Add($"{GetTimeAndDate()} {ConstructMessage(exception.ToString(), exception.StackTrace.ToString(), LogType.EXCEPTION)} CTX: {context.name}");

        public void LogWarning(string tag, object message) => logs.Add($"{GetTimeAndDate()} {ConstructMessage(tag, message.ToString(), LogType.WARNING)}");
        public void LogWarning(string tag, object message, UnityEngine.Object context) => logs.Add($"{GetTimeAndDate()} {ConstructMessage(tag, message.ToString(), LogType.WARNING)} CTX: {context.name}");

        public void Log(UnityEngine.LogType logType, object message) => logs.Add(ConstructMessage(null, message.ToString(), logType));
        public void Log(UnityEngine.LogType logType, object message, UnityEngine.Object context) => logs.Add(ConstructMessage(context.name, message.ToString(), logType, context));
        public void Log(UnityEngine.LogType logType, string tag, object message) => logs.Add(ConstructMessage(tag, message.ToString(), logType));
        public void Log(UnityEngine.LogType logType, string tag, object message, UnityEngine.Object context) => logs.Add(ConstructMessage(tag, message.ToString(), logType, context));

        public void Log(object message) => logs.Add(ConstructMessage(null, message.ToString(), LogType.LOG));
        public void Log(string tag, object message) => logs.Add(ConstructMessage(tag, message.ToString(), LogType.LOG));
        public void Log(string tag, object message, UnityEngine.Object context) => logs.Add(ConstructMessage(tag, message.ToString(), LogType.LOG, context));

        public void LogFormat(UnityEngine.LogType logType, string format, params object[] args) { }
        public void LogFormat(UnityEngine.LogType logType, UnityEngine.Object context, string format, params object[] args) { }

        private static string GetTimeAndDate() => DateTime.Now.ToString("hh:mm:ss");
        public bool IsLogTypeAllowed(UnityEngine.LogType logType) => true;

        public enum LogType
        {
            DEFAULT,
            WARNING,
            ERROR,
            DEVELOPER,
            FILTERED,
            CONSOLE,
            EXCEPTION,
            LOG
        }
    }
}
