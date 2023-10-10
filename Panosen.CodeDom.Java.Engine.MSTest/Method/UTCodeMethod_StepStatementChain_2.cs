using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_2 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var chain = codeMethod.StepStatementChain($"response.Items = bookDBContext.Countrys");

            chain.AddCallMethodExpression("Where")
                .AddParameterOfLamdaExpression().SetParameter("v").SetExpression($"v.Name == name");

            chain.AddCallMethodExpression("Select").AddParameterOfLamdaNewInstance().SetClassName($"CasLocationVo").SetLamdaParameter("v");

            chain.AddCallMethodExpression("Select", true).AddParameterOfLamdaNewInstance().SetClassName($"CasLocationVo").SetLamdaParameter("v");

            chain.AddCallMethodExpression("ToListA");
            chain.AddCallMethodExpression("ToListB");
        }

        protected override string PrepareExpected()
        {
            return @"public void TestMethod() {
    response.Items = bookDBContext.Countrys.Where(v -> v.Name == name).Select(v -> new CasLocationVo())
            .Select(v -> new CasLocationVo()).ToListA().ToListB();
}
";
        }
    }
}
