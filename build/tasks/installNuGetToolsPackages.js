var gulp = require('gulp');
var config = require('config')();
var nuget = require('lib/nuget');
 
// Install the NuGet packages defined in ./tools
module.exports = function installNuGetToolsPackages(){

    var source = config.tools + '/packages.config';
    var destination = config.tools;
    
    return nuget.restorePackages(gulp, source, destination, config.msbuild.version);
};
