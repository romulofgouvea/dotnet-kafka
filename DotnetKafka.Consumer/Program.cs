using System.Text.Json;
using Confluent.Kafka;
using DotnetKafka.Entities;


CancellationTokenSource cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true; // prevent the process from terminating.
    cts.Cancel();
};

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:29092",
    GroupId = $"group-0",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<string, string>(config).Build())
{
    consumer.Subscribe("queue_kafka");
    while (!cts.IsCancellationRequested)
    {
        try
        {
            var cr = consumer.Consume(cts.Token);
            var json = cr.Message.Value;
            MessageConsumer mensagem = JsonSerializer.Deserialize<MessageConsumer>(json);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Titulo: {mensagem.Titulo}; Texto={mensagem.Texto}; Id={mensagem.Id}");
        }
        catch (OperationCanceledException oce)
        {
            continue;
        }
    }
}