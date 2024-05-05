# Snapshot 테스트

## 구성
- .gitattributes

```
*.verified.txt text eol=lf working-tree-encoding=UTF-8
*.verified.xml text eol=lf working-tree-encoding=UTF-8
*.verified.json text eol=lf working-tree-encoding=UTF-8
```

```shell
dotnet tool install -g verify.tool

# .verified. 생성을 결정한다.
dotnet verify review

# 모든 .received. 파일을 .verified. 파일로 변환한다.
dotnet verify accept -y -w 특정_경로

# 모든 .received. 파일을 삭제한다.
dotnet verify reject -y -w 특정_경로
```

| 구분 | URL | 기능 |
| === | --- | --- |
| GET     | /api/students/{id}                | Student 조회 |
| POST    | /api/students                     | Student 추가 |
| POST    | /api/students/{id}/enrollments    | Student의 Enrollments 추가 |
| PUT     | /api/students/{id}                | Student 변경 |

```
curl -X POST --location "https://localhost:7230/people" \
    -H "Content-Type: application/json" \
    -d "{ \"FirstName\": \"Maarten\" }"

Invoke-WebRequest `
    -Uri https://localhost:7230/people `
    -Method Post `
    -ContentType "application/json" `
    -Body '{"FirstName": "Maarten"}'
```

## 디버깅 환경
### VS 디버깅일 때 Web Browser 활성화 비활성화
- launchSettings.json
  ```
  {
    "profiles": {
      "Api": {
        "launchBrowser": false,
      }
    }
  }
  ```

### REST Client VS 확장 도구
- 확장 도구: https://github.com/madskristensen/RestClientVS
- 단축키: Ctrl+Alt+S

```http
@hostname=localhost
@port=5168
@host = {{hostname}}:{{port}}
@contentType = application/json

### GET
GET http://{{host}}/api/students/1

### PUT & POST
PUT http://{{host}}/api/students/2
Content-Type:{{contentType}}

{
    "name": "foo",
    "address": "hello world 1004"
}
```

### WebAPI 통합 테스트
- WebAPI 생성: Microsoft.AspNetCore.Mvc.Testing
  ```cs
  // 
  var webAppFactory = new WebApplicationFactory<Program>();
  using var httpClient = webAppFactory.CreateDefaultClient();
  ```
- WebAPI 호출: System.Net.Http.Json
  ```cs
  PostAsJsonAsync<T>    
  ReadFromJsonAsync<T>
  ```
- TODO
  - [ ] [How to test ASP.NET Core Minimal APIs](https://www.twilio.com/blog/test-aspnetcore-minimal-apis)
  - [ ] [Integration tests in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0)
  - [ ] Get & Put 테스트 분리?
  - [ ] Assert 코드 개선(Act 포함됨)
    ```cs
    using var response = await httpClient.GetAsync($"api/students/{id}");
    var student = await response.Content.ReadAsStringAsync();
    await VerifyJson(student)
        .UseParameters(id);
    ```

### Verify 테스트 자동화
- 폴더 지정
  ```cs
  public static class Settings
  {
      [ModuleInitializer]
      public static void Initialize()
      {
          // https://github.com/VerifyTests/Verify/blob/main/docs/naming.md
          Verifier.UseProjectRelativeDirectory("Snapshots");
      }
  }
  ```
- 클래스 지정
  ```cs
  [UsesVerify]
  public class 단위테스트_클래스
  { }
  ```
- 파라미터 지정
  ```
  [Theory]
  [InlineData("1")]
  [InlineData("2")]
  public async Task GetStudentById(string id)
  {
      // ...

      await VerifyJson(student)
           .UseParameters(id);            // https://github.com/VerifyTests/Verify/blob/main/docs/parameterised.md


      using var response = await httpClient.GetAsync($"api/students/{id}");
      var student = await response.Content.ReadAsStringAsync();
      await VerifyJson(student)
          .UseParameters(id);
  }
  ```
  - StudentControllerTest.GetStudentById_id=1.verified.txt
  - StudentControllerTest.GetStudentById_id=2.verified.txt
- TODO
  - [x] 특정 폴더 결과 생성: `Verifier.UseProjectRelativeDirectory`
  - [x] InlineData 처리: `UseParameters`
  - [ ] .txt -> .json 확장자 변경
  - [ ] 실패시 파일 비교 표시
  - [ ] [Testing an incremental generator with snapshot testing](https://andrewlock.net/creating-a-source-generator-part-2-testing-an-incremental-generator-with-snapshot-testing/)
  - [ ] [OSS Power-Ups: Verify – Webinar Recording](https://blog.jetbrains.com/dotnet/2021/07/15/oss-power-ups-verify-webinar-recording/)
    - [ ] [Snapshot Testing with Verify](https://www.danclarke.com/snapshot-testing-with-verify)

---
- [ASP.NET Core Integration Tests with Test Containers & Postgres](https://www.azureblue.io/asp-net-core-integration-tests-with-test-containers-and-postgres/)
- [Integration Testing ASP.NET Core APIs incl. auth and database](https://www.fearofoblivion.com/asp-net-core-integration-testing)

