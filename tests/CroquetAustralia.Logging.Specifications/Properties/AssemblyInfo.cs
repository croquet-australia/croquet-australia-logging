using System.Reflection;
using Anotar.NLog;
using Xunit;

[assembly: AssemblyTitle("CroquetAustralia.Logging.Specifications")]
[assembly: AssemblyDescription("Specifications for CroquetAustralia.Logging project.")]
[assembly: CollectionBehavior(DisableTestParallelization = true)] // Tests cannot be run in parallel because NLog uses singletons.
[assembly: LogMinimalMessage]