using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeEnum1 : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/**
 * 状态
 */
public enum Status {

    A_0,

    A_1,

    A_2,

    /**
     * of 0
     */
    B_0,

    /**
     * of 1
     */
    B_1,

    /**
     * of 2
     */
    B_2
}
";
        }

        protected override Code PrepareCode()
        {
            CodeEnum codeEnum = new CodeEnum();
            codeEnum.Name = "Status";
            codeEnum.Summary = "状态";
            codeEnum.AccessModifiers = AccessModifiers.Public;

            for (int i = 0; i < 3; i++)
            {
                codeEnum.AddValue($"A_{i}");
            }

            for (int i = 0; i < 3; i++)
            {
                codeEnum.AddValue($"B_{i}", summary: $"of {i}");
            }

            return codeEnum;
        }
    }
}
