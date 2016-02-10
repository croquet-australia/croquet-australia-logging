using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace CroquetAustralia.Logging
{
    public static class LoggerConfiguration
    {
        internal const string ChainsawTargetName = "Chainsaw";
        internal const string MemoryTargetName = "Memory";

        public static void StartLogging(bool isDeveloperMachine = false)
        {
            if (!isDeveloperMachine)
            {
                return;
            }
            SetChainsawLevel(LogLevel.Trace);
            SetMemoryLevel(LogLevel.Trace);
        }

        private static void SetChainsawLevel(LogLevel minimumLevel)
        {
            SetTargetLevel(
                ChainsawTargetName,
                minimumLevel,
                targetName => new ChainsawTarget { Name = targetName, Address = "udp://127.0.0.1:7071" });
        }

        private static void SetMemoryLevel(LogLevel minimumLevel)
        {
            SetTargetLevel(
                MemoryTargetName,
                minimumLevel,
                targetName => new MemoryTarget { Name = targetName });
        }

        private static void SetTargetLevel(string targetName, LogLevel minimumLevel, Func<string, Target> targetFactory)
        {
            var config = LogManager.Configuration ?? (LogManager.Configuration = new LoggingConfiguration());
            var target = config.FindTargetByName(targetName);

            if (target != null)
            {
                throw new NotImplementedException("Changing target level has not been implemented, yet!");
            }

            target = targetFactory(targetName);

            config.AddTarget(target);
            config.LoggingRules.Add(new LoggingRule("*", minimumLevel, target));

            LogManager.Configuration = config;
        }
    }
}