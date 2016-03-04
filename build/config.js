module.exports = function () {
    
    // Solution specific
    var solution = './CroquetAustralia.Logging.sln';
    
    // Required by functions
    var artifacts = './artifacts';
    var configuration = 'Release';
    var tools = './tools';
    
    var config = {
        artifacts: artifacts,
        msbuild: {
            version: '14.0'
        },
        packages: './packages',
        solution: solution,
        testAssemblies: ['**/bin/' + configuration + '/*.Tests.dll', '**/bin/' + configuration + '/*.Specifications.dll'],
        tools: tools,
        xunit: { 
            executable: tools + '/xunit.runner.console.2.1.0/tools/xunit.console.exe',
            options: {
                html: artifacts + '/tests.html'
            }
        } 
    };

    config.getMSBuildOptions = getMSBuildOptions;
         
    return config;
    
    function getMSBuildOptions(target) {
        return {
            configuration: configuration,
            errorOnFail: true,
            fileLoggerParameters: 'LogFile=' + artifacts + '/msbuild.log;Verbosity=normal',
            logCommand: true,
            stderr: true,
            stdout: true,
            targets: [target],
            toolsVersion: 14,
            verbosity: 'minimal'
        } 
    }
};