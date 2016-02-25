# Build Server for Croquet Australia - Logging

The following describes how to configure a [Jenkins CI](http://jenkins-ci.org/) build server to compile, test & publish croquet-australia-logging.

## Prerequisites

### Jenkins CI

See [azure-build-server](https://github.com/timmurphy/azure-build-server) for documentation and scripts to create and configure an Azure Virtual Machine to run Jenkins CI.

#### Plugins

The Jenkins CI server requires the following plugins:

- [Github plugin](https://wiki.jenkins-ci.org/display/JENKINS/GitHub+Plugin)

### Chocolatey

- choco install dotnet4.6.1-devpack
- choco install microsoft-build-tools

## GitHub - Configure Webhook

- Goto: https://github.com/croquet-australia/croquet-australia-logging/settings/hooks/new?service=jenkins
- Jenkins hook url: https://Jenkins:{password}@buildservertmit.cloudapp.net/github-webhook/

## Jenkins CI - Create Job

- Name: croquet-australia-logging
- Freestyle project: Select
- Click `OK` button
- GitHub project: Tick
    - Project url: https://github.com/croquet-australia/croquet-australia-logging
- Source Code Management:
    - Select Git
        - Repository URL: https://github.com/croquet-australia/croquet-australia-logging.git
        - Click `Advanced` button
            - Branch Specifier (blank for 'any'): <blank>
            - Additional Behaviours:
                - Click `Add` button
                - Select `Advanced sub-modules behaviours`
                - Tick `Recursively update submodules`                
- Build Triggers
    - Build when a change is pushed to GitHub
- Build Steps
    - Execute Windows batch command
        - Command: npm install
    - Execute Windows batch command
        - Command: npm test

Now do a manual build then test build on push to GitHub.