Feature: MemoryLogger

Scenario: Get logs
	Given I have started the logger
	And I have logged trace message 'dummy trace message'
	And I have logged debug message 'dummy debug message'
	And I have logged info message 'dummy info message'
	And I have logged warn message 'dummy warn message'
	And I have logged error message 'dummy error message'
	When I call MemoryLogger.Logs
	Then the result be should a list of the logging messages

Scenario: Get logs before logger is running
	When I call MemoryLogger.Logs
    Then an InvalidOperationException should be thrown with message 'Logs cannot be called while logging configuration is null.'

Scenario: Get logs when memory logger is not running
	Given I have started the logger
    And the memory logger is turned off
	When I call MemoryLogger.Logs
    Then an InvalidOperationException should be thrown with message 'Logs cannot be called while memory logging is not running.'