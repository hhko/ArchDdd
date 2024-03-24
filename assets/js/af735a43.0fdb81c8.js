"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[3289],{8982:(n,o,e)=>{e.r(o),e.d(o,{assets:()=>d,contentTitle:()=>r,default:()=>u,frontMatter:()=>i,metadata:()=>l,toc:()=>a});var t=e(4848),s=e(8453);const i={sidebar_position:2},r=".NET SDK \ubc84\uc804 \uc9c0\uc815\ud558\uae30",l={id:"solution-organization/solution-configuration/sdkversion/README",title:".NET SDK \ubc84\uc804 \uc9c0\uc815\ud558\uae30",description:"global.json \ud30c\uc77c\uc740 dotnet CLI \uba85\ub839\uc744 \uc774\uc6a9\ud558\uc5ec \uc2e4\ud589\ud560 .NET SDK \ubc84\uc804\uc744 \uc815\uc758\ud569\ub2c8\ub2e4.",source:"@site/docs/02-solution-organization/01-solution-configuration/02-sdkversion/README.md",sourceDirName:"02-solution-organization/01-solution-configuration/02-sdkversion",slug:"/solution-organization/solution-configuration/sdkversion/",permalink:"/cleanddd/docs/solution-organization/solution-configuration/sdkversion/",draft:!1,unlisted:!1,editUrl:"https://github.com/hhko/cleanddd/tree/main/docs/docs/02-solution-organization/01-solution-configuration/02-sdkversion/README.md",tags:[],version:"current",sidebarPosition:2,frontMatter:{sidebar_position:2},sidebar:"tutorialSidebar",previous:{title:"\uc194\ub8e8\uc158 \uad6c\uc131 Script",permalink:"/cleanddd/docs/solution-organization/solution-configuration/script/"},next:{title:"\uc911\uc559 \ube4c\ub4dc \uad00\ub77c\ud788\uae30",permalink:"/cleanddd/docs/solution-organization/solution-configuration/buildprops/"}},d={},a=[{value:".NET SDK \ubc84\uc804 \uccb4\uacc4",id:"net-sdk-\ubc84\uc804-\uccb4\uacc4",level:2},{value:".NET SDK \ud655\uc778\ud558\uae30",id:"net-sdk-\ud655\uc778\ud558\uae30",level:2},{value:"\uc194\ub8e8\uc158 .NET SDK \uad6c\uc131\ud558\uae30",id:"\uc194\ub8e8\uc158-net-sdk-\uad6c\uc131\ud558\uae30",level:2}];function c(n){const o={a:"a",blockquote:"blockquote",code:"code",h1:"h1",h2:"h2",li:"li",p:"p",pre:"pre",ul:"ul",...(0,s.R)(),...n.components};return(0,t.jsxs)(t.Fragment,{children:[(0,t.jsx)(o.h1,{id:"net-sdk-\ubc84\uc804-\uc9c0\uc815\ud558\uae30",children:".NET SDK \ubc84\uc804 \uc9c0\uc815\ud558\uae30"}),"\n",(0,t.jsxs)(o.blockquote,{children:["\n",(0,t.jsxs)(o.p,{children:[(0,t.jsx)(o.code,{children:"global.json"})," \ud30c\uc77c\uc740 dotnet CLI \uba85\ub839\uc744 \uc774\uc6a9\ud558\uc5ec \uc2e4\ud589\ud560 .NET SDK \ubc84\uc804\uc744 \uc815\uc758\ud569\ub2c8\ub2e4."]}),"\n"]}),"\n",(0,t.jsx)(o.h2,{id:"net-sdk-\ubc84\uc804-\uccb4\uacc4",children:".NET SDK \ubc84\uc804 \uccb4\uacc4"}),"\n",(0,t.jsx)(o.pre,{children:(0,t.jsx)(o.code,{children:"x.y.znn\r\n\r\nx   Major      latestMajor         x.x.xxx\r\ny   Minor      latestMinor         3.x.xxx\r\nz   Feature    latestFeature       3.1.xxx\r\nnm  Patch      latestPatch         3.1.2xx\n"})}),"\n",(0,t.jsx)(o.h2,{id:"net-sdk-\ud655\uc778\ud558\uae30",children:".NET SDK \ud655\uc778\ud558\uae30"}),"\n",(0,t.jsx)(o.pre,{children:(0,t.jsx)(o.code,{className:"language-shell",children:"# .NET SDK \ubaa9\ub85d\r\ndotnet --list-sdks\r\n\r\n# .NET Runtime \ubaa9\ub85d\r\ndotnet --list-runtimes\n"})}),"\n",(0,t.jsxs)(o.ul,{children:["\n",(0,t.jsxs)(o.li,{children:["\ucc38\uace0 \uc790\ub8cc","\n",(0,t.jsxs)(o.ul,{children:["\n",(0,t.jsx)(o.li,{children:(0,t.jsx)(o.a,{href:"https://github.com/dotnet/core/tree/main/release-notes",children:".NET SDK \ucd5c\uc2e0 \ubc84\uc804"})}),"\n",(0,t.jsx)(o.li,{children:(0,t.jsx)(o.a,{href:"https://learn.microsoft.com/ko-kr/dotnet/core/install/how-to-detect-installed-versions?pivots=os-windows",children:".NET\uc774 \uc124\uce58\ub418\uc5b4 \uc788\ub294\uc9c0 \ud655\uc778\ud558\ub294 \ubc29\ubc95"})}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,t.jsx)(o.h2,{id:"\uc194\ub8e8\uc158-net-sdk-\uad6c\uc131\ud558\uae30",children:"\uc194\ub8e8\uc158 .NET SDK \uad6c\uc131\ud558\uae30"}),"\n",(0,t.jsx)(o.pre,{children:(0,t.jsx)(o.code,{className:"language-shell",children:"# \uc194\ub8e8\uc158 \uc0dd\uc131\ud558\uae30\r\ndotnet new sln -o SdkVersion\r\ncd ./SdkVersion\r\n\r\n# .NET SDK \ud655\uc778\ud558\uae30\r\ndotnet --list-sdks\r\n\r\n# global.json \ud30c\uc77c \uc0dd\uc131\ud558\uae30\r\n#   - latestPatch: 3.1.2xx\r\ndotnet new global.json --sdk-version 8.0.x --roll-forward latestFeature\n"})})]})}function u(n={}){const{wrapper:o}={...(0,s.R)(),...n.components};return o?(0,t.jsx)(o,{...n,children:(0,t.jsx)(c,{...n})}):c(n)}},8453:(n,o,e)=>{e.d(o,{R:()=>r,x:()=>l});var t=e(6540);const s={},i=t.createContext(s);function r(n){const o=t.useContext(i);return t.useMemo((function(){return"function"==typeof n?n(o):{...o,...n}}),[o,n])}function l(n){let o;return o=n.disableParentContext?"function"==typeof n.components?n.components(s):n.components||s:r(n.components),t.createElement(i.Provider,{value:o},n.children)}}}]);