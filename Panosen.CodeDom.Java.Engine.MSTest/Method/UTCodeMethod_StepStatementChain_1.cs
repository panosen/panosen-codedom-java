using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_StepStatementChain_1 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            codeMethod.StepEmpty();
            codeMethod.StepStatement("List<String> items = Lists.newArrayList();");

            //lengths
            codeMethod.StepEmpty();
            {
                var chain = codeMethod.StepStatementChain("List<Integer> lengths = items");
                chain.AddCallMethodExpression("stream");
                chain.AddCallMethodExpression("map")
                    .AddParameterOfLamdaExpression().SetParameter("v").SetExpression("v.length()");
                chain.AddCallMethodExpression("collect").AddParameter("Collectors.toList()");
            }

            //apples
            codeMethod.StepEmpty();
            {
                var chain = codeMethod.StepStatementChain("List<Apple> apples = items");
                chain.AddCallMethodExpression("stream");
                chain.AddCallMethodExpression("map", true)
                    .AddParameterOfLamdaNewInstance().SetLamdaParameter("v").SetClassName("Apple");
                chain.AddCallMethodExpression("collect").AddParameter("Collectors.toList()");
            }

            //bananas
            codeMethod.StepEmpty();
            {
                var chain = codeMethod.StepStatementChain("List<Banana> bananas = items");
                chain.AddCallMethodExpression("stream");
                chain.AddCallMethodExpression("map", true)
                    .AddParameterOfLamdaNewInstance().SetLamdaParameter("v").SetClassName("Banana").AddStringValue("tom").AddPlainValue("12");
                chain.AddCallMethodExpression("collect").AddParameter("Collectors.toList()");
            }

            //candys
            codeMethod.StepEmpty();
            {
                var chain = codeMethod.StepStatementChain("List<Candy> candys = items");
                chain.AddCallMethodExpression("stream");
                var map = chain.AddCallMethodExpression("map")
                     .AddParameterOfLamdaNewInstance().SetLamdaParameter("v").SetClassName("Candy");
                map.AddMethod("work")
                    .SetAccessModifiers(AccessModifiers.Public)
                    .SetReturnType("void")
                    .StepStatement("System.out.println(123);");
                chain.AddCallMethodExpression("collect").AddParameter("Collectors.toList()");
            }

            //welcome
            codeMethod.StepEmpty();
            {
                var chain = codeMethod.StepStatementChain("student");
                var map = chain.AddCallMethodExpression("welcome")
                     .AddParameterOfNewInstance().SetClassName("Candy");
                map.AddMethod("work")
                    .SetAccessModifiers(AccessModifiers.Public)
                    .SetReturnType("void")
                    .StepStatement("System.out.println(456);");
            }

        }

        protected override string PrepareExpected()
        {
            return @"public void TestMethod() {

    List<String> items = Lists.newArrayList();

    List<Integer> lengths = items.stream().map(v -> v.length()).collect(Collectors.toList());

    List<Apple> apples = items.stream()
            .map(v -> new Apple()).collect(Collectors.toList());

    List<Banana> bananas = items.stream()
            .map(v -> new Banana(""tom"", 12)).collect(Collectors.toList());

    List<Candy> candys = items.stream().map(v -> new Candy() {

        @Override
        public void work() {
            System.out.println(123);
        }
    }).collect(Collectors.toList());

    student.welcome(new Candy() {

        @Override
        public void work() {
            System.out.println(456);
        }
    });
}
";
        }
    }
}
