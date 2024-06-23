#
# 새 Migration 생성
#
# Write-Host "Migrations add" -ForegroundColor Yellow
# dotnet ef migrations add {주제} -p .\src\ArchDdd.Adapters.Persistence\

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


Unable to create a 'DbContext' of type ''. 
The exception 'Unable to resolve service for type 
    'Microsoft.EntityFrameworkCore.DbContextOptions' while attempting to activate 
    '{프로젝트}.{클래스}DbContext'.' was thrown while attempting to create an instance.