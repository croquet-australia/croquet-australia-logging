module.exports = { error, finished, info, quote, starting };

var util = require('gulp-util');

// Logs a task has finished
//
// e.g. finished('Compiled', './solution') => Compiled './solution'.
function finished(action, what) {
    if (what == undefined) {
        info(action);    
    } else {
        info(action.trim() + ' ' + quote(what) + '.');
    }
}

// Log an error message or series of error messages. Can pass in a string, object or array.
function error(message){
    log(message, util.colors.red);
}

// Log a message or series of messages. Can pass in a string, object or array.
function info(message) {
    log(message, util.colors.white)
}

// Logs a colored message or series of messages. Can pass in a string, object or array.
function log(message, color){
    if (typeof (message) === 'object') {
        for (var item in message) {
            if (message.hasOwnProperty(item)) {
                util.log(color(message[item]));
            }
        }
    } else {
        util.log(color(message));
    }
}

// Returns message in ' quotes and cyan.
function quote(message) {
    return '\'' + util.colors.cyan(message) + '\'';
}

// Logs a task is starting
//
// e.g. starting('Compiling', './solution') => Compiling './solution'...
function starting(action, what) {
    info(action.trim() + ' ' + quote(what) + '...');
}
