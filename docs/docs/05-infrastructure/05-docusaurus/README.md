---
sidebar_position: 6
---

# docusaurus

## 구성
### Node.js 설치
```powershell
# Node.js 설치

# Node.js 버전
node -v
```

### 사이트 생성
```powershell
npx --yes create-docusaurus@3.1.1 site classic --typescript

cd sidte
npm run build       # 빌드
npm run serve       # 사이트 오픈
```