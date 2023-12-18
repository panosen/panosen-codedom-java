using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass1 : UTCodeClassBase
    {
        protected override string PrepareExpected()
        {
            return @"/**
 * 学生
 */
public class Student {

    /**
     * 字段 0
     */
    private String Field0;

    /**
     * 字段 1
     */
    private String Field1;

    private String SQL1 = ""plain_field_0"" +
        ""plain_field_1"" +
        ""plain_field_2"";

    private String SQL2 = ""string_field_0"" +
        ""string_field_1"" +
        ""string_field_2"";

    private int property0;

    /**
     * 属性 1
     */
    private int property1;

    public TheConstructor() {
    }

    public int getProperty0() {
        return property0;
    }

    public void setProperty0(int property0) {
        this.property0 = property0;
    }

    /**
     * [getter] 属性 1
     */
    public int getProperty1() {
        return property1;
    }

    /**
     * [setter] 属性 1
     */
    public void setProperty1(int property1) {
        this.property1 = property1;
    }

    /**
     * 方法 0
     */
    public int Method0(int p1, int p2, int p3) {
    }

    /**
     * 方法 1
     */
    public int Method1(int p1, int p2, int p3) {
    }

    /**
     * 方法 2
     */
    public int Method2(int p1, int p2, int p3) {
    }
}
";
        }

        protected override CodeClass PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            for (int i = 0; i < 2; i++)
            {
                var codeParam = codeClass.AddProperty("int", $"Property{i}");
                if (i == 1)
                {
                    codeParam.Summary = $"属性 {i}";
                }
            }

            for (int i = 0; i < 2; i++)
            {
                codeClass.AddField("String", $"Field{i}", summary: $"字段 {i}");
            }

            {
                CodeField codeField = new CodeField();
                codeClass.FieldList.Add(codeField);
                codeField.Type = "String";
                codeField.Name = "SQL1";

                for (int i = 0; i < 3; i++)
                {
                    codeField.AddPlainValue($"\"plain_field_{i}\"");
                }
            }
            {
                CodeField codeField = new CodeField();
                codeClass.FieldList.Add(codeField);
                codeField.Type = "String";
                codeField.Name = "SQL2";

                for (int i = 0; i < 3; i++)
                {
                    codeField.AddStringValue($"string_field_{i}");
                }
            }

            codeClass.MethodList = new List<CodeMethod>();
            for (int i = 0; i < 3; i++)
            {
                var codeMethod = codeClass.AddMethod($"Method{i}", summary: $"方法 {i}");
                codeMethod.ReturnType = "int";
                codeMethod.AccessModifiers = AccessModifiers.Public;

                for (int j = 0; j < 3; j++)
                {
                    codeMethod.AddParameter("int", $"p{j + 1}");
                }

                codeMethod.Steps = new List<StepOrCollection>();
            }

            codeClass.AddConstructor(new CodeMethod
            {
                Name = "TheConstructor",
                AccessModifiers = AccessModifiers.Public,
                Steps = new List<StepOrCollection>()
            });

            return codeClass;
        }
    }
}
