using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreDiDemo.Rules
{
    public class RuleTwo : IRuleTwo
    {
        public void Apply()
        {
            Console.WriteLine($"Applied {nameof(RuleTwo)}");
        }

        public void ApplyTwo()
        {
            Console.WriteLine($"Applied Two {nameof(RuleTwo)}");
        }
    }
}
