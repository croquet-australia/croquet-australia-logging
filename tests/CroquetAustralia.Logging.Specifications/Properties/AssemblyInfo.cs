using System.Reflection;
using Anotar.Custom;
using CroquetAustralia.Logging;
using Xunit;

[assembly: AssemblyTitle("CroquetAustralia.Logging.Specifications")]
[assembly: AssemblyDescription("Specifications for CroquetAustralia.Logging project.")]
[assembly: LoggerFactory(typeof(LoggerFactory))]
[assembly: LogMinimalMessage]
[assembly: CollectionBehavior(DisableTestParallelization = true)] // Tests cannot be run in parallel because NLog uses singletons.