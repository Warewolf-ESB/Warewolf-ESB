powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -File "%~dp0..\..\..\..\Compile.ps1" -AcceptanceTesting -InDockerContainer
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -Projects Dev2.*.Specs,Warewolf.*.Specs -ExcludeProjects Dev2.Activities.Specs,Warewolf.Tools.Specs,Warewolf.UI.Specs,Warewolf.UI.Load.Specs -Category ConflictingContributeViewExecutePermissionsSecurity -PreTestRunScript "StartAs.ps1 -Cleanup -Anonymous -ResourcesPath ServerTests" -Coverage -RunInDocker