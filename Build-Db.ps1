#
# 새 Migration 생성
#
# Write-Host "Migrations add" -ForegroundColor Yellow
# dotnet ef migrations add {메시지} -p .\src\ArchDdd.Adapters.Persistence\

#
# Database 업데이트
#
# Write-Host "Database update" -ForegroundColor Yellow
# dotnet ef database update -p .\src\ArchDdd.Adapters.Persistence\

#--------------------------------------------------------

#
# database 롤백
#
# dotnet ef migrations list -p .\src\ArchDdd.Adapters.Persistence\
# dotnet ef database update {migrations 이름} -p .\src\ArchDdd.Adapters.Persistence\
# dotnet ef migrations remove -p .\src\ArchDdd.Adapters.Persistence\

#
# migrations 롤백
#
# dotnet ef migrations list -p .\src\ArchDdd.Adapters.Persistence\
# dotnet ef migrations remove -p .\src\ArchDdd.Adapters.Persistence\


# dotnet ef migrations add Init -p .\ArchDdd.Adapters.Persistence\ -o Migrations\Sqlite
#
# # migrations 목록을 출력합니다.
# dotnet ef migrations list -p .\ArchDdd.Adapters.Persistence\
#     20240623091732_Init (Pending)
#
# # 최근에 추가된 마이그레이션부터 역순으로 하나씩 제거합니다.
# dotnet ef migrations remove -p .\ArchDdd.Adapters.Persistence\
# dotnet ef database update -p .\ArchDdd.Adapters.Persistence\
#
#
#
# Unable to create a 'DbContext' of type ''. 
# The exception 'Unable to resolve service for type 
#     'Microsoft.EntityFrameworkCore.DbContextOptions' while attempting to activate 
#     '{프로젝트}.{클래스}DbContext'.' was thrown while attempting to create an instance.
#
# dotnet ef migrations add {메시지} -p {프로젝트} -o {프로젝트 하위 폴더}
# dotnet ef migrations add Init -p .\ArchDdd.Adapters.Persistence\ -o .\Migrations\Sqlite
#
# .\ArchDdd.Adapters.Persistence\
#     Migrations\
#         Sqlite\
#             {시간}_{메시지}.cs
#             {시간}_{메시지}.Designer.cs
#             {DbContext 클래스}ModelSnapshot.cs
#
# dotnet ef migrations list -p .\ArchDdd.Adapters.Persistence\
#
#
# 20230101010101_InitialCreate\t(Pending)
# ["20230101010101_InitialCreate", "(Pending)"]
# 20230101010101_InitialCreate
#
# dotnet ef migrations list -p .\ArchDdd.Adapters.Persistence\ | `
#     Select-String -Pattern '\(Pending\)$' | `
#     ForEach-Object { $_.Line.Split(" ")[0] } | `
#     Sort-Object | `
#     ForEach-Object {
#         Write-Host "Removing migration: $_";
#         dotnet ef migrations remove -p .\ArchDdd.Adapters.Persistence\ --force;
#         Write-Host;
#     }
# ```

If '0', all migrations will be reverted. Defaults to the last migration.
0은 데이터베이스를 모든 migrations가 적용되기 전의 초기 상태로 되돌리는 데 사용됩니다.


