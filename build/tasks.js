require('app-module-path').addPath("./build");

var gulp = require('gulp');

// Order of tasks is important.
//
// When a task runs a gulp.series(...) and one of the items
// in the series call a task then the task must already
// be defined.
gulp.task('clean', load('clean'));
gulp.task('install:npm', load('installNpmPackages'));
gulp.task('install:nuget', gulp.parallel(load('installNuGetSolutionPackages'), load('installNuGetToolsPackages')));
gulp.task('install', gulp.parallel('install:npm', 'install:nuget'));
gulp.task('compile', gulp.series(gulp.parallel('clean', 'install'), load('compile')));
gulp.task('test', gulp.series('compile', load('test')));
gulp.task('build', gulp.series('test'));
gulp.task('default', gulp.series('build'));

function load(name) {
    return require('tasks/' + name);
}