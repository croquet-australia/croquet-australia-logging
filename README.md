# Croquet Australia - Logging

This repository, [croquet-australia-logging](https://github.com/croquet-australia/croquet-australia-logging), contains the logging library for all Croquet Australia resources. 

## Usage

To start logging:

```c#
LoggerConfiguration.StartLogging();
```

Each logger's minimum logging level can be configured:

```c#
LoggerConfiguration.SetChainsawLevel(minimumLevel: LoggerLevel.Trace)
```

More loggers coming soon. Probably :-)

## Building this solution

After checking out this repository run:

```shell
> npm install
```

TODO: To compile & test this solution run:

```shell
> npm build
```

TODO: To list all available commands run:

```shell
> npm TODO
```

See .\documentation\build-server.md on configuring a build server (continuous integration).