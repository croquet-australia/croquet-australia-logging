var config = require('config')();
var del = require('del');
var gulp = require('gulp');
var log = require('lib/logging');

// Delete all output directories
module.exports = function clean() {

    var configuration = config.getMSBuildOptions().configuration
    var paths = [
        config.artifacts,
        './**/bin/' + configuration,
        './**/obj/' + configuration
    ];

    log.starting('Deleting', paths.join(', '));

    return del(paths);
};
