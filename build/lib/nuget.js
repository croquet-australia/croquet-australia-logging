module.exports = { restorePackages };

function restorePackages(gulp, source, destination, msbuildVersion) {

    var nugetRestore = require('gulp-nuget-restore');
    var options = {
        additionalArgs: ['-PackagesDirectory', destination, '-MSBuildVersion', msbuildVersion]
    }

    return gulp
        .src(source)
        .pipe(nugetRestore(options));
}