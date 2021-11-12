using System;

namespace ConsoleProducerV2
{
    public class Program
    {
        static void Main()
        {


            Producer producer1 = new();
            producer1.EventProducer();


            Console.ReadLine();


        }
    }
}
