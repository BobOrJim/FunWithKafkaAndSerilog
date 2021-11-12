using Confluent.Kafka;
using System;

namespace ConsoleProducerV2
{
    static public class EventPublisher //According to the documentation static is a good option.
    {
        static public void PublishEvent(string topic = "", string key = "", string value = "")
        {
            using (var producer = new ProducerBuilder<string, string>(new ProducerConfig { BootstrapServers = "localhost:9092" }).Build())
            {
                producer.Produce(topic, new Message<string, string> { Key = key, Value = value }, (deliveryReport) => 
                    {
                        if (deliveryReport.Error.Code != ErrorCode.NoError)
                            {
                                Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                            }
                    });
                producer.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}