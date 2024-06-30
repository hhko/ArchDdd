# .\CI.Db-Update.ps1
# .\CI.Db-Update.ps1 -p ".\src\Migrators\Migrators.Sqlite\"

param(
    [Alias("p", "project")]
    [string]$projectPath = ".\src\Migrators\Migrators.Sqlite\"
)

dotnet ef database update --project $projectPath
if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to update database. Stopping script."
    break
} else {
    Write-Host "Successfully update database."
}

dotnet ef migrations list --project $projectPath