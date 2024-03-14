# 기본 경로
$sln_dir            = split-path -parent $MyInvocation.MyCommand.Definition
$sln_path           = Join-Path $sln_dir "CleanDdd.sln"
$testresults_dir    = Join-Path $sln_dir "testresults"
$coverage_dir       = Join-Path $testresults_dir "coverage"
$coverage_path      = Join-Path $coverage_dir "coverage.cobertura.merged.xml"

#
# 준비
#   - **/testresults 모든 폴더 삭제
#   - ./testresults/coverage 폴더 생성
(Get-ChildItem -Path $sln_dir -Directory -Recurse -Filter "testresults").FullName | ForEach-Object { Write-Output $_; Remove-Item $_ -Recurse -Force }
New-Item $coverage_dir -ItemType Directory -Force | Out-Null

#
# 솔루션 빌드
#
dotnet restore $sln_path
dotnet build $sln_path `
    --no-restore `
    --configuration Release `
    --verbosity m

#
# 솔루션 테스트
#

# {테스트 프로젝트}
#   ├─.csproj
#   └─TestResults
#       ├─0ca60e99-32fb-43ac-bbd3-01f5a5ef6886        : XPlat Code Coverage 폴더
#       │   └─coverage.cobertura.xml                  : 코드 커버리지 파일(병합 대상)
#       ├─{username}_{hostname}_2024-03-14_15_16_30   : trx 로그 폴더
#       │   └─In
#       │       └─{hostname}
#       │           └─coverage.cobertura.xml          : 코드 커버리지 파일(사용 안함)
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
#   ├─.sln
#   └─testresults
#       └─coverage
#           └─coverage.cobertura.merged.xml
dotnet-coverage merge "**/testresults/*/*.cobertura.xml" `
    -f cobertura `
    -o $coverage_path

#
# 솔루션 코드 커버리지 보고서
#

# {솔루션}
#   ├─.sln
#   └─testresults
#       ├─coverage
#       │   └─coverage.cobertura.merged.xml
#       └─report
#           ├─ ...
#           └─SummaryGithub.md
reportgenerator `
    -reports:$coverage_path `
    -targetdir:(Join-Path $coverage_dir "report") `
    -reporttypes:"Html;Badges;MarkdownSummaryGithub" `
    -verbosity:Info