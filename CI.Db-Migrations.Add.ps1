# .\CI.Build-Migrations.Add.ps1
# .\CI.Build-Migrations.Add.ps1 -m "Init"
# .\CI.Build-Migrations.Add.ps1 -p ".\src\Migrators\Migrators.Sqlite\" -m "Init"

# message은 공백없이 입력합니다.
# 예.
#   NxM-User_x_Role

param(
    [Alias("p", "project")]
    [string]$projectPath = ".\src\Migrators\Migrators.Sqlite\",

    [Alias("m", "msg")]
    [string]$message
)

dotnet ef migrations add $message --project $projectPath
if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to add migration. Stopping script."
    break
} else {
    Write-Host "Successfully add migration."
}

dotnet ef migrations list --project $projectPath