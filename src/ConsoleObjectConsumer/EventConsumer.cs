using System;
using Confluent.Kafka;
using System.Threading;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Common;
using System.Text.Json;

namespace ConsoleObjectConsumer
{
    public class EventConsumer
    {
        public void ConsumeEvent(string topic = "")
        {
            var conf = new ConsumerConfig
            {
                GroupId = "hpax_consumer_group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => 
            { 
                e.Cancel = true; 
                cts.Cancel();
            };

            using (var consumer = new ConsumerBuilder<string, string>(conf).Build())
            {
                consumer.Subscribe(topic);
                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume(cts.Token);
                        Stuff stuff = JsonSerializer.Deserialize<Stuff>(cr.Message.Value);
                        //Console.WriteLine($"Consumed event from topic {topic} with key {cr.Message.Key,-10} and value {cr.Message.Value}");
                        Console.WriteLine($"Number as int: {stuff.MyInt}. Number as string {stuff.MyString}");
                    }
                }
                catch (OperationCanceledException)
                {
                }
                finally
                {
                    consumer.Close();
                }
            }
        }

    }
}
