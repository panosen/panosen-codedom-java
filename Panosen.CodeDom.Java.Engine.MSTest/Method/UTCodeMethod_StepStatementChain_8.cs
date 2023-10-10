using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_8 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var xx = codeMethod.StepStatementChain().AddCallMethodExpression("list.Select");
            var lamda = xx.AddParameterOfLamdaNewInstance();
            lamda.SetClassName("Student");
            lamda.SetLamdaParameter("x");
        }

        protected override string PrepareExpected()
        {
            return @"public void TestMethod() {
    list.Select(x -> new Student());
}
";
        }
    }
}
