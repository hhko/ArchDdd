# 배포

## 참고 자료
- [Publish a console app as a single executable](https://bartwullems.blogspot.com/2024/06/publish-console-app-as-single-executable.html)
- [단일 파일 배포](https://learn.microsoft.com/ko-kr/dotnet/core/deploying/single-file/overview?tabs=cli)
- [.NET CLI를 사용하여 .NET 앱 게시](https://learn.microsoft.com/ko-kr/dotnet/core/deploying/deploy-with-cli)

## 주요 명령
- 프레임워크 종속 배포
  ```
  dotnet publish -c Release -p:UseAppHost=false
  ```
- 프레임워크 종속 실행 파일
  ```
  dotnet publish -c Release -r <RID> --self-contained false
  dotnet publish -c Release
  ```                                      |
- 자체 포함 배포
  ```
  dotnet publish -c Release -r <RID> --self-contained true
  ```
- 자체 포함 배포 단일 파일
  ```
  dotnet publish -c Release -r <RID> -p:PublishSingleFile=true --self-contained true
  ```

## 옵션
- `-c Release`
- `-r win-x64
  ```
  <RuntimeIdentifier>win-x64</RuntimeIdentifier>
  ```
- `-p:PublishSingleFile=true`
  ```
  <PublishSingleFile>true</PublishSingleFile>
  ```
- `--self-contained`
  ```
  <SelfContained>true</SelfContained>
  ```
- ``
  ```
  <DebugType>embedded</DebugType>
  ```
