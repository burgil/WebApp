@ECHO OFF
"%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe" -latest -prerelease -products * -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe > MSBuild-CSharp.TEMP
FOR /f "delims=" %%x IN (MSBuild-CSharp.TEMP) DO SET MSBuild=%%x
DEL MSBuild-CSharp.TEMP
CALL "%MSBuild%" BackEnd\CSharp\WebApp.sln
TIMEOUT 60