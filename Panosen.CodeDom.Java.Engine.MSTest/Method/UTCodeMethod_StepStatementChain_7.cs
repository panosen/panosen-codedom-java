using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_7 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var xx = codeMethod.StepStatementChain().AddCallMethodExpression("list.Where");
            var lamda = xx.AddParameterOfLamdaExpression();
            lamda.SetParameter("x");
            lamda.SetExpression("x.DataStatus == 1");
        }

        protected override string PrepareExpected()
        {
            return @"public void TestMethod() {
    list.Where(x -> x.DataStatus == 1);
}
";
        }
    }
}
