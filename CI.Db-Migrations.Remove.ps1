# .\CI.Build-Migrations.Remove.ps1
# .\CI.Build-Migrations.Remove.ps1 -n 3
# .\CI.Build-Migrations.Remove.ps1 -p ".\src\Migrators\Migrators.Sqlite\" -n 3

param(
    [Alias("p", "project")]
    [string]$projectPath = ".\src\Migrators\Migrators.Sqlite\",

    [Alias("n", "number")]
    [int]$numOfMigrationsToRemove = 1
)

for ($i = 0; $i -lt $numOfMigrationsToRemove; $i++) {
    dotnet ef migrations remove --project $projectPath -f
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Failed to remove migration. Stopping script."
        break
    } else {
        Write-Host "Successfully removed migration $($i + 1)."
    }
}

dotnet ef migrations list --project $projectPath