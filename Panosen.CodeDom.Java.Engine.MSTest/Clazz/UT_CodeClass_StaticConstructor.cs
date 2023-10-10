using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass_StaticConstructor
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().GenerateClass(option, builder, new GenerateOptions
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
 * 学生
 */
public class Student {

    static {
        GSON = null;
    }
}
";
        }

        protected CodeClass PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            var staticConstructor = codeClass.AddStaticConstructor();
            staticConstructor.StepStatement("GSON = null;");

            return codeClass;
        }
    }
}
