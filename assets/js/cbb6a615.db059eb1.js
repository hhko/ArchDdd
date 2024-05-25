"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[407],{5030:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>l,contentTitle:()=>c,default:()=>h,frontMatter:()=>r,metadata:()=>d,toc:()=>a});var i=t(4848),s=t(8453);const r={sidebar_position:3},c="Verify",d={id:"test-packages/verify/README",title:"Verify",description:"\uad6c\uc131",source:"@site/docs/04-test-packages/03-verify/README.md",sourceDirName:"04-test-packages/03-verify",slug:"/test-packages/verify/",permalink:"/ArchDdd/docs/test-packages/verify/",draft:!1,unlisted:!1,editUrl:"https://github.com/hhko/ArchDdd/tree/main/docs/docs/04-test-packages/03-verify/README.md",tags:[],version:"current",sidebarPosition:3,frontMatter:{sidebar_position:3},sidebar:"tutorialSidebar",previous:{title:"Microsoft.AspNetCore.Mvc.Testing",permalink:"/ArchDdd/docs/test-packages/webapi/"},next:{title:"NBomber",permalink:"/ArchDdd/docs/test-packages/nbomber/"}},l={},a=[{value:"\uad6c\uc131",id:"\uad6c\uc131",level:2},{value:"WebAPI \ud1b5\ud569 \ud14c\uc2a4\ud2b8",id:"webapi-\ud1b5\ud569-\ud14c\uc2a4\ud2b8",level:3},{value:"Verify \ud14c\uc2a4\ud2b8 \uc790\ub3d9\ud654",id:"verify-\ud14c\uc2a4\ud2b8-\uc790\ub3d9\ud654",level:3}];function o(e){const n={code:"code",h1:"h1",h2:"h2",h3:"h3",img:"img",input:"input",li:"li",p:"p",pre:"pre",ul:"ul",...(0,s.R)(),...e.components};return(0,i.jsxs)(i.Fragment,{children:[(0,i.jsx)(n.h1,{id:"verify",children:"Verify"}),"\n",(0,i.jsx)(n.h2,{id:"\uad6c\uc131",children:"\uad6c\uc131"}),"\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:".gitattributes"}),"\n"]}),"\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{children:"*.verified.txt text eol=lf working-tree-encoding=UTF-8\r\n*.verified.xml text eol=lf working-tree-encoding=UTF-8\r\n*.verified.json text eol=lf working-tree-encoding=UTF-8\n"})}),"\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{className:"language-shell",children:"dotnet tool install -g verify.tool\r\n\r\n# .verified. \uc0dd\uc131\uc744 \uacb0\uc815\ud55c\ub2e4.\r\ndotnet verify review\r\n\r\n# \ubaa8\ub4e0 .received. \ud30c\uc77c\uc744 .verified. \ud30c\uc77c\ub85c \ubcc0\ud658\ud55c\ub2e4.\r\ndotnet verify accept -y -w \ud2b9\uc815_\uacbd\ub85c\r\n\r\n# \ubaa8\ub4e0 .received. \ud30c\uc77c\uc744 \uc0ad\uc81c\ud55c\ub2e4.\r\ndotnet verify reject -y -w \ud2b9\uc815_\uacbd\ub85c\n"})}),"\n",(0,i.jsx)(n.p,{children:(0,i.jsx)(n.img,{src:t(7993).A+"",width:"2346",height:"1500"})}),"\n",(0,i.jsx)(n.h3,{id:"webapi-\ud1b5\ud569-\ud14c\uc2a4\ud2b8",children:"WebAPI \ud1b5\ud569 \ud14c\uc2a4\ud2b8"}),"\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["WebAPI \uc0dd\uc131: Microsoft.AspNetCore.Mvc.Testing","\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{className:"language-cs",children:"var webAppFactory = new WebApplicationFactory<Program>();\r\nusing var httpClient = webAppFactory.CreateDefaultClient();\n"})}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["WebAPI \ud638\ucd9c: System.Net.Http.Json","\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{className:"language-cs",children:"PostAsJsonAsync<T>\r\nReadFromJsonAsync<T>\n"})}),"\n"]}),"\n"]}),"\n",(0,i.jsx)(n.h3,{id:"verify-\ud14c\uc2a4\ud2b8-\uc790\ub3d9\ud654",children:"Verify \ud14c\uc2a4\ud2b8 \uc790\ub3d9\ud654"}),"\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["\ud3f4\ub354 \uc9c0\uc815","\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{className:"language-cs",children:'public static class Settings\r\n{\r\n    [ModuleInitializer]\r\n    public static void Initialize()\r\n    {\r\n        // https://github.com/VerifyTests/Verify/blob/main/docs/naming.md\r\n        Verifier.UseProjectRelativeDirectory("Snapshots");\r\n\r\n        // \uc2e4\ud328\uc2dc \ud30c\uc77c \ube44\uad50\ucc3d \ube44\ud65c\uc131\ud654\r\n        DiffRunner.Disabled = true;\r\n    }\r\n}\n'})}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["\ud30c\ub77c\ubbf8\ud130 \uc9c0\uc815","\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{children:'[Theory]\r\n[InlineData("1")]\r\n[InlineData("2")]\r\npublic async Task GetStudentById(string id)\r\n{\r\n    // ...\r\n\r\n    await VerifyJson(student)\r\n         .UseParameters(id);            // https://github.com/VerifyTests/Verify/blob/main/docs/parameterised.md\r\n\r\n\r\n    using var response = await httpClient.GetAsync($"api/students/{id}");\r\n    var student = await response.Content.ReadAsStringAsync();\r\n    await VerifyJson(student)\r\n        .UseParameters(id);\r\n}\n'})}),"\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"StudentControllerTest.GetStudentById_id=1.verified.txt"}),"\n",(0,i.jsx)(n.li,{children:"StudentControllerTest.GetStudentById_id=2.verified.txt"}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["TODO","\n",(0,i.jsxs)(n.ul,{className:"contains-task-list",children:["\n",(0,i.jsxs)(n.li,{className:"task-list-item",children:[(0,i.jsx)(n.input,{type:"checkbox",checked:!0,disabled:!0})," ","\ud2b9\uc815 \ud3f4\ub354 \uacb0\uacfc \uc0dd\uc131: ",(0,i.jsx)(n.code,{children:"Verifier.UseProjectRelativeDirectory"})]}),"\n",(0,i.jsxs)(n.li,{className:"task-list-item",children:[(0,i.jsx)(n.input,{type:"checkbox",checked:!0,disabled:!0})," ","InlineData \ucc98\ub9ac: ",(0,i.jsx)(n.code,{children:"UseParameters"})]}),"\n",(0,i.jsxs)(n.li,{className:"task-list-item",children:[(0,i.jsx)(n.input,{type:"checkbox",disabled:!0})," ",".txt -> .json \ud655\uc7a5\uc790 \ubcc0\uacbd"]}),"\n",(0,i.jsxs)(n.li,{className:"task-list-item",children:[(0,i.jsx)(n.input,{type:"checkbox",checked:!0,disabled:!0})," ","\uc2e4\ud328\uc2dc \ud30c\uc77c \ube44\uad50 \ube44\ud65c\uc131\ud654"]}),"\n"]}),"\n"]}),"\n"]})]})}function h(e={}){const{wrapper:n}={...(0,s.R)(),...e.components};return n?(0,i.jsx)(n,{...e,children:(0,i.jsx)(o,{...e})}):o(e)}},7993:(e,n,t)=>{t.d(n,{A:()=>i});const i=t.p+"assets/images/2024-05-06-15-54-04-eefe05214e226415652cbe1364af0e18.png"},8453:(e,n,t)=>{t.d(n,{R:()=>c,x:()=>d});var i=t(6540);const s={},r=i.createContext(s);function c(e){const n=i.useContext(r);return i.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function d(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(s):e.components||s:c(e.components),i.createElement(r.Provider,{value:n},e.children)}}}]);