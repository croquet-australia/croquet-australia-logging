var gulp = require('gulp');
var config = require('config')();
var nuget = require('lib/nuget');
 
// Install the solution's NuGet packages
module.exports = function installNuGetSolutionPackages(){

    var source = config.solution;
    var destination = config.packages;

    return nuget.restorePackages(gulp, source, destination, config.msbuild.version);
};