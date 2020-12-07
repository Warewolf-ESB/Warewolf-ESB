powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -File "%~dp0..\..\..\..\Compile.ps1" -AcceptanceTesting -SolutionWideOutputs
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -Projects Dev2.*.Tests,Warewolf.*.Tests,Warewolf.UIBindingTests.* -ExcludeProjects Dev2.Infrastructure.Tests,Dev2.Integration.Tests,Warewolf.UI.Tests,Warewolf.Auditing.Tests,Warewolf.Studio.ViewModels.Tests,Warewolf.Web.UI.Tests,Warewolf.Storage.Tests,Warewolf.UIBindingTests.ComPluginSource -Coverage -RunInDocker