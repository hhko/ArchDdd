---
sidebar_position: 6
---

# EFCore

> ORM(Object Relational Mapping)

```powershell
# Microsoft.EntityFrameworkCore.Design

# 도구 설치
dotnet tool install --global dotnet-ef

# 도구 업데이트
dotnet tool update --global dotnet-ef

dotnet tool list -g
dotnet-ef --version
```

```powershell
# ef tool 사용을 위한 패키지
Microsoft.EntityFrameworkCore.Design

# Migrations 팩토링 클래스
IDesignTimeDbContextFactory

# Migrations 스크립트 생성
dotnet ef migrations add init -p .\ArchDdd.Adapters.Persistence\
    Build started...
    Build succeeded.
    The entity type 'User' is configured to use schema 'Master', but SQLite does not support schemas. 
        This configuration will be ignored by the SQLite provider.
        Done. To undo this action, use 'ef migrations remove'

# 데이터베이스 생성
dotnet ef database update -p .\ArchDdd.Adapters.Persistence\
    Build started...
    Build succeeded.
    Applying migration '20240526223353_init'.
    Done.

    ArchDddDb.db 파일 생성
```

```powershell
dotnet ef database update
dotnet ef database update -- --environment Production
```
```powershell
Usage: dotnet ef migrations add [arguments] [options]

Arguments:
  <NAME>  The name of the migration.

Options:
  -o|--output-dir <PATH>                 The directory to put files in. Paths are relative to the project directory. Defaults to "Migrations".
  -p|--project <PROJECT>                 The project to use. Defaults to the current working directory.
```

```powershell
dotnet ef database drop
dotnet ef database update
dotnet ef database update -- --environment Production
dotnet ef database update 20180904195021_InitialCreate --connection your_connection_string

dotnet ef dbcontext info
dotnet ef dbcontext list
dotnet ef dbcontext optimize
dotnet ef dbcontext scaffold
dotnet ef dbcontext script

dotnet ef migrations add
dotnet ef migrations bundle
dotnet ef migrations has-pending-model-changes
dotnet ef migrations list
dotnet ef migrations remove
dotnet ef migrations script
```