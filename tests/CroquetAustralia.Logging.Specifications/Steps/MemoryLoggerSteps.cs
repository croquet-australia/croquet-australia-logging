using System;
using System.Collections.Generic;
using System.Linq;
using Anotar.Custom;
using FluentAssertions;
using NLog;
using TechTalk.SpecFlow;

namespace CroquetAustralia.Logging.Specifications.Steps
{
    [Binding]
    public class MemoryLoggerSteps
    {
        private readonly List<KeyValuePair<string, string>> _givenLogMessages = new List<KeyValuePair<string, string>>();
        private Exception _exception;
        private IList<string> _logs;

        [Given(@"I have started the logger")]
        public void GivenIHaveStartedTheLogger()
        {
            LoggerConfiguration.StartLogging(true);
        }

        [Given(@"I have logged trace message '(.*)'")]
        public void GivenIHaveLoggedTraceMessage(string logMessage)
        {
            GivenLogMessage("Trace", logMessage, () => LogTo.Trace(logMessage));
        }

        [Given(@"I have logged debug message '(.*)'")]
        public void GivenIHaveLoggedDebugMessage(string logMessage)
        {
            GivenLogMessage("Debug", logMessage, () => LogTo.Debug(logMessage));
        }

        [Given(@"I have logged info message '(.*)'")]
        public void GivenIHaveLoggedInfoMessage(string logMessage)
        {
            GivenLogMessage("Info", logMessage, () => LogTo.Information(logMessage));
        }

        [Given(@"I have logged warn message '(.*)'")]
        public void GivenIHaveLoggedWarnMessage(string logMessage)
        {
            GivenLogMessage("Warn", logMessage, () => LogTo.Warning(logMessage));
        }

        [Given(@"I have logged error message '(.*)'")]
        public void GivenIHaveLoggedErrorMessage(string logMessage)
        {
            GivenLogMessage("Error", logMessage, () => LogTo.Error(logMessage));
        }

        private void GivenLogMessage(string logLevel, string logMessage, Action logAction)
        {
            _givenLogMessages.Add(new KeyValuePair<string, string>(logLevel, logMessage));
            logAction();
        }

        [When(@"I call MemoryLogger\.Logs")]
        public void WhenICallMemoryLogger_Logs()
        {
            try
            {
                _logs = MemoryLogger.Logs;
                _exception = null;
            }
            catch (Exception exception)
            {
                _exception = exception;
            }
        }

        [Then(@"the result be should a list of the logging messages")]
        public void ThenTheResultBeShouldAListOfTheLoggingMessages()
        {
            // Each log line is {timestamp}|{loglevel}|{logger}|{message}. 
            // We want to compare everything but the {timestamp}
            var actual = _logs.Select(log => log.Split('|').Skip(1));
            var expected = _givenLogMessages.Select(p => new[] { p.Key.ToUpperInvariant(), typeof(MemoryLoggerSteps).FullName, p.Value });

            actual.ShouldAllBeEquivalentTo(expected);
        }

        [Then(@"an InvalidOperationException should be thrown with message '(.*)'")]
        public void ThenAnInvalidOperationExceptionShouldBeThrownWithMessage(string expectedMessage)
        {
            _exception
                .Should().BeOfType<InvalidOperationException>()
                .Which.Message
                .Should().Be(expectedMessage);
        }

        [Given(@"the memory logger is turned off")]
        public void GivenTheMemoryLoggerIsTurnedOff()
        {
            var config = LogManager.Configuration;

            config.RemoveTarget(LoggerConfiguration.MemoryTargetName);
        }
    }
}