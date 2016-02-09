using NLog;
using TechTalk.SpecFlow;

namespace CroquetAustralia.Logging.Specifications.Steps
{
    [Binding]
    public class CommonSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            LogManager.Configuration = null;
        }
    }
}