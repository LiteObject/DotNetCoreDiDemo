using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreDiDemo.Rules
{
    public interface IRuleOne : IGeneralRule
    {
        public void Apply();
    }
}
