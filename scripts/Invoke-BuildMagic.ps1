param (
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
    [string]
    $Command  
)

$global:ErrorActionPreference = "Stop"
$global:WarningPreference = "SilentlyContinue"
$global:VerbosePreference = "SilentlyContinue"

try {    
    Import-Module "$PSScriptRoot\..\submodules\BuildMagic\BuildMagic.psm1" -Force

    switch ($Command) {
        "clean" { Invoke-CleanSolution -Configuration $env:npm_config_msbuild_configuration -Verbosity $env:npm_config_msbuild_verbosity }
        "compile" { Invoke-CompileSolution -Configuration $env:npm_config_msbuild_configuration -Verbosity $env:npm_config_msbuild_verbosity }
        "install-dependencies" { Install-NuGetPackages }
        "test" { Invoke-TestSolution -Configuration $env:npm_config_msbuild_configuration }
        Default { throw "Command '$command' is not supported." }
    }
}
catch {
    # 26 Feb 2016. Windows Server 2012 R2 requires this catch statement otherwise this script exits with 0.
    Write-Host     
	Write-Host $_ -ForegroundColor Red
    Write-Host
	exit $lastexitcode
}

exit 0