using GrainInterfaces;
using Orleans;
using System;
using System.Threading.Tasks;

namespace GrainCollection
{
    class HelloGrain : Grain, IHello
    {
        private string text = "hello world";

        public override Task OnActivateAsync()
        {
            var primaryKey = this.GetPrimaryKey();
            Console.WriteLine(primaryKey);
            return base.OnActivateAsync();
        }

        public Task<string> SayHello(string msg)
        {
            var oldText = text;
            text = msg;

            return Task.FromResult(oldText);
        }
    }
}
