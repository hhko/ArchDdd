---
sidebar_position: 8
---

# 문서 사이트 구축하기

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
npx --yes create-docusaurus@latest docs classic --typescript
npx --yes create-docusaurus@3.1.1 docs classic --typescript

#
# 명령
#
npm start
npm run build
npm run serve
npm run deploy

# Self-Hosting
# https://docusaurus.io/docs/deployment#self-hosting
npm run serve -- --build --port 80 --host 0.0.0.0
```

## docusaurus.config.ts 설정
```
baseUrl: '/cleanddd/',
```
- `cleanddd` 저장소 이름


```ts
const config: Config = {
  title: 'CleanDDD',
  tagline: 'Domain-Driven Design with Clean Architecture are cool',
```

```ts
const config: Config = {
  themeConfig: {
    navbar: {
      title: 'CleanDDD',
```

```ts
const config: Config = {
  presets: [
    [
      'classic',
      {
        blog: {
          showReadingTime: true,
          blogSidebarTitle: 'All posts',
          blogSidebarCount: 'ALL',
```