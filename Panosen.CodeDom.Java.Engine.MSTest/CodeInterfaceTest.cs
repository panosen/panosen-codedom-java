using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class CodeInterfaceTest : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/**
 * 学生
 */
public interface IStudentRepository {

    /**
     * 方法 0
     */
    int Method0(int p1, int p2, int p3);

    /**
     * 方法 1
     */
    int Method1(int p1, int p2, int p3);

    /**
     * 方法 2
     */
    int Method2(int p1, int p2, int p3);
}
";
        }

        protected override Code PrepareCode()
        {
            CodeInterface codeInterface = new CodeInterface();
            codeInterface.Name = "IStudentRepository";
            codeInterface.Summary = "学生";
            codeInterface.AccessModifiers = AccessModifiers.Public;

            codeInterface.MethodList = new List<CodeMethod>();
            for (int i = 0; i < 3; i++)
            {
                var codeMethod = new CodeMethod();
                codeInterface.MethodList.Add(codeMethod);

                codeMethod.Name = $"Method{i}";
                codeMethod.ReturnType = "int";
                codeMethod.Summary = $"方法 {i}";

                codeMethod.Parameters = new List<CodeParameter>();
                for (int j = 0; j < 3; j++)
                {
                    var codeParameter = new CodeParameter();
                    codeMethod.Parameters.Add(codeParameter);

                    codeParameter.Name = $"p{j + 1}";
                    codeParameter.Type = "int";
                }
            }

            return codeInterface;
        }
    }
}
