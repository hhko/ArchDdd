```shell
dotnet new nuget.config

# docfx 설치하기
#   https://www.nuget.org/packages/docfx
#   dotnet tool install --global docfx --version 2.75.3
dotnet tool install -g docfx
dotnet tool list -g

패키지 ID          버전            명령
----------------------------------------------
docfx              2.75.3        docfx


# 사이트 생성
docfx init -y
#   api             <- C# 코드에서 자동 생성: docfx.json
#   docs
#   docfx.json
#   index.md
#   toc.yml

# 빌드
docfx docfx.json --serve
docfx docfx.json
```

## TODO
![](./.images/2024-03-04-18-30-07.png)

- [x] 솔루션 통합: C#
- [ ] 새로 고침 자동화?
- [ ] 하단
- [ ] 한국어 검색: 메뉴
- [ ] 한국어 검색: 내용
- [ ] 컨테이너 배포
- [ ] GitHub Actions 통합