using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreDiDemo.Rules
{
    public interface IRule : IGeneralRule
    {
        public void Apply();
    }
}
