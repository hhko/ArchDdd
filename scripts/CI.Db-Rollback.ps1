# .\CI.Db-Update.ps1
# .\CI.Db-Update.ps1 -p ".\..\src\Migrators\Migrators.Sqlite\"

param(
    [Alias("p", "project")]
    [string]$projectPath = ".\..\src\Migrators\Migrators.Sqlite\",

    [Alias("m", "msg")]
    [string]$message
)

dotnet ef database update $message --project $projectPath
if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to update($message) database. Stopping script."
    break
} else {
    Write-Host "Successfully update($message) database."
}

dotnet ef migrations list --project $projectPath