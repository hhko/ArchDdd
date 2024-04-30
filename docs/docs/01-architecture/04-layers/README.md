# 레이어 구성요소

## Domain 레이어
### Value
- [ ] ValueObject
- [ ] Enumeration

### Entity
- [ ] Entity
- [ ] EntityId
- [ ] DomainService
- [ ] DomainException

### Aggregate
- [ ] AggregateRoot
- [ ] DomainEvent(EventHandler)
- [ ] Auditable

### Result
- [ ] Error
- [ ] Result
- [ ] ValidationResult

### 기술 인터페이스?

<br/>

## Application 레이어
### UseCase
- [ ] Command(CommandHandler)
- [ ] Query(QueryHandler)

### 데이터 변환
- [ ] DTO

### 데이터 처리
- [ ] Behavior

### 기술 인터페이스?

<br/>

## Adapter 레이어
### Repository
- [ ] Repository
- [ ] CachedRepository
- [ ] FileSystem
- [ ] ...

### Network
- [ ] gRPC
- [ ] Web API
- [ ] RabbitMQ
- [ ] Kafka
- [ ] Auth...

### Basic
- [ ] System Clock

### ?
- [ ] Composition Root