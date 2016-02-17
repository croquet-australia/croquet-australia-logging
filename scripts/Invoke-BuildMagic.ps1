param (
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [string]
    $Command  
)

$ErrorActionPreference = "Stop"
$WarningPreference = "SilentlyContinue"
$VerbosePreference = "SilentlyContinue"

Import-Module "$PSScriptRoot\..\submodules\BuildMagic\BuildMagic.psm1"

switch ($Command) {
    "clean" { Invoke-CleanSolution -Configuration $env:npm_config_msbuild_configuration -Verbosity $env:npm_config_msbuild_verbosity }
    "compile" { Invoke-CompileSolution -Configuration $env:npm_config_msbuild_configuration -Verbosity $env:npm_config_msbuild_verbosity }
    "install-dependencies" { Install-NuGetPackages }
    "test" { Invoke-TestSolution -Configuration $env:npm_config_msbuild_configuration }
    Default { throw "Command '$command' is not supported." }
}