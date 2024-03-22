---
sidebar_position: 8
---

# docusaurus 문서화하기

## 사이트 생성
```shell
#
# Node.js 18.0 이상 버전
#
node -v

#
# 웹사이트 생성하기
#

# create-docusaurus 패키지 버전
npm show create-docusaurus versions

# https://docusaurus.io/docs/typescript-support
# latest: create-docusaurus 패키지 최신 버전
npx --yes create-docusaurus@latest site classic --typescript
npx --yes create-docusaurus@3.1.1 site classic --typescript

#
# 명령
#
npm start
npm run build
npm run serve
npm run deploy
```

## TODO
- [X] 특정 버전 사이트 생성
- [X] docs 메뉴 생성 `_category_.json`
- [x] docs 페이지 생성 `sidebar_position`
- [x] docs 페이지를 위한 폴더 구성 `폴더 이름`