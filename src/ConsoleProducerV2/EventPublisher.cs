using Confluent.Kafka;
using System;
using Microsoft.Extensions.Configuration;

namespace ConsoleProducerV2
{
    public class EventPublisher
    {
        public void PublishEvent(string topic = "", string key = "", string value = "")
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
            } //Using
        } //method
    } //class
} //namespace
