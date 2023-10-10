using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class CodeFieldReferenceExpressionTest
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().GenerateCodeFieldReferenceExpression(option, builder, new GenerateOptions());

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected string PrepareExpected()
        {
            return @"this.Name";
        }

        protected CodeFieldReferenceExpression PrepareCode()
        {
            CodeFieldReferenceExpression codeExpression = new CodeFieldReferenceExpression();
            codeExpression.TargetObject = new CodeThisReferenceExpression();
            codeExpression.FieldName = "Name";

            return codeExpression;
        }
    }
}
