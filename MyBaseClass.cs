using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreDiDemo
{
    public abstract class MyBaseClass
    {
        private readonly IMyService _service;

        protected MyBaseClass(IEnumerable<IMyService> services)
        {
            if(services is null)
            {
                throw new ArgumentNullException($"Param \"{nameof(services)}\" of type {nameof(IMyService)} is null.");
            }

            this._service = services.FirstOrDefault();
            this._service?.DoSomething();
        }
    }
}
