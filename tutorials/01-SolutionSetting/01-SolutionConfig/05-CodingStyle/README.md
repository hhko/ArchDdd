# 코딩 스타일 정의하기

---
- [ ] .editorconfig
  ```
  dotnet tool install -g dotnet-format --version "8.*" --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet8/nuget/v3/index.json
  dotnet format --verify-no-changes
  ```
- [ ] StyleCop
- [ ] format
---


<ItemGroup>
    <AdditionalFiles Include="$(MSBuildThisFileDirectory)stylecop.json" Link="stylecop.json" />
    <AdditionalFiles Include="$(MSBuildThisFileDirectory)SonarLint.xml" Link="SonarLint.xml" />
    <EditorConfigFiles Include="$(MSBuildThisFileDirectory).editorconfig" Link=".editorconfig"/>
  </ItemGroup>

<PropertyGroup Condition="'$(Configuration)'=='Debug'">

    <!--the full path of your ruleset file for Debug mode-->
    <CodeAnalysisRuleSet>xxx\RuleSet1.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup


  dotnet format --verify-no-changes --report issues.json
  dotnet format –verify-no-changes –report issues.json