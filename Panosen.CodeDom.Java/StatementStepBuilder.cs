using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public class StatementStepBuilder : StepBuilder
    {
        public string Statement { get; private set; }

        public StatementStepBuilder(string statement)
        {
            this.Statement = statement;
        }
    }
}
