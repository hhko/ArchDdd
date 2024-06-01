---
sidebar_position: 6
---

# EFCore

ORM(Object Relational Mapping)

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
```

```

dotnet ef migrations list -p .\src\ArchDdd.Adapters.Persistence\
  Build started...
  Build succeeded.
  20240526223353_init
  20240531232626_Refactor_IAuditable
dotnet ef database update 20240526223353_init -p .\src\ArchDdd.Adapters.Persistence\
  Build started...
  Build succeeded.
  Reverting migration '20240531232626_Refactor_IAuditable'.
  Done.

dotnet ef migrations remove -p .\src\ArchDdd.Adapters.Persistence\
  Build started...
  Build succeeded.
  The entity type 'User' is configured to use schema 'Master', but SQLite does not support schemas. This configuration will be ignored by the SQLite provider.
  Removing migration '20240531232626_Refactor_IAuditable'.
  Reverting the model snapshot.
  Done.
```
```powershell
# Migrations 스크립트 생성
dotnet ef migrations add init -p .\src\ArchDdd.Adapters.Persistence\
    Build started...
    Build succeeded.
    The entity type 'User' is configured to use schema 'Master', but SQLite does not support schemas.
        This configuration will be ignored by the SQLite provider.
        Done. To undo this action, use 'ef migrations remove'

  지정한 프로젝트에 "Migrations" 폴더와 관련 파일을 생성합니다.

# 데이터베이스 생성
dotnet ef database update -p .\src\ArchDdd.Adapters.Persistence\
    Build started...
    Build succeeded.
    Applying migration '20240526223353_init'.
    Done.

  지정한 프로젝트에 "ArchDddDb.db" 파일을 생성합니다.
```

```powershell
# arguments 1개 전달
// args[0] = "arg0 arg0"
dotnet ef migrations add init -p .\src\ArchDdd.Adapters.Persistence\ -- "arg0 arg0"

# arguments N개 전달
// args[0] = arg0
// args[1] = arg1
dotnet ef migrations add init -p .\src\ArchDdd.Adapters.Persistence\ -- arg0 arg1
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
  -p|--project <PROJECT>                 The project to use. Defaults to the current working directory.
  --no-build                             Don't build the project. Intended to be used when the build is up-to-date.
  --configuration <CONFIGURATION>        The configuration to use.


  -o|--output-dir <PATH>                 The directory to put files in. Paths are relative to the project directory. Defaults to "Migrations".
  --json                                 Show JSON output. Use with --prefix-output to parse programatically.
  -n|--namespace <NAMESPACE>             The namespace to use. Matches the directory by default.
  -c|--context <DBCONTEXT>               The DbContext to use.
  -s|--startup-project <PROJECT>         The startup project to use. Defaults to the current working directory.
  --framework <FRAMEWORK>                The target framework. Defaults to the first one in the project.
  --runtime <RUNTIME_IDENTIFIER>         The runtime to use.
  --msbuildprojectextensionspath <PATH>  The MSBuild project extensions path. Defaults to "obj".
  -h|--help                              Show help information
  -v|--verbose                           Show verbose output.
  --no-color                             Don't colorize output.
  --prefix-output                        Prefix output with level.
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