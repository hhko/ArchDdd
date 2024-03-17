# 기본 경로
$sln_dir        = split-path -parent $MyInvocation.MyCommand.Definition
$sln_path       = Join-Path $sln_dir "CleanDdd.sln"
$results_dir    = Join-Path $sln_dir ".results"
$coverage_dir   = Join-Path $results_dir "coverage"
$coverage_path  = Join-Path $coverage_dir "coverage.cobertura.merged.xml"
$doc_dir        = Join-Path $sln_dir "site"

#
# 준비
#   - **/TestResults 모든 폴더 삭제
#   - ./.results/coverage 폴더 생성
#(Get-ChildItem -Path $sln_dir -Directory -Recurse -Filter "TestResults").FullName | ForEach-Object { Write-Output $_; Remove-Item $_ -Recurse -Force }
(Get-ChildItem -Path $sln_dir -Directory -Recurse -Filter "TestResults").FullName | ForEach-Object { Write-Output $_; }
New-Item $coverage_dir -ItemType Directory -Force | Out-Null

#
# 솔루션 패키지 복원
#
dotnet restore $sln_path

#
# 솔루션 빌드
#
dotnet build $sln_path `
    --no-restore `
    --configuration Release `
    --verbosity m

if ($LASTEXITCODE -ne 0) {
#if ($LASTEXITCODE -eq 0) {
    Write-Output "Build failed"
    exit 1
}

#
# 솔루션 테스트
#

# {테스트 프로젝트}
#   └─TestResults
#       ├─0ca60e99-32fb-43ac-bbd3-01f5a5ef6886        : XPlat Code Coverage 폴더
#       │   └─coverage.cobertura.xml                  : 코드 커버리지 파일(dotnet-coverage merge 대상)
#       ├─{username}_{hostname}_2024-03-14_15_16_30   : trx 로그 폴더
#       │   └─In
#       │       └─{hostname}
#       │           └─coverage.cobertura.xml          : 코드 커버리지 파일(사용 안함, Junit 로그 생성시 자동 생성됨)
#       └─logs.trx                                    : trx 로그 파일
dotnet test $sln_path `
    --configuration Release `
    --no-build `
    --collect "XPlat Code Coverage" `
    --logger "trx;LogFileName=logs.trx" `
    --verbosity normal

#
# 솔루션 코드 커버리지 병합
#   -o 출력 경로(폴더)는 사전에 명령어 실행 전에 존재해야 합니다(자동 생성되지 않습니다: 실패).

# 솔루션 테스트

# {솔루션}
#  └─.results
#      └─coverage
#           └─coverage.cobertura.merged.xml
dotnet-coverage merge "**/TestResults/*/*.cobertura.xml" `
    -f cobertura `
    -o $coverage_path

#
# 솔루션 코드 커버리지 보고서 생성
#

# {솔루션}
#  └─.results
#      └─coverage
#           ├─coverage.cobertura.merged.xml
#           └─report
#                ├─...
#                └─SummaryGithub.md
reportgenerator `
    -reports:$coverage_path `
    -targetdir:(Join-Path $coverage_dir "report") `
    -reporttypes:"Html;Badges;MarkdownSummaryGithub" `
    -verbosity:Info

#
# 문서 빌드
#

# {솔루션}
#  └─site
#      ├─...
#      └─docfx.json
docfx (Join-Path $doc_dir docfx.json)