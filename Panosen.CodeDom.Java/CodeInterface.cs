using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 接口
    /// </summary>
    public class CodeInterface : CodeObject
    {
        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public List<CodeMethod> MethodList { get; set; }

        /// <summary>
        /// 继承的接口
        /// </summary>
        public CodeInterface BaseInterface { get; set; }
    }

    /// <summary>
    /// CodeInterfaceExtension
    /// </summary>
    public static class CodeInterfaceExtension
    {
        /// <summary>
        /// AddMethod
        /// </summary>
        public static CodeInterface AddMethod(this CodeInterface codeInterface, CodeMethod codeMethod)
        {
            if (codeInterface.MethodList == null)
            {
                codeInterface.MethodList = new List<CodeMethod>();
            }

            codeInterface.MethodList.Add(codeMethod);

            return codeInterface;
        }

        /// <summary>
        /// SetBaseInterface
        /// </summary>
        public static CodeInterface SetBaseInterface(this CodeInterface codeInterface, string name, string summary = null)
        {
            CodeInterface baseCodeInterface = new CodeInterface();
            baseCodeInterface.Name = name;
            baseCodeInterface.Summary = summary;

            codeInterface.BaseInterface = baseCodeInterface;

            return codeInterface;
        }
    }
}
