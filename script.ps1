param(
	[string]$serviceName,
	[string]$projectPath="C:\FCC-SEU\Projects\PocWorkServiceWebApi\PocWorkServiceWebApi\PocWorkServiceWebApi.csproj",
	[string]$outputPath="C:\FCC-SEU\Projects\PocWorkServiceWebApi\PocWorkServiceWebApi\bin\Release\net8.0"
)
Write-Host "Project Path: $projectPath"
Write-Host "Service Name: $serviceName"
Write-Host "Output Path: $outputPath"

dotnet publish $projectPath -c Release -o $outputPath

$exePath = Join-Path $outputPath "PocWorkServiceWebApi.exe"


Write-Host "Creating the windows service for exe $exePath"
sc.exe create $serviceName binPath= $exePath start= auto

Write-Host "Starting the Windows service..."
sc.exe start $serviceName

Write-Host "Service '$serviceName' has been created and started successfully."

