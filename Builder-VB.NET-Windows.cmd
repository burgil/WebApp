@ECHO OFF
"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -latest -prerelease -products * -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe > MSBuild-VB.NET.TEMP
FOR /f "delims=" %%x IN (MSBuild-VB.NET.TEMP) DO SET MSBuild=%%x
DEL MSBuild-VB.NET.TEMP
CALL "%MSBuild%" BackEnd\VB.NET\WebApp.sln
TIMEOUT 60