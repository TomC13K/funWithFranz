using Confluent.Kafka;
using Newtonsoft.Json;

Console.WriteLine("Kafka producer");

var config = new ProducerConfig {BootstrapServers = "localhost:9092", 
    Acks = Acks.None
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{
    string? state;
    while ((state = Console.ReadLine()) != null)
    {
        var response = await producer.ProduceAsync("kafka-topic",
            new Message<Null, string> { Value = JsonConvert.SerializeObject(
                new Weather(state,10))});
    }
}
catch (ProduceException<Null,string> e)
{
    Console.WriteLine(e);
    throw;
}

public record Weather(string State, int Temperature);