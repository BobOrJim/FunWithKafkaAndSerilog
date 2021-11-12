using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProducerV2
{
    public class EventGenerator
    {
        public Int64 InstanceId { get; set; }
        public EventGenerator()
        {
            InstanceId = DateTime.Now.Ticks;
        }

        public void EventProducer(string topic = "", string key ="", string value = "", int intervall = 1000)
        {
            while (true)
            {
                Console.WriteLine($"TaskID: {InstanceId} Topic = {topic}. Key = {key}. Value = {value} ");
                EventPublisher.PublishEvent(topic, key, value);
                Thread.Sleep(intervall);
            }
        }
    }
}


