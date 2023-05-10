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

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeAttribute> AttributeList { get; set; }
    }

    /// <summary>
    /// CodeInterfaceExtension
    /// </summary>
    public static class CodeInterfaceExtension
    {

        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeInterface AddAttribute(this CodeInterface codeInterface, CodeAttribute codeAttribute)
        {
            if (codeInterface.AttributeList == null)
            {
                codeInterface.AttributeList = new List<CodeAttribute>();
            }

            codeInterface.AttributeList.Add(codeAttribute);

            return codeInterface;
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeAttribute AddAttribute(this CodeInterface codeInterface, string name)
        {
            if (codeInterface.AttributeList == null)
            {
                codeInterface.AttributeList = new List<CodeAttribute>();
            }

            CodeAttribute codeAttribute = new CodeAttribute();
            codeAttribute.Name = name;

            codeInterface.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

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
        /// 添加一个方法
        /// </summary>
        public static CodeMethod AddMethod(this CodeInterface codeInterface, string name, string summary = null)
        {
            if (codeInterface.MethodList == null)
            {
                codeInterface.MethodList = new List<CodeMethod>();
            }

            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = name;
            codeMethod.Summary = summary;

            codeInterface.MethodList.Add(codeMethod);

            return codeMethod;
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
