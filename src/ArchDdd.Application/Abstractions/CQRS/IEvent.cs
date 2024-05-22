using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;

public interface IEvent : INotification
{
}

// public interface IIntegrationEvent : INotification
// {
// }

// public interface IIntegrationEventHandler<in TIntegrationEvent> : INotificationHandler<TIntegrationEvent>
//     where TIntegrationEvent : IIntegrationEvent
// {
// }

// public interface IIntegrationEventPublisher
// {
//     /// <summary>
//     /// Publishes the specified integration event to the message queue.
//     /// </summary>
//     /// <param name="integrationEvent">The integration event.</param>
//     /// <returns>The completed task.</returns>
//     void Publish(IIntegrationEvent integrationEvent);
// }