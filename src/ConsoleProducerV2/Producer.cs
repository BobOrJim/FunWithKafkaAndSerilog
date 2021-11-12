using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProducerV2
{
    public class Producer
    {
        public Int64 InstanceId { get; set; }
        public Producer()
        {
            InstanceId = DateTime.Now.Ticks;
        }

        public async Task EventProducer(string topic = "", string key ="", string value = "")
        {
            int counter = 0;
            while (true)
            {
                Console.WriteLine($"TaskID: {InstanceId}. My Counter is: {counter++}. Sending message to topic: {topic}. With Key: {key}. With value: {value} ");
                Thread.Sleep(1000);
            }

            await Task.CompletedTask;
        }


    }
}


