# 튜토리얼

## 솔루션 설정
- [x] SDK 버전
- [x] Directory.Build.props
- [x] Directory.Package.props
  ```
  !--#if (!UseApiOnly)-->
  ```
  - https://github.com/jasontaylordev/CleanArchitecture/blob/main/Directory.Packages.props
- [ ] .editorconfig
  ```
  dotnet tool install -g dotnet-format --version "8.*" --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet8/nuget/v3/index.json
  dotnet format --verify-no-changes
  ```
- [ ] .template.config
- [ ] .nuspec
---
- [ ] 소스 연동(GitVersion?)