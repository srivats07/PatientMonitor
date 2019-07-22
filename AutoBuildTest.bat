@echo off
set "BAT_PATH=%~dp0"



@echo off

call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat"
echo %BAT_PATH%
echo Executing batch file
:: param1 =     certificate hash for cash microservice : default no certificate
:: param2 =     Build Type: default Debug, Range: Debug or Release
::Win32
::              To Make it to work open BranchConfiguration.json then set the value of "name": "BranchProfile" 
::              to as per Build Type like, "value": "Release" or "value": "Debug", By default the vlaue is debug
::X64
::              To Make it to work open BranchConfiguration64.json then set the value of "name": "BranchProfile" 
::              to as per Build Type like, "value": "Release" or "value": "Debug", By default the vlaue is debug
:: param3 =     Infra Compiling: default: build, Range: nobuild OR build
:: param4 =     Platform: default: x64 or Win32, Range: Win32 OR x64
devenv "%BAT_PATH%\Alerting.sln" /build Release 
echo.


pushd %BAT_PATH%Alerting\Alerting\Bin\Release
start %BAT_PATH%\Alerting\Bin\Release\Alerting.exe