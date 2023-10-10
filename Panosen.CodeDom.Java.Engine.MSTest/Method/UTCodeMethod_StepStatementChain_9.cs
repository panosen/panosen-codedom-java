using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_9 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var xx = codeMethod.StepStatementChain("this");
            xx.AddCallMethodExpression("MethodA");
            xx.AddCallMethodExpression("MethodB", true);
        }

        protected override string PrepareExpected()
        {
            return @"public void TestMethod() {
    this.MethodA()
            .MethodB();
}
";
        }
    }
}
