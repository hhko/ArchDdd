---
sidebar_position: 4
---

# 레이어 구성요소

## Domain 레이어
- Value
  - [ ] ValueObject
  - [ ] Enumeration
- Entity
  - [ ] Entity
  - [ ] EntityId
  - [ ] DomainService
  - [ ] DomainException
- Aggregate
  - [ ] AggregateRoot
  - [ ] DomainEvent(EventHandler)
  - [ ] Auditable
- Primitives
  - [ ] Error
  - [ ] Result
  - [ ] ValidationResult
- Ports

## Application 레이어
- UseCase
  - [ ] Command(CommandHandler)
  - [ ] Query(QueryHandler)
- UserCase 입/출력
  - [ ] Pipelines
  - [ ] DTO
- Ports

## Adapter 레이어
- Repository
  - [ ] Repository
  - [ ] CachedRepository
  - [ ] FileSystem
  - [ ] ...
- Network
  - [ ] gRPC
  - [ ] Web API
  - [ ] RabbitMQ
  - [ ] Kafka
  - [ ] Auth...
- System
  - [ ] System Clock
- ?
  - [ ] Composition Root