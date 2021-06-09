using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreDiDemo.Rules
{
    public class RuleOne : IRuleOne
    {
        public void Apply()
        {
            Console.WriteLine($"Applied {nameof(RuleOne)}");
        }
    }
}
