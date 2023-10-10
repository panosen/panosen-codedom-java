using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeAttribute
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().GenerateClass(option, builder, new GenerateOptions());

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected string PrepareExpected()
        {
            return @"public class Student {

    @Apple
    @Banana(1)
    @Candy(""2"")
    @Dog(""3"", name = ""4"")
    private int property0;

    public int getProperty0() {
        return property0;
    }

    public void setProperty0(int property0) {
        this.property0 = property0;
    }
}
";
        }

        protected CodeClass PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.AccessModifiers = AccessModifiers.Public;

            {
                var codeProperty = codeClass.AddProperty("int", $"Property0");
                codeProperty.AddAttribute("Apple");
                codeProperty.AddAttribute("Banana").AddPlainParam("1");
                codeProperty.AddAttribute("Candy").AddStringParam("2");
                codeProperty.AddAttribute("Dog").AddStringParam("3").AddStringParam("name", "4");
            }

            return codeClass;
        }
    }
}
