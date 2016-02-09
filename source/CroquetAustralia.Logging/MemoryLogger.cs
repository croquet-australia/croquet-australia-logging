using System;
using System.Collections.Generic;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace CroquetAustralia.Logging
{
    public static class MemoryLogger
    {
        public static IList<string> Logs => GetTarget().Logs;

        private static LoggingConfiguration GetConfiguration()
        {
            if (LogManager.Configuration == null)
            {
                throw new InvalidOperationException("Logs cannot be called while logging configuration is null.");
            }

            return LogManager.Configuration;
        }

        private static MemoryTarget GetTarget()
        {
            var configuration = GetConfiguration();
            var target = (MemoryTarget) configuration.FindTargetByName(LoggerConfiguration.MemoryTargetName);

            if (target == null)
            {
                throw new InvalidOperationException("Logs cannot be called while memory logging is not running.");
            }

            return target;
        }
    }
}