
## 1. Required one-to-one
```shell
dotnet ef migrations add Init -p .\OneToOne_01
dotnet ef database update -p .\OneToOne_01

siren-gen `
    ".\OneToOne_01\bin\Debug\net8.0\OneToOne_01.dll" `
    ".\OneToOne_01\ERD.md"
```

## 2. Required one-to-one with primary key to primary key relationship
```shell
dotnet ef migrations add Init -p .\OneToOne_02_PrimaryKeyToPrimaryKey
dotnet ef database update -p .\OneToOne_02_PrimaryKeyToPrimaryKey

siren-gen `
    ".\OneToOne_02_PrimaryKeyToPrimaryKey\bin\Debug\net8.0\OneToOne_02_PrimaryKeyToPrimaryKey.dll" `
    ".\OneToOne_02_PrimaryKeyToPrimaryKey\ERD.md"
```

## 3. Required one-to-one with shadow foreign key
```shell
dotnet ef migrations add Init -p .\OneToOne_03_ShadowForeignKey
dotnet ef database update -p .\OneToOne_03_ShadowForeignKey

siren-gen `
    ".\OneToOne_03_ShadowForeignKey\bin\Debug\net8.0\OneToOne_03_ShadowForeignKey.dll" `
    ".\OneToOne_03_ShadowForeignKey\ERD.md"
```
```
# AarchDdd
siren-gen `
    "C:\Workspace\Github\ArchDdd\src\Migrators\Migrators.Sqlite\bin\Debug\net8.0\Migrators.Sqlite.dll" `
    "C:\Workspace\Github\ArchDdd\src\Migrators\Migrators.Sqlite\ERD.md"

# DDD
siren-gen `
    "C:\Workspace\Github\DomainDrivenDesignUniversity\bin\Debug\Shopway.Persistence.dll" `
    "C:\Workspace\Github\DomainDrivenDesignUniversity\ERD.md"
```