@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Java\bin\Release\Panosen.CodeDom.Java.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.Java.Engine\bin\Release\Panosen.CodeDom.Java.Engine.*.nupkg D:\LocalSavoryNuget\

pause