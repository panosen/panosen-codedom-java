using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass3 : UTCodeClassBase
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
    private static final String Field0;

    /**
     * 字段 1
     */
    private static final String Field1;

    private final String SQL1 = ""plain_field_0"" +
        ""plain_field_1"" +
        ""plain_field_2"";

    private static String SQL2 = ""string_field_0"" +
        ""string_field_1"" +
        ""string_field_2"";
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
                var field = codeClass.AddField("String", $"Field{i}", summary: $"字段 {i}");
                field.IsFinal = true;
                field.IsStatic = true;
            }

            {
                CodeField codeField = new CodeField();
                codeClass.FieldList.Add(codeField);
                codeField.Type = "String";
                codeField.Name = "SQL1";
                codeField.IsFinal = true;

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
                codeField.IsStatic = true;

                for (int i = 0; i < 3; i++)
                {
                    codeField.AddStringValue($"string_field_{i}");
                }
            }

            return codeClass;
        }
    }
}
