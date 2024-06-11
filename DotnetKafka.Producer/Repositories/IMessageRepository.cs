using DotnetKafka.Entities;

namespace DotnetKafka.Repositories;

public interface IMessageRepository
{
    void SendMessage(MessageProducer messageProducer);
}