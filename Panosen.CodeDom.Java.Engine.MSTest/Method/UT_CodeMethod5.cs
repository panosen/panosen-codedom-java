using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeMethod5
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().GenerateMethod(option, builder, new GenerateOptions
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
 * @return int
 */
public int TestMethod() {

}
";
        }

        protected CodeMethod PrepareCode()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.AccessModifiers = AccessModifiers.Public;
            codeMethod.Name = "TestMethod";
            codeMethod.ReturnType = "int";

            codeMethod.StepEmpty();

            return codeMethod;

        }
    }
}
