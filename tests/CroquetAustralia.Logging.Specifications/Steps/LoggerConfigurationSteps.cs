using System.Linq;
using CroquetAustralia.Logging.Specifications.Helpers;
using FluentAssertions;
using NLog;
using TechTalk.SpecFlow;

namespace CroquetAustralia.Logging.Specifications.Steps
{
    [Binding]
    public class LoggerConfigurationSteps
    {
        private readonly ActualData _actual;
        private readonly GivenData _given;

        public LoggerConfigurationSteps(GivenData given, ActualData actual)
        {
            _given = given;
            _actual = actual;
        }

        [Given(@"isDeveloperMachine is (.*)")]
        public void GivenIsDeveloperMachineIs(bool isDeveloperMachine)
        {
            _given.IsDeveloperMachine = isDeveloperMachine;
        }

        [When(@"I call LoggerConfiguration\.StartLogging\(isDeveloperMachine\)")]
        public void WhenICallLoggerConfiguration_StartLoggingIsDeveloperMachine()
        {
            LoggerConfiguration.StartLogging(_given.IsDeveloperMachine);
        }

        [Then(@"Chainsaw logger should be started with minimum level trace")]
        public void ThenChainsawLoggerShouldBeStartedWithMinimumLevelTrace()
        {
            LoggerShouldBeStartedWithMinimumLevelTrace(LoggerConfiguration.ChainsawTargetName);
        }

        [Then(@"Memory logger should be started with minimum level trace")]
        public void ThenMemoryLoggerShouldBeStartedWithMinimumLevelTrace()
        {
            LoggerShouldBeStartedWithMinimumLevelTrace(LoggerConfiguration.MemoryTargetName);
        }

        [Then(@"Chainsaw logger should not be started")]
        public void ThenChainsawLoggerShouldNotBeStarted()
        {
            LoggerShouldNotBeStarted(LoggerConfiguration.ChainsawTargetName);
        }

        [Then(@"Memory logger should not be started")]
        public void ThenMemoryLoggerShouldNotBeStarted()
        {
            LoggerShouldNotBeStarted(LoggerConfiguration.ChainsawTargetName);
        }

        private static void LoggerShouldBeStartedWithMinimumLevelTrace(string targetName)
        {
            // Do not use LogManager.Configuration.FindTargetByName because it looks up NamedTargets
            // and NamedTargets are not necessarily logged to.
            LogManager.Configuration.AllTargets.Any(t => t.Name == targetName).Should().BeTrue();

            var loggingRule = LogManager.Configuration.LoggingRules.Single(l => l.Targets.Any(t => t.Name == targetName));

            loggingRule.IsLoggingEnabledForLevel(LogLevel.Trace).Should().BeTrue();
        }

        private static void LoggerShouldNotBeStarted(string targetName)
        {
            // Do not use LogManager.Configuration.FindTargetByName because it looks up NamedTargets
            // and NamedTargets are not necessarily logged to.
            LogManager.Configuration?.AllTargets.Any(t => t.Name == targetName).Should().BeFalse();
        }
    }
}