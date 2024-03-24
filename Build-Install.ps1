# 패키지 ID                              버전           명령
# --------------------------------------------------------------------
# dotnet-coverage                        17.9.6        dotnet-coverage
# dotnet-reportgenerator-globaltool      5.2.0         reportgenerator

dotnet tool install --global dotnet-coverage --version 17.9.6
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.2.0
dotnet tool install --global dotnet-format --version 5.1.250801

# nodejs 설치
# create-docusaurus 버전 확인
#   npm show create-docusaurus versions
# create-docusaurus 생성
#   npx --yes create-docusaurus@3.1.1 docs classic --typescript

dotnet tool list --global