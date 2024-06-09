---
sidebar_position: 1
---

# 아키텍처 이해

## 아키텍처 중요성
건축업자가 프로그래머의 프로그램 작성 방식에 따라 건물을 짓는다면 가장 먼저 도착하는 딱따구리가 문명을 파괴할 것입니다.  
If builders built buildings the way programmers wrote programs, then the first woodpecker that came along would destroy civilization. - Gerald Weinberg
- Architecting is a series of **trade-offs**.
- The architecture should scream **the intent of the system**.

## 아키텍처 원칙
**관심사의 분리(SoC, Separation of Concerns)은** 중요한 아키텍처 원칙 중 하나입니다. 이는 **관심사**를 분리함으로써 코드를 더 잘 관리할 수 있다는 개념입니다. 아키텍처 수준의 관심사는 각각의 **레이어**로 나눠져 관리됩니다.
> **레이어 기반 아키텍처 패턴의 역사**는 **관심사**를 관리하기 위한 **레이어 배치의 역사**입니다.

- Layered Architecture
- Hexagonal Architecture
- Onion Architecture
- Clean Architecture
- ...

![ArchitecturePatternHistory](./img/ArchitecturePatternHistory.png)

관심사를 **비즈니스와 기술**로 분리하고, **비즈니스 유스케이스 중심**으로 관심사를 구성합니다.
![](./img/soc.png)

## 참고 자료
### 소프트웨어 아키텍처의 중요성
[![](https://img.youtube.com/vi/4E1BHTvhB7Y/0.jpg)](https://www.youtube.com/watch?v=4E1BHTvhB7Y)

### 테스트 주도 개발(TDD)의 장단점
[![](https://img.youtube.com/vi/eRxc4PD6RN0/0.jpg)](https://www.youtube.com/watch?v=eRxc4PD6RN0)