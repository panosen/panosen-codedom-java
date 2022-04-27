using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class CodeFieldReferenceExpressionTest : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"this.Name";
        }

        protected override Code PrepareCode()
        {
            CodeFieldReferenceExpression codeExpression = new CodeFieldReferenceExpression();
            codeExpression.TargetObject = new CodeThisReferenceExpression();
            codeExpression.FieldName = "Name";

            return codeExpression;
        }
    }
}
