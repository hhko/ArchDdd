# .\CI.Db-Migrations.List.ps1
# .\CI.Db-Migrations.List.ps1 -p ".\..\src\Migrators\Migrators.Sqlite\"

param(
    [Alias("p", "project")]
    [string]$projectPath = ".\..\src\Migrators\Migrators.Sqlite\"
)

dotnet ef migrations list --project $projectPath