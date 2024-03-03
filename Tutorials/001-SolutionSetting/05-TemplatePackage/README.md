# 템플릿 패키지 만들기

## .nuspec 파일
```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
  <metadata>
    <id>CleanDdd.Template</id>
    <title>ASP.NET Clean Architecture with DDD Solution</title>
    <version>1.0.0-alpha.1</version>
    <authors>고형호</authors>
    <description>.NET 8 Clean Architecture with DDD Solution Template</description>
    <language>en-US</language>
    <license type="expression">MIT</license>
    <!--
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    -->
    <projectUrl>https://github.com/hhko/CleanDdd</projectUrl>
    <repository type="git" url="https://github.com/hhko/CleanDdd" branch="main" />
    <!--
    <releaseNotes>
      Minor updates to dependencies. Fixed Releases on GitHub.
    </releaseNotes>
    -->
    <packageTypes>
      <packageType name="Template" />
    </packageTypes>
    <tags>clean-architecture ddd domain-driven-design architecture asp-net-core template</tags>
    <!--
    <icon>./content/icon.png</icon>
    -->
    <readme>README.md</readme>
  </metadata>
  <files>
    <file src=".\**" target="content" exclude="**\bin\**;**\obj\**;**\.git\**;**\.github\**;**\*.user;**\.vs\**;**\.vscode\**;**\.gitignore;**\Tutorials\**" />
    <file src="README.md" />
  </files>
</package>
```

## 패키지 명령
```shell
# 패키지 nupkg 파일 생성하기
#   - nuget.exe 최신 버전: https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
#   - -NoDefaultExcludes???
.\nuget.exe pack .\CleanDdd.nuspec -NoDefaultExcludes

# 패키지 설치
dotnet new install .\CleanDdd.Template.1.0.0-alpha.1.nupkg 

# 패키지 제거
dotnet new uninstall CleanDdd.Template

# 패키지 세부 정보
dotnet new details CleanDdd.Template
```

## 참고 자료
- 패키지 버전: https://learn.microsoft.com/en-us/nuget/concepts/package-versioning?tabs=semver20sort
