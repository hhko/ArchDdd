"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[6494],{3246:(e,o,n)=>{n.r(o),n.d(o,{assets:()=>a,contentTitle:()=>r,default:()=>u,frontMatter:()=>i,metadata:()=>l,toc:()=>c});var t=n(4848),s=n(8453);const i={},r="\ucf54\ub529 \uc2a4\ud0c0\uc77c \uc815\uc758\ud558\uae30",l={id:"solution-organization/solution-devops/codestyle/README",title:"\ucf54\ub529 \uc2a4\ud0c0\uc77c \uc815\uc758\ud558\uae30",description:"---",source:"@site/docs/02-solution-organization/02-solution-devops/99-codestyle/README.md",sourceDirName:"02-solution-organization/02-solution-devops/99-codestyle",slug:"/solution-organization/solution-devops/codestyle/",permalink:"/docs/solution-organization/solution-devops/codestyle/",draft:!1,unlisted:!1,editUrl:"https://github.com/facebook/docusaurus/tree/main/packages/create-docusaurus/templates/shared/docs/02-solution-organization/02-solution-devops/99-codestyle/README.md",tags:[],version:"current",frontMatter:{},sidebar:"tutorialSidebar",previous:{title:"GitHub Packages \ub9cc\ub4e4\uae30",permalink:"/docs/solution-organization/solution-devops/github-packages/"},next:{title:"Tutorial Intro",permalink:"/docs/intro"}},a={},c=[];function d(e){const o={a:"a",code:"code",h1:"h1",hr:"hr",input:"input",li:"li",pre:"pre",ul:"ul",...(0,s.R)(),...e.components};return(0,t.jsxs)(t.Fragment,{children:[(0,t.jsx)(o.h1,{id:"\ucf54\ub529-\uc2a4\ud0c0\uc77c-\uc815\uc758\ud558\uae30",children:"\ucf54\ub529 \uc2a4\ud0c0\uc77c \uc815\uc758\ud558\uae30"}),"\n",(0,t.jsx)(o.hr,{}),"\n",(0,t.jsxs)(o.ul,{className:"contains-task-list",children:["\n",(0,t.jsxs)(o.li,{className:"task-list-item",children:[(0,t.jsx)(o.input,{type:"checkbox",disabled:!0})," ",".editorconfig","\n",(0,t.jsx)(o.pre,{children:(0,t.jsx)(o.code,{children:'dotnet tool install -g dotnet-format --version "8.*" --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet8/nuget/v3/index.json\r\ndotnet format --verify-no-changes\n'})}),"\n"]}),"\n",(0,t.jsxs)(o.li,{className:"task-list-item",children:[(0,t.jsx)(o.input,{type:"checkbox",disabled:!0})," ","StyleCop"]}),"\n",(0,t.jsxs)(o.li,{className:"task-list-item",children:[(0,t.jsx)(o.input,{type:"checkbox",disabled:!0})," ","format"]}),"\n"]}),"\n",(0,t.jsx)(o.hr,{}),"\n",(0,t.jsx)(o.pre,{children:(0,t.jsx)(o.code,{className:"language-xml",children:'<ItemGroup>\r\n    <AdditionalFiles Include="$(MSBuildThisFileDirectory)stylecop.json" Link="stylecop.json" />\r\n    <AdditionalFiles Include="$(MSBuildThisFileDirectory)SonarLint.xml" Link="SonarLint.xml" />\r\n    <EditorConfigFiles Include="$(MSBuildThisFileDirectory).editorconfig" Link=".editorconfig"/>\r\n  </ItemGroup>\r\n\r\n<PropertyGroup Condition="\'$(Configuration)\'==\'Debug\'">\r\n\r\n    \x3c!--the full path of your ruleset file for Debug mode--\x3e\r\n    <CodeAnalysisRuleSet>xxx\\RuleSet1.ruleset</CodeAnalysisRuleSet>\r\n  </PropertyGroup\n'})}),"\n",(0,t.jsx)(o.pre,{children:(0,t.jsx)(o.code,{children:"  dotnet format --verify-no-changes --report issues.json\r\n  dotnet format \u2013verify-no-changes \u2013report issues.json\n"})}),"\n",(0,t.jsxs)(o.ul,{children:["\n",(0,t.jsx)(o.li,{children:(0,t.jsx)(o.a,{href:"https://devzone.channeladam.com/tags/analyzerconfig/",children:".NET Notebook Update - Distribution of a Common EditorConfig File to Multiple .NET Projects The .NET Notebook has been updat"})}),"\n"]})]})}function u(e={}){const{wrapper:o}={...(0,s.R)(),...e.components};return o?(0,t.jsx)(o,{...e,children:(0,t.jsx)(d,{...e})}):d(e)}},8453:(e,o,n)=>{n.d(o,{R:()=>r,x:()=>l});var t=n(6540);const s={},i=t.createContext(s);function r(e){const o=t.useContext(i);return t.useMemo((function(){return"function"==typeof e?e(o):{...o,...e}}),[o,e])}function l(e){let o;return o=e.disableParentContext?"function"==typeof e.components?e.components(s):e.components||s:r(e.components),t.createElement(i.Provider,{value:o},e.children)}}}]);