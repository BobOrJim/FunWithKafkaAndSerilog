using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProducerV2
{
    public class Program
    {
        static void Main()
        {
            EventGenerator eventGenerator1 = new();
            EventGenerator eventGenerator2 = new();
            EventGenerator eventGenerator3 = new();

            new Task(() => eventGenerator1.EventProducer("Marketing", "Tea pot", "+1", 1000)).Start();
            new Task(() => eventGenerator2.EventProducer("Inventory", "Tea pot", "-1", 1000)).Start();
            new Task(() => eventGenerator3.EventProducer("Basket", "Tea pot", "+1", 1000)).Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
