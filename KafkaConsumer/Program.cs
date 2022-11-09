using Confluent.Kafka;
using Newtonsoft.Json;

Console.WriteLine("Franz - the consumer!");

var config = new ConsumerConfig
{
    GroupId = "weather-consumer-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

var consumer = new ConsumerBuilder<Null, string>(config).Build();

consumer.Subscribe("kafka-topic");

CancellationTokenSource token = new();

try
{
    while (true)
    {
        var response = consumer.Consume(token.Token);
        if (response.Message != null)
        {
            var weather = JsonConvert.DeserializeObject<Weather>(response.Message.Value);
            Console.WriteLine($"State: {weather?.State} Temp: {weather?.Temperature} C");
        }
    }

}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

public record Weather(string State, int Temperature);