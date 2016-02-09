Feature: LoggerConfiguration

Scenario: StartLogging(isDeveloperMachine: true)
	Given isDeveloperMachine is true
	When I call LoggerConfiguration.StartLogging(isDeveloperMachine)
	Then Chainsaw logger should be started with minimum level trace
	Then Memory logger should be started with minimum level trace

Scenario: StartLogging(isDeveloperMachine: false)
	Given isDeveloperMachine is false
	When I call LoggerConfiguration.StartLogging(isDeveloperMachine)
	Then Chainsaw logger should not be started
	Then Memory logger should not be started
