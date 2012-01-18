@ECHO off
cls

set User=%1%
set Password=%2%
set DBchoice=%3%
set pathchoice=%4%
set hostIP=%5%
set toolPath=%6%

@REM Remove double quotes from the path
@REM SET pathchoice=%pathchoice:"=%
@REM SET pathchoice=%pathchoice:"=%

%toolPath%\mysql -u %User% -h%hostIP% --password=%Password% %DBchoice% < %pathchoice%