Node.js 버전 18 이상

# 패키지 버전 목록
npm show <패키지> versions
npm show vitepress versions

# vitepress 패키지 명시적 버전 설치
npm add -D vitepress@<version>
npm add -D vitepress@1.3.4

-D: --save-dev의 줄임말로, 패키지를 "개발 의존성"에 추가하는 옵션입니다. 
이 옵션을 사용하면 설치된 패키지는 package.json의 devDependencies 섹션에 추가됩니다. 
일반적으로 개발 중에만 필요한 도구나 라이브러리를 설치할 때 사용합니다.

package.json
package-lock.json
node_modules

# 설치된 패키지 목록
npm list
npm list -g




mkdir Rule
cd Rule

npm add -D vitepress@1.3.4
ls
npm list

npx vitepress init

┌  Welcome to VitePress!
│
◇  Where should VitePress initialize the config?
│  ./
│
◇  Site title:
│  Architecture and Domain-Driven Design
│
◇  Site description:
│  지속 가능한 코드 이야기
│
◇  Theme:
│  ● Default Theme
│
◇  Use TypeScript for config and theme files?
│  ● Yes
│
◇  Add VitePress npm scripts to package.json?
│  ● Yes
│
└  Done! Now run npm run docs:dev and start writing.


피어 의존성으로서의 Vue
커스텀을 위해 Vue 컴포넌트나 API를 사용하려는 경우, vue를 명시적으로 의존성으로 설치해야 합니다.

```shell
# mkdir Rule
Rule
│  # npm add -D vitepress@1.3.4
├─ node_modules
│  └─ ...
├─ package-lock.json
├─ package.json
│
│  # npx vitepress init
├─ .vitepress
│  └─ config.js
├─ docs
│  └─ 
├─ api-examples.md
├─ markdown-examples.md
└─ index.md
```

```json
# package.json
{
  "devDependencies": {
    "vitepress": "^1.3.4"
  },
  "scripts": {
    "docs:dev": "vitepress dev",
    "docs:build": "vitepress build",
    "docs:preview": "vitepress preview"
  }
}
```
npm run docs:dev
npx vitepress dev docs
vitepress dev docs

TODO 포트 변경?

https://vitepress.dev/ko/guide/getting-started
https://velog.io/@kang-bit/VitePress-Github-Pages%EB%A1%9C-%EB%B8%94%EB%A1%9C%EA%B7%B8-%EB%A7%8C%EB%93%A4%EA%B8%B0-%EC%83%9D%EC%84%B1

- 루트 문서 경로
srcDir: './pages'

- 서브 제목 목차 구성
## <--- 2수준만 대상

---
outline: deep
---
## ... <-- 모든 대상


- md -> .html

- 문서 링크하기
경로만 표시하고 확장자는 제외한다.

<!-- Do -->
[시작하기](./getting-started)       <- 올바른 예

<!-- Don't -->
[시작하기](./getting-started.md)    <- 잘못된 예


- url 단순화
1.html -> 1

cleanUrls: true



      msg: '오류', // [!code error]
      msg: '경고' // [!code warning]


      lineNumbers: true