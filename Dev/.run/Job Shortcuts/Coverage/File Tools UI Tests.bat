mkdir "%~dp0..\..\..\..\bin\AcceptanceTesting"
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -RetryRebuild -Projects Warewolf.UI.Tests -Category File Tools -PreTestRunScript 'StartAs.ps1 -Cleanup -Anonymous -ResourcesPath UITests' -PostTestRunScript 'ReverseDeployLog.ps1' -Coverage