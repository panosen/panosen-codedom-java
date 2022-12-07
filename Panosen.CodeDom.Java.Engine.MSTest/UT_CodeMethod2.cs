using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeMethod2
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().Generate(option, builder, new GenerateOptions
            {
                UseJavaDoc = true
            });

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected string PrepareExpected()
        {
            return @"/**
 * TestMethod
 *
 * @param name name
 * @param age age
 * @return int
 */
public int TestMethod(String name, int age) {
    return 0;
}
";
        }

        protected Code PrepareCode()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.AccessModifiers = AccessModifiers.Public;
            codeMethod.Name = "TestMethod";
            codeMethod.ReturnType = "int";

            codeMethod.Parameters = new List<CodeParameter>();
            codeMethod.Parameters.Add(new CodeParameter { Name = "name", Type = "String" });
            codeMethod.Parameters.Add(new CodeParameter { Name = "age", Type = "int" });

            codeMethod.StepStatement("return 0;");

            return codeMethod;

        }
    }
}
