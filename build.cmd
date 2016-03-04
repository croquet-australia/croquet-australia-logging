@echo off
rem ---------------------------------------------------------------------------
rem Builds croquet-australia-logging. See :help section for more details.
rem ---------------------------------------------------------------------------
pushd %~dp0

if "%1" == "-h" goto help
if "%1" == "/h" goto help
if "%1" == "/?" goto help
if "%1" == "-?" goto help
if "%1" == "--help" goto help

if not exist .\node_modules (
    echo Installing node packages...    
    call npm install --no-optional

    if not "%errorlevel%" == "0" (
        echo Failed to install node packages.
        goto finally
    )
     
    echo Successfully installed node packages.
)

call gulp --gulpfile .\build\tasks.js --cwd .\ %* 
goto finally

:help
echo.
echo Builds croquet-australia-logging.
echo.
echo Usage: build [task]
echo.
echo Where [task] is one of the following:
echo.
call gulp --gulpfile .\build\tasks.js --cwd .\ --tasks-simple
echo.
echo If [task] is not specified then the default task is used.
echo.
echo To learn more about each task see .\build\tasks.js.
echo.
echo Sub-tasks are indicated by {task}:{subtask}.
echo.

:finally
exit /b %errorlevel%