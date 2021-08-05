dotnet restore

dotnet build --no-restore -c Debug

copy-pdb-to-nuget debug

copy Panosen.CodeDom.Java.Engine\bin\Debug\net472\Panosen.CodeDom.Java.dll D:\Github\harris2012\elasticsearch\packages\Panosen.CodeDom.Java.0.1.0\lib\net472\Panosen.CodeDom.Java.dll

copy Panosen.CodeDom.Java.Engine\bin\Debug\net472\Panosen.CodeDom.Java.Engine.dll D:\Github\harris2012\elasticsearch\packages\Panosen.CodeDom.Java.Engine.0.1.0\lib\net472\Panosen.CodeDom.Java.Engine.dll

pause
