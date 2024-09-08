using Kacu.Shared.Abstraction.Messaging;

namespace Kacu.Shared.Infrastructure.Messaging.Dispatchers;

public interface IAsyncMessageDispatcher
{
    Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage;
}