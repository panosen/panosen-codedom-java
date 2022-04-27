using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeEnum2 : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/**
 * 状态
 */
public enum Status {

    None(),

    Active(1),

    Inactive(2);

    private final int value;

    Status() {
        this.value = 0;
    }

    Status(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}
";
        }

        protected override Code PrepareCode()
        {
            CodeEnum codeEnum = new CodeEnum();
            codeEnum.Name = "Status";
            codeEnum.Summary = "状态";
            codeEnum.AccessModifiers = AccessModifiers.Public;

            codeEnum.AddValue("None");
            codeEnum.AddValue("Active", value: (DataValue)1);
            codeEnum.AddValue("Inactive", value: (DataValue)2);

            return codeEnum;
        }
    }
}
