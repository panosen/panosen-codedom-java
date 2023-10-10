using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_3 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var chain = codeMethod.StepStatementChain("services");
            chain.AddCallMethodExpression("AddAuth").AddParameter("Scheme");
            var exp = chain.AddCallMethodExpression("AddJwtBearer");
            exp.AddParameter("OK");
        }

        protected override string PrepareExpected()
        {
            return @"public void TestMethod() {
    services.AddAuth(Scheme).AddJwtBearer(OK);
}
";
        }
    }
}
