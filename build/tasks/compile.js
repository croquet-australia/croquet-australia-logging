var config = require('config')();
var gulp = require('gulp');
var log = require('lib/logging');
var mkdirp = require('mkdirp')
var msbuild = require('gulp-msbuild');

// Compile the solution
module.exports = function compile() {
    log.starting('Compiling', config.solution);

    mkdirp.sync(config.artifacts);
    
    var options = config.getMSBuildOptions('ReBuild')

    return gulp
        .src(config.solution)
        .pipe(msbuild(options));
};

