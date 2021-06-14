using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetCoreDiDemo.Library;

namespace DotNetCoreDiDemo
{
    public class MyClass : MyBaseClass
    {

        private readonly IOrderService _orderService;

        public MyClass(IEnumerable<IMyService> services) : base(services)
        {
            if (services is null)
            {
            }
        }

        public string Get()
        {
            return $"This is {nameof(MyClass)}";
        }
    }
}
