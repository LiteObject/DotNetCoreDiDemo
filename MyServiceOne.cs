using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreDiDemo
{
    class MyServiceOne : IMyService
    {
        public void DoSomething()
        {
            Console.WriteLine($"Invoked {nameof(DoSomething)} of {nameof(MyServiceOne)} class.");
        }
    }
}
