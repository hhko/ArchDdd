# # ----------------------
# # migrations 조회
# # ----------------------

# dotnet ef migrations list -p .\src\Migrators\Migrators.Sqlite\

# #  Build started...
# #  Build succeeded.
# #    20240602145704_init
# #    20240629062941_Add1 (Pending)

# # ----------------------
# # migrations 추가
# # ----------------------

# dotnet ef migrations add Init -p .\src\Migrators\Migrators.Sqlite\

# # IDesignTimeDbContextFactory<ArchDddDbContext>
# #     new ArchDddDbContext
# #
# # --> ArchDddDbContext
# #     protected override void OnModelCreating(ModelBuilder builder)
# #     {
# #         // IEntityTypeConfiguration 모든 클래스
# #         builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
# #     }
# #
# # --> N개: ... : : IEntityTypeConfiguration<User>

# # -- 구성 --
# #   프로젝트\
# #     Migrations\
# #       {시간}_{메시지}.cs
# #       {시간}_{메시지}.Designer.cs
# #       {DbContext 클래스}ModelSnapshot.cs
# #
# # -- 사례 --
# #   Migrators.Sqlite\
# #     Migrations\
# #       20240602145704_init.cs
# #       20240602145704_init.Designer.cs
# #       ArchDddDbContextModelSnapshot.cs
# #     ArchDdd.db                          <-- Sqlite 파일

# # ----------------------
# # database 목록 조회
# # ----------------------

# # (Pending) 중인 모든 Migrations을 데이터베이스에 업데이트합니다.
# dotnet ef database update -p .\src\Migrators\Migrators.Sqlite\

# # ----------------------
# # rollback 목록 조회
# # ----------------------

# ```
# #
# # Database
# #

# # Database 특정 Rollback
# dotnet ef database update {Migration_이름} -p .\src\Migrators\Migrators.Sqlite\

# # __EFMigrationHistory
# #   MigrationId             <-- Migration_이름
# #   ProductVersion

# # Database 전체 Rollback
# dotnet ef database update 0 -p .\src\Migrators\Migrators.Sqlite\

# #
# # Migration
# #

# # Migration Rollback
# #   한번에 한개 migration만 삭제 가능합니다.
# dotnet ef migrations remove -p .\src\Migrators\Migrators.Sqlite\
# ```



########################################################










# 버전 테이블 이름 변경
#   https://learn.microsoft.com/ko-kr/ef/core/managing-schemas/migrations/history-table
#   https://www.codeproject.com/Articles/5338891/Customize-Entity-Framework-Core-Migration-History
#   https://www.learnentityframeworkcore.com/migrations


# exe 배포할 때 .db 파일?


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

# If '0', all migrations will be reverted. Defaults to the last migration.
# 0은 데이터베이스를 모든 migrations가 적용되기 전의 초기 상태로 되돌리는 데 사용됩니다.