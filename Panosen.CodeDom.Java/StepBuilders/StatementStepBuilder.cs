using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// StatementStepBuilder
    /// </summary>
    public class StatementStepBuilder : StepBuilder
    {
        /// <summary>
        /// Statement
        /// </summary>
        public string Statement { get; private set; }

        /// <summary>
        /// StatementStepBuilder
        /// </summary>
        public StatementStepBuilder(string statement)
        {
            this.Statement = statement;
        }
    }
}
