using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class CodeBinaryOperatorExpressionTest
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().GenerateBinaryOperatorExpresion(option, builder, new GenerateOptions());

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected string PrepareExpected()
        {
            return @"a + b";
        }

        protected CodeBinaryOperatorExpression PrepareCode()
        {
            CodeBinaryOperatorExpression codeExpression = new CodeBinaryOperatorExpression();
            codeExpression.Operator = EnumBinaryOperator.Add;
            codeExpression.Left = "a";
            codeExpression.Right = "b";

            return codeExpression;
        }
    }
}
