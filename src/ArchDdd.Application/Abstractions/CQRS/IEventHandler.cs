using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;

// MediatR 원본 정의
// public interface INotificationHandler<in TNotification>
//    where TNotification : INotification
public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : INotification
{
}