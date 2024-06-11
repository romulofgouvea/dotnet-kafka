namespace DotnetKafka.Entities;

public class MessageProducer
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public required string Texto { get; set; }
}