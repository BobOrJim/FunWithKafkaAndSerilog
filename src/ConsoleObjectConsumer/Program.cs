using System;
using System.Threading.Tasks;

namespace ConsoleObjectConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            EventConsumer eventConsumer1 = new();
            EventConsumer eventConsumer2 = new();
            EventConsumer eventConsumer3 = new();

            new Task(() => eventConsumer1.ConsumeEvent("Marketing")).Start();
            new Task(() => eventConsumer2.ConsumeEvent("Inventory")).Start();
            new Task(() => eventConsumer3.ConsumeEvent("Basket")).Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
