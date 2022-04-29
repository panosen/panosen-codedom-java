using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass2
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().Generate(option, builder, new GenerateOptions
            {
                UseJavaCoc = true
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

    /**
     * 属性 0
     */
    private int property0;

    /**
     * TheConstructor
     */
    public TheConstructor() {
    }

    /**
     * [getter] 属性 0
     *
     * @return int
     */
    public int getProperty0() {
        return property0;
    }

    /**
     * [setter] 属性 0
     *
     * @param property0 property0
     */
    public void setProperty0(int property0) {
        this.property0 = property0;
    }

    /**
     * 方法 0
     *
     * @param p1 p1
     * @param p2 okok
     * @param p3 p3
     * @return int
     */
    public int Method0(int p1, int p2, int p3) {
    }
}
";
        }

        protected Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            {
                codeClass.AddProperty("int", $"Property0", summary: $"属性 0");
            }

            {
                var codeMethod = codeClass.AddMethod($"Method0", summary: $"方法 0");
                codeMethod.ReturnType = "int";
                codeMethod.AccessModifiers = AccessModifiers.Public;

                for (int j = 0; j < 3; j++)
                {
                    var codeParam = codeMethod.AddParameter("int", $"p{j + 1}");
                    if (j == 1)
                    {
                        codeParam.Summary = "okok";
                    }
                }

                codeMethod.StepBuilders = new List<StepBuilderOrCollection>();
            }

            codeClass.AddConstructor(new CodeMethod
            {
                Name = "TheConstructor",
                AccessModifiers = AccessModifiers.Public,
                StepBuilders = new List<StepBuilderOrCollection>()
            });

            return codeClass;
        }
    }
}
