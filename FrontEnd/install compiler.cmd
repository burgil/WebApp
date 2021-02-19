@echo off
call npm init
call npm install eslint --save-dev
call .\node_modules\.bin\eslint --init
echo =================
echo More information can be found on the next screen:
echo =================
pause
cls
echo =================
echo To update the configuration file, use this command on the root folder of your project:
echo npx eslint --init
echo =================
echo To run ESLint on a file or a directory, use this command:
echo npx eslint c:\Projects\MyProject
echo npx eslint c:\Projects\MyProject\yourfile.js
echo cd c:\Projects\MyProject
echo npx eslint yourfile.js
echo =================
pause