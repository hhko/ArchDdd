# 튜토리얼

## 1. 솔루션 설정
- [x] [`global.json` .NET SDK 버전 지정하기](./001-SolutionSetting/01-SdkVersion/)
- [x] [`Directory.Build.props` 빌드 중앙 관라히기](./001-SolutionSetting/02-BuildProps/)
- [x] [`Directory.Packages.props` 패키지 중앙 관리하기](./001-SolutionSetting/03-PackagesProps/)
  - TODO 옵션: `#if (!UseApiOnly)`
  - TODO 소스: https://github.com/jasontaylordev/CleanArchitecture/blob/main/Directory.Packages.props
- [x] [`.template.config` 템플릿 생성하기](./001-SolutionSetting/04-Template/)
- [x] [`.nuspec` 템플릿 배포하기](./001-SolutionSetting/05-TemplatePackage/)
- [ ] DocFx
---
- [ ] .editorconfig
  ```
  dotnet tool install -g dotnet-format --version "8.*" --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet8/nuget/v3/index.json
  dotnet format --verify-no-changes
  ```
- [ ] StyleCop
---
- [ ] 소스 연동(GitVersion?)
- [ ] .gitattributes
- [ ] .dockerignore