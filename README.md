# Croquet Australia - Logging

This repository, [croquet-australia-logging](https://github.com/croquet-australia/croquet-australia-logging), contains the logging library for all Croquet Australia resources. 

## Usage

To start logging:

```
LoggerConfiguration.Start();
```

Each logger's minimum logging level can be configured:

```
LoggerConfiguration.SetChainsawLevel(minimumLevel: LoggerLevel.Trace)
```

More loggers coming soon. Probably :-)