# 솔루션 빌드를 위한 .NET SDK 버전 지정하기

## .NET SDK 버전 체계
```
x.y.znn

x   Major      latestMajor         x.x.xxx
y   Minor      latestMinor         3.x.xxx
z   Feature    latestFeature       3.1.xxx
nm  Patch      latestPatch         3.1.2xx
```

## .NET SDK 확인하기
```shell
# .NET SDK 목록
dotnet --list-sdks

# .NET Runtime 목록
dotnet --list-runtimes
```
- 참고 자료
  - [.NET SDK 최신 버전](https://github.com/dotnet/core/tree/main/release-notes)
  - [.NET이 설치되어 있는지 확인하는 방법](https://learn.microsoft.com/ko-kr/dotnet/core/install/how-to-detect-installed-versions?pivots=os-windows)

## 솔루션에 .NET SDK 버전 지정하기
- `global.json` 파일은 dotnet CLI 명령을 이용하여 실행할 .NET SDK 버전을 정의합니다.

```shell
# 솔루션 생성하기
dotnet new sln -o SdkVersion
cd ./SdkVersion

# .NET SDK 확인하기
dotnet --list-sdks

# global.json 파일 생성하기
#   - latestPatch: 3.1.2xx
dotnet new global.json --sdk-version 8.0.102 --roll-forward latestPatch
```