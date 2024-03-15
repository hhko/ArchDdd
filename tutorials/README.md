# 튜토리얼

## 1. 솔루션 구성
### 1. 솔루션 설정
- [x] 1. [프로젝트 레이어 구성](./01-SolutionSetting/01-SolutionConfig/01-Layer/)
- [x] 2. [.NET SDK 버전 지정하기: `global.json`](./01-SolutionSetting/01-SolutionConfig/02-SdkVersion/)
- [x] 3. [빌드 중앙 관라히기: `Directory.Build.props`](./01-SolutionSetting/01-SolutionConfig/03-BuildProps/)
- [x] 4.1 [패키지 중앙 관리하기: `Directory.Packages.props`, `nuget.config`](./01-SolutionSetting/01-SolutionConfig/04.1-PackagesProps/)
- [x] 4.2 [패키지 Bulk 추가/제거하기](./01-SolutionSetting/01-SolutionConfig/04.2-PackagesBulk/)
- [x] 5. [문서화하기: `docfx`](./01-SolutionSetting/01-SolutionConfig/05-Docfx/)
- [ ] 6. 코드 매트릭
- [ ] 6. [코딩 스타일 정의하기: `.eidtorconfig`](./01-SolutionSetting/01-SolutionConfig/06-CodingStyle/)
- [x] 7. [템플릿 만들기: `.template.config`](./01-SolutionSetting/01-SolutionConfig/07-Template/)
- [x] 8. [템플릿 배포하기: `.nuspec`](./01-SolutionSetting/01-SolutionConfig/08-TemplatePackage/)

### 2. 솔루션 CI/CD
| 구분          | Build.ps1 | Actions | Actions 이력 | Actions PR |
|---------|-------|---------|------------|------------|
| 빌드          | O     | O       |            |            |
| 테스트        | O     | O       |            |            |
| 코드 커버리지 | O     | O       |            |            |
| 코드 스타일   |       |         |            |            |
| 코드 매트릭   |       |         |            |            |
| 코드 보안?    |       |         |            |            |
| 코드 문서화   |       |         |            |            |
| Release       | X     |         | X          | X          |

### 3. 솔루션 배포
- 컨테이너화
  - 솔루션
  - docfx
  - opensearch
- 컨테이너 디버깅
  - linux 파일 생성?

### 4. 솔루션 관측 시스템
- 로그
- 자원
  - 운영체제
  - 컨테이너
  - .NET
- 헬스체크

## 2. ?
### 1. 설정
- 실행
### 2. DI
### 3. Pipeline(Behavior)

## 3. 도메인
### 1. 기본 타입
- Result
- ValidationResult

### 2. 사용 시나리오