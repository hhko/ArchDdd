# GitHub Packages 만들기

## GitHub Token 만들기
```
계정 > Settings
  Developer settings
    Personal access tokens > tokens (classic): "Generate new token" > "Generate new token (classic)

    - Name: GITHUB_TOKEN_PACKAGES_READONLY
    - Expiration: No expiration
    - Select scopes
      - [x] read:packages

    - Name: GITHUB_TOKEN_PACKAGES
    - Expiration: No expiration
    - Select scopes
      - [x] write:packages
      - [x] delete:packages
```
```shell
# 설치 전용
GITHUB_TOKEN_PACKAGES_READONLY
...

# GitHub Actions 전용
GITHUB_TOKEN_PACKAGES
...
```

## nuget.config
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="github" value="https://nuget.pkg.github.com/hhko/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="hhko" />
      <add key="ClearTextPassword" value="{{ GITHUB_TOKEN_PACKAGES_READONLY }}" />
    </github>
  </packageSourceCredentials>
</configuration>
```

## %appdata%\NuGet\NuGet.Config
```shell
dotnet nuget add source `
    --username hhko `
    --password {{ GITHUB_TOKEN_PACKAGES_READONLY }} `
    --store-password-in-clear-text `
    --name github "https://nuget.pkg.github.com/hhko/index.json"

dotnet nuget list source
dotnet nuget remove source github
```

## 참고 자료
- [Working with the NuGet registry](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry)
- [Running Custom .NET code in GitHub Actions](https://www.dotnetcurry.com/dotnetcore/custom-dotnet-code-github-actions)