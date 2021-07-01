using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public class CodeBinaryOperatorExpression : CodeExpression
    {
        public BinaryOperator Operator { get; set; }

        public string Left { get; set; }

        public string Right { get; set; }
    }
}
