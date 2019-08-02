@echo off
set "BAT_PATH=%~dp0"



@echo off


call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat"

echo %BAT_PATH%

echo Executing batch file

:: param1 =     certificate hash for cash microservice : default no certificate

:: param2 =     Build Type: default Debug, Range: Debug or Release
::Win32
::              
:: To Make it to work open BranchConfiguration.json then set the value of "name": "BranchProfile" 

::              to as per Build Type like, "value": "Release" or "value": "Debug", By default the vlaue is debug
::X64

::              To Make it to work open BranchConfiguration64.json then set the value of "name": "BranchProfile" 

::              to as per Build Type like, "value": "Release" or "value": "Debug", By default the vlaue is debug

:: param3 =     Infra Compiling: default: build, Range: nobuild OR build
:: param4 =     Platform: default: x64 or Win32, Range: Win32 OR x64

devenv "%BAT_PATH%\Alerting.sln" /build Debug 
pause
mstest /TestContainer:"%BAT_PATH%PatientMoniterTest\bin\Debug\PatientMoniterTest.dll" /Test:TestParameters /Test:TestSpo2Valid /Test:TestTempValid /Test:TestPulseValid /Test:TestSpo2BoundaryMinus1 /Test:TestTempBoundaryMinus1 /Test:TestPulseBoundaryMinus1 /Test:TestSpo2BoundaryZero /Test:TestTempBoundaryZero /Test:TestPulseBoundaryZero /Test:TestSpo2BoundaryPlus1 /Test:TestTempBoundaryPlus1 /Test:TestPulseBoundaryPlus1 /Test:TestSpo2Invalid /Test:TestTempInvalid /Test:TestPulseInvalid
pause
 

echo.


call %BAT_PATH%JsonGenerator\bin\Debug\JsonGenerator.exe | %BAT_PATH%Alerting\bin\Debug\Alerting.exe 

pause