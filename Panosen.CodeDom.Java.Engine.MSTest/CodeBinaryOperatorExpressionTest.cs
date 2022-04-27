using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class CodeBinaryOperatorExpressionTest: UTBase
    {
        protected override string PrepareExpected()
        {
            return @"a + b";
        }

        protected override Code PrepareCode()
        {
            CodeBinaryOperatorExpression codeExpression = new CodeBinaryOperatorExpression();
            codeExpression.Operator = EnumBinaryOperator.Add;
            codeExpression.Left = "a";
            codeExpression.Right = "b";

            return codeExpression;
        }
    }
}
