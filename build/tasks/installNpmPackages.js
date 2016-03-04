var gulp = require('gulp');
var install = require("gulp-install");

// Install npm packages
module.exports = function installNpmPackages() {
    return gulp
        .src('./package.json')
        .pipe(install({noOptional: true}));
};

