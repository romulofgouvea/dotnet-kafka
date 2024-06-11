using System.Text.Json;
using DotnetKafka.Entities;
using DotnetKafka.Repositories;
using Confluent.Kafka;

namespace DotnetKafka.Implementations;

public class KafkaMensagemRepository : IMessageRepository
{
    public void SendMessage(MessageProducer message)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:29092"
        };

        using (var producer = new ProducerBuilder<string, string>(config).Build())
        {
            string json = JsonSerializer.Serialize(message);
            producer.Produce("queue_kafka",
                new Message<string, string>
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = json
                }
            );
        }
    }
}