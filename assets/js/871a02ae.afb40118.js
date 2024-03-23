"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[5958],{6462:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>l,contentTitle:()=>s,default:()=>u,frontMatter:()=>a,metadata:()=>o,toc:()=>c});var r=t(4848),i=t(8453);const a={sidebar_position:7},s="SDK \ud15c\ud50c\ub9bf \ud328\ud0a4\uc9c0 \ub9cc\ub4e4\uae30",o={id:"solution-organization/solution-configuration/sdktemplate-package/README",title:"SDK \ud15c\ud50c\ub9bf \ud328\ud0a4\uc9c0 \ub9cc\ub4e4\uae30",description:".nuspec \ud30c\uc77c",source:"@site/docs/02-solution-organization/01-solution-configuration/07-sdktemplate-package/README.md",sourceDirName:"02-solution-organization/01-solution-configuration/07-sdktemplate-package",slug:"/solution-organization/solution-configuration/sdktemplate-package/",permalink:"/docs/solution-organization/solution-configuration/sdktemplate-package/",draft:!1,unlisted:!1,editUrl:"https://github.com/facebook/docusaurus/tree/main/packages/create-docusaurus/templates/shared/docs/02-solution-organization/01-solution-configuration/07-sdktemplate-package/README.md",tags:[],version:"current",sidebarPosition:7,frontMatter:{sidebar_position:7},sidebar:"tutorialSidebar",previous:{title:"SDK \ud15c\ud50c\ub9bf \ub9cc\ub4e4\uae30",permalink:"/docs/solution-organization/solution-configuration/sdktemplate/"},next:{title:"\ubb38\uc11c \uc0ac\uc774\ud2b8 \uad6c\ucd95\ud558\uae30",permalink:"/docs/solution-organization/solution-configuration/docusaurus/"}},l={},c=[{value:".nuspec \ud30c\uc77c",id:"nuspec-\ud30c\uc77c",level:2},{value:"\ud328\ud0a4\uc9c0 \uba85\ub839",id:"\ud328\ud0a4\uc9c0-\uba85\ub839",level:2},{value:"TODO",id:"todo",level:2},{value:"\ud3f4\ub354 \uc720\uc9c0 \ubabb\ud568?",id:"\ud3f4\ub354-\uc720\uc9c0-\ubabb\ud568",level:3},{value:"XML \uba40\ud2f0 \ub77c\uc778",id:"xml-\uba40\ud2f0-\ub77c\uc778",level:3},{value:"Reset-Templates",id:"reset-templates",level:3},{value:"\ucc38\uace0 \uc790\ub8cc",id:"\ucc38\uace0-\uc790\ub8cc",level:2}];function p(e){const n={a:"a",code:"code",h1:"h1",h2:"h2",h3:"h3",li:"li",pre:"pre",ul:"ul",...(0,i.R)(),...e.components};return(0,r.jsxs)(r.Fragment,{children:[(0,r.jsx)(n.h1,{id:"sdk-\ud15c\ud50c\ub9bf-\ud328\ud0a4\uc9c0-\ub9cc\ub4e4\uae30",children:"SDK \ud15c\ud50c\ub9bf \ud328\ud0a4\uc9c0 \ub9cc\ub4e4\uae30"}),"\n",(0,r.jsx)(n.h2,{id:"nuspec-\ud30c\uc77c",children:".nuspec \ud30c\uc77c"}),"\n",(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{className:"language-xml",children:'<?xml version="1.0" encoding="utf-8"?>\r\n<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">\r\n  <metadata>\r\n    <id>CleanDdd.Template</id>\r\n    <title>ASP.NET Clean Architecture with DDD Solution</title>\r\n    <version>1.0.0-alpha.1</version>\r\n    <authors>\uace0\ud615\ud638</authors>\r\n    <description>.NET 8 Clean Architecture with DDD Solution Template</description>\r\n    <language>en-US</language>\r\n    <license type="expression">MIT</license>\r\n    \x3c!--\r\n    <requireLicenseAcceptance>false</requireLicenseAcceptance>\r\n    --\x3e\r\n    <projectUrl>https://github.com/hhko/CleanDdd</projectUrl>\r\n    <repository type="git" url="https://github.com/hhko/CleanDdd" branch="main" />\r\n    \x3c!--\r\n    <releaseNotes>\r\n      Minor updates to dependencies. Fixed Releases on GitHub.\r\n    </releaseNotes>\r\n    --\x3e\r\n    <packageTypes>\r\n      <packageType name="Template" />\r\n    </packageTypes>\r\n    <tags>clean-architecture ddd domain-driven-design architecture asp-net-core template</tags>\r\n    \x3c!--\r\n    <icon>./content/icon.png</icon>\r\n    --\x3e\r\n    <readme>README.md</readme>\r\n  </metadata>\r\n  <files>\r\n    \x3c!--\r\n      **\\.template.config\\**;\r\n      \ud15c\ud50c\ub9bf \uc815\uc758\ub97c \uc704\ud574\uc11c .template.config \ud3f4\ub354\ub294 \ubc18\ub4dc\uc2dc \ud3ec\ud568\uc2dc\ucf1c\uc57c \ud55c\ub2e4.\r\n    --\x3e\r\n    <file src=".\\**" target="content" exclude=".\\nuget.exe;**\\bin\\**;**\\obj\\**;**\\.git\\**;**\\.github\\**;**\\*.user;**\\.vs\\**;**\\.vscode\\**;**\\.gitignore;**\\Tutorials\\**" />\r\n    <file src="README.md" />\r\n  </files>\r\n</package>\n'})}),"\n",(0,r.jsx)(n.h2,{id:"\ud328\ud0a4\uc9c0-\uba85\ub839",children:"\ud328\ud0a4\uc9c0 \uba85\ub839"}),"\n",(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{className:"language-shell",children:"# \ud328\ud0a4\uc9c0 nupkg \ud30c\uc77c \uc0dd\uc131\ud558\uae30\r\n#   - nuget.exe \ucd5c\uc2e0 \ubc84\uc804: https://dist.nuget.org/win-x86-commandline/latest/nuget.exe\r\n#   - -NoDefaultExcludes:\r\n#       .nupkg' \ud30c\uc77c\uc774 \ud328\ud0a4\uc9c0\uc5d0 \ucd94\uac00\ub418\uc9c0 \uc54a\uc558\uc2b5\ub2c8\ub2e4.\r\n#       '.'\uc73c\ub85c \uc2dc\uc791\ud558\uac70\ub098 '.nupkg'\ub85c \ub05d\ub098\ub294 \ud30c\uc77c \ubc0f \ud3f4\ub354\ub294 \uae30\ubcf8\uc801\uc73c\ub85c \uc81c\uc678\ub429\ub2c8\ub2e4.\r\n#       \uc774 \ud30c\uc77c\uc744 \ud3ec\ud568\ud558\ub824\uba74 \uba85\ub839\uc904\uc5d0\uc11c -NoDefaultExcludes\ub97c \uc0ac\uc6a9\ud558\uc138\uc694.\r\n.\\nuget.exe pack .\\CleanDdd.nuspec -NoDefaultExcludes\r\n\r\n# \ud328\ud0a4\uc9c0 \uc124\uce58\r\ndotnet new install .\\CleanDdd.Template.1.0.0-alpha.1.nupkg \r\n\r\n# \ud328\ud0a4\uc9c0 \uc81c\uac70\r\ndotnet new uninstall CleanDdd.Template\r\n\r\n# \ud328\ud0a4\uc9c0 \uc138\ubd80 \uc815\ubcf4\r\ndotnet new details CleanDdd.Template\n"})}),"\n",(0,r.jsx)(n.h2,{id:"todo",children:"TODO"}),"\n",(0,r.jsx)(n.h3,{id:"\ud3f4\ub354-\uc720\uc9c0-\ubabb\ud568",children:"\ud3f4\ub354 \uc720\uc9c0 \ubabb\ud568?"}),"\n",(0,r.jsx)(n.h3,{id:"xml-\uba40\ud2f0-\ub77c\uc778",children:"XML \uba40\ud2f0 \ub77c\uc778"}),"\n",(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{className:"language-xml",children:'<file src=".\\**" target="content" exclude=".\\nuget.exe;**\\.template.config\\**;**\\bin\\**;**\\obj\\**;**\\.git\\**;**\\.github\\**;**\\*.user;**\\.vs\\**;**\\.vscode\\**;**\\.gitignore;**\\Tutorials\\**" />\n'})}),"\n",(0,r.jsx)(n.h3,{id:"reset-templates",children:"Reset-Templates"}),"\n",(0,r.jsxs)(n.ul,{children:["\n",(0,r.jsx)(n.li,{children:(0,r.jsx)(n.a,{href:"https://github.com/sayedihashimi/template-sample/blob/main/build-nuget.ps1",children:"https://github.com/sayedihashimi/template-sample/blob/main/build-nuget.ps1"})}),"\n",(0,r.jsx)(n.li,{children:"\uc124\uce58\ud55c nupkg \ud30c\uc77c \uc0ad\uc81c\ud558\uae30"}),"\n"]}),"\n",(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{children:"\uc624\ub958 :\ud30c\uc77c C:\\Users\\\uace0\ud615\ud638\\.templateengine\\packages\\CleanDdd.Template.1.0.0-alpha.1.nupkg\uc774(\uac00) \uc774\ubbf8 \uc788\uc2b5\ub2c8\ub2e4.\n"})}),"\n",(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{className:"language-powershell",children:"$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition\r\n$srcDir = (Join-Path -path $scriptDir src)\r\n# nuget.exe needs to be on the path or aliased\r\nfunction Reset-Templates{\r\n    [cmdletbinding()]\r\n    param(\r\n        [string]$templateEngineUserDir = (join-path -Path $env:USERPROFILE -ChildPath .templateengine)\r\n    )\r\n    process{\r\n        'resetting dotnet new templates. folder: \"{0}\"' -f $templateEngineUserDir | Write-host\r\n        get-childitem -path $templateEngineUserDir -directory | Select-Object -ExpandProperty FullName | remove-item -recurse\r\n        &dotnet new --debug:reinit\r\n    }\r\n}\r\nfunction Clean(){\r\n    [cmdletbinding()]\r\n    param(\r\n        [string]$rootFolder = $scriptDir\r\n    )\r\n    process{\r\n        'clean started, rootFolder \"{0}\"' -f $rootFolder | write-host\r\n        # delete folders that should not be included in the nuget package\r\n        Get-ChildItem -path $rootFolder -include bin,obj,nupkg -Recurse -Directory | Select-Object -ExpandProperty FullName | Remove-item -recurse\r\n    }\r\n}\r\n\r\n# start script\r\nClean\r\n\r\n# create nuget package\r\n$outputpath = Join-Path $scriptDir nupkg\r\n$pathtonuspec = Join-Path $srcDir SayedHa.Template.NetCoreTool.nuspec\r\nif(Test-Path $pathtonuspec){\r\n    nuget.exe pack $pathtonuspec -OutputDirectory $outputpath\r\n}\r\nelse{\r\n    'ERROR: nuspec file not found at {0}' -f $pathtonuspec | Write-Error\r\n    return\r\n}\r\n\r\n$pathtonupkg = join-path $scriptDir nupkg/SayedHa.Template.NetCoreTool.nuspec.1.0.1.nupkg\r\n# install nuget package using dotnet new --install\r\nif(test-path $pathtonupkg){   \r\n    Reset-Templates\r\n    'installing template with command \"dotnet new --install {0}\"' -f $pathtonupkg | write-host\r\n    &dotnet new --install $pathtonupkg\r\n}\r\nelse{\r\n    'Not installing template because it was not found at \"{0}\"' -f $pathtonupkg | Write-Error\r\n}\n"})}),"\n",(0,r.jsx)(n.h2,{id:"\ucc38\uace0-\uc790\ub8cc",children:"\ucc38\uace0 \uc790\ub8cc"}),"\n",(0,r.jsxs)(n.ul,{children:["\n",(0,r.jsxs)(n.li,{children:["\ud328\ud0a4\uc9c0 \ubc84\uc804: ",(0,r.jsx)(n.a,{href:"https://learn.microsoft.com/en-us/nuget/concepts/package-versioning?tabs=semver20sort",children:"https://learn.microsoft.com/en-us/nuget/concepts/package-versioning?tabs=semver20sort"})]}),"\n",(0,r.jsxs)(n.li,{children:["nuspec: ",(0,r.jsx)(n.a,{href:"https://learn.microsoft.com/en-us/nuget/reference/nuspec",children:"https://learn.microsoft.com/en-us/nuget/reference/nuspec"})]}),"\n"]})]})}function u(e={}){const{wrapper:n}={...(0,i.R)(),...e.components};return n?(0,r.jsx)(n,{...e,children:(0,r.jsx)(p,{...e})}):p(e)}},8453:(e,n,t)=>{t.d(n,{R:()=>s,x:()=>o});var r=t(6540);const i={},a=r.createContext(i);function s(e){const n=r.useContext(a);return r.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function o(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(i):e.components||i:s(e.components),r.createElement(a.Provider,{value:n},e.children)}}}]);