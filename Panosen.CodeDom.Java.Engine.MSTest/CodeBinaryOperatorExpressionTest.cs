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
            var option = GetData();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().Generate(option, builder);

            var actual = builder.ToString();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private object PrepareExpected()
        {
            return @"a + b";
        }

        public Code GetData()
        {
            CodeBinaryOperatorExpression codeExpression = new CodeBinaryOperatorExpression();
            codeExpression.Operator = EnumBinaryOperator.Add;
            codeExpression.Left = "a";
            codeExpression.Right = "b";

            return codeExpression;
        }
    }
}
