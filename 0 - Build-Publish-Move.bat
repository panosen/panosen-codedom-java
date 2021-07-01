@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Java\bin\Release\Panosen.CodeDom.Java.*.nupkg D:\LocalSavoryNuget\

pause