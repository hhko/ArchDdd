# 패키지 ID                              버전           명령
# --------------------------------------------------------------------
# dotnet-coverage                        17.9.6        dotnet-coverage
# dotnet-reportgenerator-globaltool      5.2.0         reportgenerator

# testresults\                                      // dotnet test 결과
#   codecoverage\                                   // 코드 커버리지
#       19f5be57-f7f1-4902-a22d-ca2dcd8fdc7a\       // dotnet test 프로젝트 1개 결과
#            coverage.cobertura.xml
#       ed0ebd65-448e-4cfc-9f8f-21ea450effc5\       // dotnet test 프로젝트 1개 결과
#            coverage.cobertura.xml
#       coverage.cobertura.merged.xml               // dotnet test 프로젝트 N개 통합 결과
#       report                                      // 코드 커버리지 보고서: Html, Badges, Markdown
#           ...

$solution_file = "CleanDdd.sln"
$current_dir = split-path -parent $MyInvocation.MyCommand.Definition
$solution_path = Join-Path $current_dir $solution_file
$codecoverage_dir = Join-Path $current_dir "testresults" "codecoverage"
$codecoverage_path = Join-Path $codecoverage_dir "coverage.cobertura.merged.xml"

# 솔루션 파일 경로 출력
Write-Output $("Solution Path: " + $solution_path)

# 이전 테스트 결과 정리(TestResults 폴더 정리)
if (Test-Path -Path $codecoverage_dir) {
    Remove-Item -Path (Join-Path $codecoverage_dir "*") -Recurse -Force
}

# 솔루션 패키지 복원
dotnet restore $solution_path

# 솔루션 빌드
dotnet build $solution_path `
    --no-restore `
    --configuration Release `
    --verbosity m

# 솔루션 테스트
dotnet test $solution_path `
    --configuration Release `
    --results-directory $codecoverage_dir `
    --no-build `
    --collect "XPlat Code Coverage" `
    --verbosity normal

# 솔루션 코드 커버지리 통합
dotnet-coverage merge (Join-Path $codecoverage_dir "**/*.cobertura.xml") `
    -f cobertura `
    -o $codecoverage_path

# 솔루션 코드 커버리지 보고서 생성
reportgenerator `
	-reports:$codecoverage_path `
	-targetdir:(Join-Path $codecoverage_dir "report") `
	-reporttypes:"Html;Badges;MarkdownSummaryGithub" `
    -verbosity:Info