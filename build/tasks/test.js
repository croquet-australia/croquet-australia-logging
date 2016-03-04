var config = require('config')();
var gulp = require('gulp');
var log = require('lib/logging');
var xunit = require('gulp-xunit-runner');

// Run all tests
module.exports = function test() {
    log.starting('Testing', config.testAssemblies);

    return gulp
        .src(config.testAssemblies, { read: false })
        .pipe(xunit(config.xunit));
};
