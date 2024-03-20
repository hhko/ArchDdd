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

# latest: create-docusaurus 패키지 최신 버전
# site: 폴더 이름
npx create-docusaurus@latest site classic --typescript --yes

# 3.1.1: create-docusaurus 패키지 특정 버전
# site: 폴더 이름
npx --yes create-docusaurus@3.1.1 site classic --typescript

#
# 명령
#
npm start
npm run build
npm run serve
npm run deploy
GIT_USER=<Your GitHub username> npm run deploy
```