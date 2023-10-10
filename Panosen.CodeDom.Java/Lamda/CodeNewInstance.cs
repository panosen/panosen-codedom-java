using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// new Item { }
    /// </summary>
    public sealed class CodeNewInstance : DataItem
    {
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public List<DataItem> ConstructorParameters { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public List<CodeMethod> MethodList { get; set; }
    }

    /// <summary>
    /// CodeNewInstanceExtension
    /// </summary>
    public static class CodeNewInstanceExtension
    {
        /// <summary>
        /// SetBooleanExpression
        /// </summary>
        public static CodeNewInstance SetClassName(this CodeNewInstance codeNewInstanceExpression, string className)
        {
            codeNewInstanceExpression.ClassName = className;

            return codeNewInstanceExpression;
        }

        #region 构造函数的参数

        /// <summary>
        /// AddValue
        /// </summary>
        public static CodeNewInstance AddValue(this CodeNewInstance codeField, DataItem value)
        {
            if (codeField.ConstructorParameters == null)
            {
                codeField.ConstructorParameters = new List<DataItem>();
            }

            codeField.ConstructorParameters.Add(value);

            return codeField;
        }

        /// <summary>
        /// AddStringValue
        /// </summary>
        public static CodeNewInstance AddStringValue(this CodeNewInstance codeField, string value)
        {
            if (codeField.ConstructorParameters == null)
            {
                codeField.ConstructorParameters = new List<DataItem>();
            }

            codeField.ConstructorParameters.Add(DataValue.DoubleQuotationString(value));

            return codeField;
        }

        /// <summary>
        /// AddPlainValue
        /// </summary>
        public static CodeNewInstance AddPlainValue(this CodeNewInstance codeField, string value)
        {
            if (codeField.ConstructorParameters == null)
            {
                codeField.ConstructorParameters = new List<DataItem>();
            }

            codeField.ConstructorParameters.Add((DataValue)value);

            return codeField;
        }

        #endregion


        #region 实例内部方法

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static CodeNewInstance AddMethod(this CodeNewInstance codeNewInstance, CodeMethod codeMethod)
        {
            if (codeNewInstance.MethodList == null)
            {
                codeNewInstance.MethodList = new List<CodeMethod>();
            }

            codeNewInstance.MethodList.Add(codeMethod);

            return codeNewInstance;
        }

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static CodeMethod AddMethod(this CodeNewInstance codeNewInstance, string name, string summary = null)
        {
            if (codeNewInstance.MethodList == null)
            {
                codeNewInstance.MethodList = new List<CodeMethod>();
            }

            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = name;
            codeMethod.Summary = summary;

            codeNewInstance.MethodList.Add(codeMethod);

            return codeMethod;
        }

        /// <summary>
        /// 添加一批方法
        /// </summary>
        public static CodeNewInstance AddMethods(this CodeNewInstance codeNewInstance, List<CodeMethod> codeMethods)
        {
            if (codeMethods == null || codeMethods.Count == 0)
            {
                return codeNewInstance;
            }

            if (codeNewInstance.MethodList == null)
            {
                codeNewInstance.MethodList = new List<CodeMethod>();
            }

            codeNewInstance.MethodList.AddRange(codeMethods);

            return codeNewInstance;
        }
        #endregion
    }
}
