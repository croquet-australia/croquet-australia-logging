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

### Prerequisites

#### Install gulp globally

If you have previously installed a version of gulp globally, please run **`npm remove --global gulp`** to make sure your old version doesn't collide with gulp-cli.

```shell
npm install --global gulp-cli
```

#### Install npm packages

```shell
npm install
```

### Clean, Compile & Test

gulp

### List gulp tasks

todo

See .\documentation\build-server.md on configuring a build server (continuous integration).