# docs
[Docusaurus](https://docusaurus.io/) 기반으로 구축하였습니다.

## docusaurus 버전 업그레이드
`package.json` 파일에 있는 모든 버전을 업데이트 후 `Build-Install.ps1` 파일을 실행합니다.

```json
"dependencies": {
  "@docusaurus/core": "3.3.2",
  "@docusaurus/preset-classic": "3.3.2",
  ...
},
"devDependencies": {
  "@docusaurus/module-type-aliases": "3.3.2",
  "@docusaurus/tsconfig": "3.3.2",
  "@docusaurus/types": "3.3.2",
  ...
```