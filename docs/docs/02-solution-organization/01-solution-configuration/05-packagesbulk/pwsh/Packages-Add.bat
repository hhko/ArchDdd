@echo off

REM Tests 프로젝트에 패키지 추가할 때
set param=Tests

REM Src 프로젝트에 패키지 추가할 때
REM set param=

powershell -File "./Packages-Add.ps1" "%param%"

pause