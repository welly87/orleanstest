using GrainInterfaces;
using Orleans;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GrainClient.Initialize();

            var grainFactory = GrainClient.GrainFactory;
            var e0 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e1 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e2 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e3 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
            var e4 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());

            var m0 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
            var m1 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
            var m0e = m0.AsEmployee().Result;
            var m1e = m1.AsEmployee().Result;

            m0e.Promote(10);
            m1e.Promote(11);

            m0.AddDirectReport(e0).Wait();
            m0.AddDirectReport(e1).Wait();
            m0.AddDirectReport(e2).Wait();

            m1.AddDirectReport(m0e).Wait();
            m1.AddDirectReport(e3).Wait();

            m1.AddDirectReport(e4).Wait();

            //var hello = GrainClient.GrainFactory.GetGrain<IHello>(Guid.NewGuid());

            //Console.WriteLine(hello.SayHello("First").Result);
            //Console.WriteLine(hello.SayHello("Second").Result);
            //Console.WriteLine(hello.SayHello("Third").Result);
            //Console.WriteLine(hello.SayHello("Fourth").Result);


            Console.ReadLine();
            //while (true)
            //{
            //    var greetings = Console.ReadLine();

            //    var result = friend.SayHello(greetings).Result;
            //    Console.WriteLine(result);
            //}
        }

        static void DoSomeClientWork()
        {
            // Orleans comes with a rich XML and programmatic configuration. Here we're just going to set up with basic programmatic config
            //var config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30000);

            GrainClient.Initialize();

            var friend = GrainClient.GrainFactory.GetGrain<IHello>(Guid.NewGuid());

            while (true)
            {
                var greetings = Console.ReadLine();

                var result = friend.SayHello(greetings).Result;
                Console.WriteLine(result);
            }
        }
    }
}
