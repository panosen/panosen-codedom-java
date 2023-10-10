using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_6 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var callMethod = codeMethod.StepStatementChain("this");
            callMethod.AddCallMethodExpression("MethodA");
            callMethod.AddCallMethodExpression("MethodB").AddParameter("zhang");
            callMethod.AddCallMethodExpression("MethodC").AddParameter(123);
        }

        protected override string PrepareExpected()
        {
            return @"public void TestMethod() {
    this.MethodA().MethodB(zhang).MethodC(123);
}
";
        }
    }
}
