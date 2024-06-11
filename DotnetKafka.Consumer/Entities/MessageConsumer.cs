namespace DotnetKafka.Entities;

public class MessageConsumer
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public required string Texto { get; set; }
}