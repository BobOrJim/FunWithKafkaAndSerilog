using System;
using Confluent.Kafka;
using System.Threading;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ConsoleConsumerV2
{
    public class EventConsumer
    {
        public void ConsumeEvent(string topic = "", string key = "", string value = "")
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
                        Console.WriteLine($"Consumed event from topic {topic} with key {cr.Message.Key,-10} and value {cr.Message.Value}");
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
