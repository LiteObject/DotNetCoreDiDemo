using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreDiDemo.Rules
{
    public interface IRuleTwo : IGeneralRule
    {
        public void Apply();

        public void ApplyTwo();
    }
}
