param(
    [string]$param
)
$param = $param.ToLower()

$root_dir = split-path -parent $MyInvocation.MyCommand.Definition
$packages = Get-Content -Path "Packages-Remove.txt"

foreach ($packageName in $packages) {
    Write-Output "$packageName"
}

$project_dirs = @()
if ($param -ieq "tests") {
    $project_dirs = Get-ChildItem -Path (Join-Path $root_dir "..\..\") -Recurse -Filter *.csproj -Include *.Tests.* -ErrorAction SilentlyContinue
}
else {
    $project_dirs = Get-ChildItem -Path (Join-Path $root_dir "..\..\") -Recurse -Filter *.csproj -Exclude *.Tests.* -ErrorAction SilentlyContinue
}

$project_dirs | ForEach-Object {
    foreach ($packageName in $packages) {
        dotnet remove "$($_.FullName)" package $packageName
    }
}