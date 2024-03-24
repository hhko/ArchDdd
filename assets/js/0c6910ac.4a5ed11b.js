"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[2100],{775:(n,e,r)=>{r.r(e),r.d(e,{assets:()=>c,contentTitle:()=>i,default:()=>u,frontMatter:()=>s,metadata:()=>a,toc:()=>l});var t=r(4848),o=r(8453);const s={},i="GitHub Actions \ub9cc\ub4e4\uae30",a={id:"solution-organization/solution-devops/github-actions/README",title:"GitHub Actions \ub9cc\ub4e4\uae30",description:"TODO",source:"@site/docs/02-solution-organization/02-solution-devops/02-github-actions/README.md",sourceDirName:"02-solution-organization/02-solution-devops/02-github-actions",slug:"/solution-organization/solution-devops/github-actions/",permalink:"/cleanddd/docs/solution-organization/solution-devops/github-actions/",draft:!1,unlisted:!1,editUrl:"https://github.com/hhko/cleanddd/tree/main/docs/docs/02-solution-organization/02-solution-devops/02-github-actions/README.md",tags:[],version:"current",frontMatter:{},sidebar:"tutorialSidebar",previous:{title:"Host \ube4c\ub4dc\ud558\uae30",permalink:"/cleanddd/docs/solution-organization/solution-devops/host-build/"},next:{title:"GitHub Packages \ub9cc\ub4e4\uae30",permalink:"/cleanddd/docs/solution-organization/solution-devops/github-packages/"}},c={},l=[{value:"TODO",id:"todo",level:2},{value:"CI \uc774\ub984",id:"ci-\uc774\ub984",level:2},{value:"CI \uc2e4\ud589 \uc870\uac74",id:"ci-\uc2e4\ud589-\uc870\uac74",level:2},{value:"CI \uc791\uc5c5",id:"ci-\uc791\uc5c5",level:2}];function d(n){const e={code:"code",h1:"h1",h2:"h2",img:"img",input:"input",li:"li",p:"p",pre:"pre",ul:"ul",...(0,o.R)(),...n.components};return(0,t.jsxs)(t.Fragment,{children:[(0,t.jsx)(e.h1,{id:"github-actions-\ub9cc\ub4e4\uae30",children:"GitHub Actions \ub9cc\ub4e4\uae30"}),"\n",(0,t.jsx)(e.h2,{id:"todo",children:"TODO"}),"\n",(0,t.jsxs)(e.ul,{className:"contains-task-list",children:["\n",(0,t.jsxs)(e.li,{className:"task-list-item",children:[(0,t.jsx)(e.input,{type:"checkbox",disabled:!0})," ","on \uc81c\uc678 \ub300\uc0c1"]}),"\n",(0,t.jsxs)(e.li,{className:"task-list-item",children:[(0,t.jsx)(e.input,{type:"checkbox",disabled:!0})," ","PR\uc77c \ub54c \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 \ub313\uae00 \ucd94\uac00"]}),"\n",(0,t.jsxs)(e.li,{className:"task-list-item",children:[(0,t.jsx)(e.input,{type:"checkbox",disabled:!0})," ","\ucf54\ub4dc \ub9e4\ud2b8\ub9ad \ucd94\uac00"]}),"\n"]}),"\n",(0,t.jsx)(e.h2,{id:"ci-\uc774\ub984",children:"CI \uc774\ub984"}),"\n",(0,t.jsx)(e.pre,{children:(0,t.jsx)(e.code,{className:"language-yml",children:'name: "CleanDdd CI"\n'})}),"\n",(0,t.jsx)(e.p,{children:(0,t.jsx)(e.img,{src:r(1955).A+"",width:"1152",height:"571"})}),"\n",(0,t.jsxs)(e.ul,{children:["\n",(0,t.jsx)(e.li,{children:"GitHub Actions \uc774\ub984"}),"\n"]}),"\n",(0,t.jsx)(e.h2,{id:"ci-\uc2e4\ud589-\uc870\uac74",children:"CI \uc2e4\ud589 \uc870\uac74"}),"\n",(0,t.jsx)(e.pre,{children:(0,t.jsx)(e.code,{className:"language-yml",children:"# TODO: PR\uc77c \ub54c \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 \ub313\uae00 \ucd94\uac00\r\non:\r\n  push:\r\n    branches: [ \"main\" ]\r\n    paths: [ 'src/**', 'tests/**', '.github/workflows/dotnet-ci.yml' ]\r\n    # TODO: \ud2b9\uc815 \ud655\uc7a5\uc790 Actions \uc81c\uc678\r\n    # paths-ignore:\r\n    #     - '**.md'\r\n    #     - '**.pptx'\r\n    #     - '**.png'\n"})}),"\n",(0,t.jsxs)(e.ul,{children:["\n",(0,t.jsxs)(e.li,{children:["GitHub Actions \uc2e4\ud589 \uc870\uac74","\n",(0,t.jsxs)(e.ul,{children:["\n",(0,t.jsx)(e.li,{children:"\ud2b9\uc815 \ube0c\ub79c\uce58\uc640 \ud3f4\ub354\uc5d0 \ubcc0\uacbd \uc0ac\ud56d\uc774 \uc788\uc744 \ub54c"}),"\n"]}),"\n"]}),"\n",(0,t.jsxs)(e.li,{children:["GitHub Actions \uc2e4\ud589 \uc81c\uc678 \uc870\uac74","\n",(0,t.jsxs)(e.ul,{children:["\n",(0,t.jsx)(e.li,{children:"\ud30c\uc77c \ud655\uc7a5\uc790 \uae30\uc900?"}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,t.jsx)(e.h2,{id:"ci-\uc791\uc5c5",children:"CI \uc791\uc5c5"}),"\n",(0,t.jsx)(e.pre,{children:(0,t.jsx)(e.code,{className:"language-yml",children:"jobs:\r\n  build:\r\n    name: Build\r\n\r\n    # \ube4c\ub4dc \ud658\uacbd \uacbd\uc6b0\uc758 \uc218 \uc815\uc758\r\n    strategy:\r\n        matrix:\r\n            dotnet-version: [ '8.0.x' ]\r\n            configuration: [ Release ]\r\n            os: [ ubuntu-22.04 ]\r\n\r\n    # \ube4c\ub4dc \ud658\uacbd \uc9c0\uc815\r\n    runs-on: ${{ matrix.os }}\r\n    #runs-on: ubuntu-22.04\r\n\r\n    # \ud658\uacbd \ubcc0\uc218\r\n    #  - \uaddc\uce59: ${{ env.\ud658\uacbd_\ubcc0\uc218_\uc774\ub984 }}\r\n    #  - \uc608\uc81c: ${{ env.solution_dir }}\r\n    env:\r\n        solution_dir: ./\r\n        solution_file: ./CleanDdd.sln\n"})}),"\n",(0,t.jsx)(e.p,{children:(0,t.jsx)(e.img,{src:r(7468).A+"",width:"1523",height:"1103"})}),"\n",(0,t.jsxs)(e.ul,{children:["\n",(0,t.jsx)(e.li,{children:(0,t.jsx)(e.code,{children:"name"})}),"\n",(0,t.jsxs)(e.li,{children:[(0,t.jsx)(e.code,{children:"strategy"})," -> ",(0,t.jsx)(e.code,{children:"runs-on"})]}),"\n",(0,t.jsxs)(e.li,{children:[(0,t.jsx)(e.code,{children:"env"}),"\n",(0,t.jsx)(e.pre,{children:(0,t.jsx)(e.code,{children:"${{ env.solution_dir }}\n"})}),"\n"]}),"\n"]}),"\n",(0,t.jsx)(e.pre,{children:(0,t.jsx)(e.code,{className:"language-yml",children:'jobs:\r\n  build:\r\n    steps:\r\n        # \ud615\uc0c1\uad00\ub9ac \ucd5c\uc2e0 \uc18c\uc2a4 \ubc1b\uae30\r\n        - name: Checkout\r\n          uses: actions/checkout@v3\r\n\r\n        # Git Commit SHA \uc5bb\uae30\r\n        #   - Deprecating save-state and set-output commands: https://github.blog/changelog/2022-10-11-github-actions-deprecating-save-state-and-set-output-commands/\r\n        #   - GitHub Actions\uc5d0\uc11c output \ubcc0\uc218\uc758 \ubb38\ubc95 \ubcc0\uacbd: https://blog.outsider.ne.kr/1651\r\n        #   - Github Actions and creating a short SHA hash: https://dev.to/hectorleiva/github-actions-and-creating-a-short-sha-hash-8b7\r\n        #\r\n        # \ub3d9\uc801 \ubcc0\uc218 \ub9cc\ub4e4\uae30\r\n        # \uaddc\uce59 1. $GITHUB_OUTPUT\uc740 "steps.vars.outputs"\uc744 \uc9c0\uc815\ud55c\ub2e4.\r\n        # \uaddc\uce59 2. "\ud0a4=\uac12" \ud615\uc2dd\uc73c\ub85c outputs\uc744 \uc815\uc758\ud55c\ub2e4.\r\n        # \uc608. ${{ steps.vars.outputs.short_sha }}\r\n        - name: Set short git commit SHA\r\n          id: vars\r\n          run: |\r\n            calculatedSha=$(git rev-parse --short ${{ github.sha }})\r\n            echo "short_sha=$calculatedSha" >> $GITHUB_OUTPUT\r\n\r\n        # .NET SDK \uc124\uce58\r\n        - name: Setup .NET SDK ${{ matrix.dotnet-version }}\r\n          uses: actions/setup-dotnet@v3\r\n          with:\r\n            dotnet-version: ${{ matrix.dotnet-version }}\r\n\r\n        # \ud328\ud0a4\uc9c0 \ubcf5\uc6d0\r\n        - name: Restore nuget packages\r\n          run: |\r\n            dotnet restore ${{ env.solution_file }}\r\n\r\n        # \ube4c\ub4dc\r\n        - name: Build\r\n          run: |\r\n            dotnet build ${{ env.solution_file }} \\\r\n                --configuration ${{ matrix.configuration }} \\\r\n                --no-restore\r\n\r\n        #\r\n        # \ud14c\uc2a4\ud2b8 \uacb0\uacfc \ud3f4\ub354 \uad6c\uc131\r\n        #\r\n        #  /home/runner/work/CleanDdd\r\n        #    /CleanDdd                                          // \uc800\uc7a5\uc18c Root\r\n        #       /testresults                                    // \ud14c\uc2a4\ud2b8 \uc790\ub3d9\ud654 \uacb0\uacfc\r\n        #           /19f5be57-f7f1-4902-a22d-ca2dcd8fdc7a       // dotnet test: \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 N\uac1c           <- Artifacts \uc5c5\ub85c\ub4dc\r\n        #               /coverage.cobertura.xml\r\n        #\r\n        #           /merged-coverage.cobertura.xml              // dotnet-coverage: Merged \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0\r\n        #           /CodeCoverageReport                         // ReportGenerator: \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 Markdown  <- Summary \uc5c5\ub85c\ub4dc\r\n        #               /SummaryGithub.md\r\n\r\n        # \ud14c\uc2a4\ud2b8\uc640 \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 coverage.cobertura.xml \ud30c\uc77c \uc0dd\uc131\r\n        #   - name: Find coverage output path\r\n        #     run: |\r\n        #       cp $(find . -name "coverage.cobertura.xml") .\r\n\r\n        - name: Test\r\n          run: |\r\n            dotnet test ${{ env.solution_file }} \\\r\n                --configuration ${{ matrix.configuration }} \\\r\n                --results-directory ${{ env.solution_dir }}/testresults \\\r\n                --no-build \\\r\n                --collect "XPlat Code Coverage" \\\r\n                --verbosity normal\r\n\r\n        # dotnet-coverage \ub3c4\uad6c \uc124\uce58\r\n        - name: Install dotnet-coverage\r\n          run: dotnet tool install -g dotnet-coverage --version 17.10.3\r\n\r\n        # N\uac1c coverage.cobertura.xml \ud30c\uc77c\uc744 \uba38\uc9c0\ud55c \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 merged-coverage.cobertura.xml \ud30c\uc77c \uc0dd\uc131\r\n        - name: Convert .coverage report to cobertura\r\n          run: |\r\n            dotnet-coverage merge ${{ env.solution_dir }}/testresults/**/*.cobertura.xml \\\r\n                -f cobertura \\\r\n                -o ${{ env.solution_dir }}/testresults/merged-coverage.cobertura.xml\r\n\r\n        # merged-coverage.cobertura.xml \ud30c\uc77c \uae30\ubc18\uc73c\ub85c \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 SummaryGithub.md \ud30c\uc77c \uc0dd\uc131\r\n        - name: Create coverage markdown file\r\n          uses: danielpalme/ReportGenerator-GitHub-Action@5.2.0\r\n          with:\r\n            reports: \'${{ env.solution_dir }}/testresults/merged-coverage.cobertura.xml\'\r\n            targetdir: \'${{ env.solution_dir }}/testresults/CodeCoverageReport\'\r\n            reporttypes: \'MarkdownSummaryGithub\'\r\n\r\n        # \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 SummaryGithub.md \ud30c\uc77c Summary \uc5c5\ub85c\ub4dc\r\n        - name: Upload coverage markdown into github actions summary\r\n          run: cat ${{ env.solution_dir }}/testresults/CodeCoverageReport/SummaryGithub.md >> $GITHUB_STEP_SUMMARY\r\n\r\n        # N\uac1c \ucf54\ub4dc \ucee4\ubc84\ub9ac\uc9c0 coverage.cobertura.xml \ud30c\uc77c\uc744 \uc555\ucd95\ud558\uc5ec Artifacts \uc5c5\ub85c\ub4dc\r\n        - name: Upload coverage files into github actions artifacts\r\n          uses: actions/upload-artifact@v3\r\n          with:\r\n            name: CodeCoverageReport_${{ matrix.dotnet-version }}_sha-${{ steps.vars.outputs.short_sha }}\r\n            path: ${{ env.solution_dir }}/testresults/**/*.cobertura.xml\n'})})]})}function u(n={}){const{wrapper:e}={...(0,o.R)(),...n.components};return e?(0,t.jsx)(e,{...n,children:(0,t.jsx)(d,{...n})}):d(n)}},1955:(n,e,r)=>{r.d(e,{A:()=>t});const t=r.p+"assets/images/2024-03-12-00-08-11-bb9ea7db2fb87f50b7741f54d804e00e.png"},7468:(n,e,r)=>{r.d(e,{A:()=>t});const t=r.p+"assets/images/2024-03-12-00-22-45-e71ca9db275124fb2761680ca6093c01.png"},8453:(n,e,r)=>{r.d(e,{R:()=>i,x:()=>a});var t=r(6540);const o={},s=t.createContext(o);function i(n){const e=t.useContext(s);return t.useMemo((function(){return"function"==typeof n?n(e):{...e,...n}}),[e,n])}function a(n){let e;return e=n.disableParentContext?"function"==typeof n.components?n.components(o):n.components||o:i(n.components),t.createElement(s.Provider,{value:e},n.children)}}}]);