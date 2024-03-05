# 튜토리얼

## 1. 솔루션 구성
### 1. 솔루션 설정
- [x] 1. [`global.json` .NET SDK 버전 지정하기](./001-SolutionSetting/01-SdkVersion/)
- [x] 2. [`Directory.Build.props` 빌드 중앙 관라히기](./001-SolutionSetting/02-BuildProps/)
- [x] 3. [`Directory.Packages.props` 패키지 중앙 관리하기](./001-SolutionSetting/03-PackagesProps/)
- [x] 4. [`.template.config` 템플릿 생성하기](./001-SolutionSetting/04-Template/)
- [x] 5. [`.nuspec` 템플릿 배포하기](./001-SolutionSetting/05-TemplatePackage/)
- [ ] 6. DocFx
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

### 2. 컨테이너화
- 솔루션
- docfx
- 디버깅
  - linux 파일 생성?

### 3. CI/CD
- loca
- github actions
- 코드 커버리지
- format

### 4. 관측 시스템
- 로그
- 자원
  - 운영체제
  - 컨테이너
  - .NET
- 헬스체크

## 2. 솔루션 ?
### 1. 설정
### 2. DI
### 3. Pipeline(Behavior)

## 3. 도메인
### 1. 기본 타입
- Result
- ValidationResult