using Common;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleObjectProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            EventGenerator eventGenerator1 = new();
            EventGenerator eventGenerator2 = new();
            EventGenerator eventGenerator3 = new();

            Stuff stuff1 = new Stuff { MyInt = 11, MyString = "Eleven" };
            Stuff stuff2 = new Stuff { MyInt = 12, MyString = "Twelve" };
            Stuff stuff3 = new Stuff { MyInt = 13, MyString = "Thirteen" };

            string jsonString1 = JsonSerializer.Serialize<Stuff>(stuff1);
            string jsonString2 = JsonSerializer.Serialize<Stuff>(stuff2);
            string jsonString3 = JsonSerializer.Serialize<Stuff>(stuff3);

            //Topic key value
            new Task(() => eventGenerator1.EventProducer("Marketing", "CoolKey", jsonString1, 1000)).Start();
            new Task(() => eventGenerator2.EventProducer("Inventory", "CoolKey", jsonString2, 1000)).Start();
            new Task(() => eventGenerator3.EventProducer("Basket", "CoolKey", jsonString3, 1000)).Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
