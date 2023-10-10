using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// x => new Item { }
    /// </summary>
    public sealed class CodeLamdaNewInstance : DataItem
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string LamdaParameter { get; set; }

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
    /// CodeLamdaNewInstanceExpressionExtension
    /// </summary>
    public static class CodeLamdaNewInstanceExtension
    {
        /// <summary>
        /// SetParameter
        /// </summary>
        public static CodeLamdaNewInstance SetLamdaParameter(this CodeLamdaNewInstance codeLamdaNewInstanceExpression, string parameter)
        {
            codeLamdaNewInstanceExpression.LamdaParameter = parameter;

            return codeLamdaNewInstanceExpression;
        }

        /// <summary>
        /// SetBooleanExpression
        /// </summary>
        public static CodeLamdaNewInstance SetClassName(this CodeLamdaNewInstance codeLamdaNewInstanceExpression, string className)
        {
            codeLamdaNewInstanceExpression.ClassName = className;

            return codeLamdaNewInstanceExpression;
        }

        #region 构造函数的参数

        /// <summary>
        /// AddValue
        /// </summary>
        public static CodeLamdaNewInstance AddValue(this CodeLamdaNewInstance codeField, DataItem value)
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
        public static CodeLamdaNewInstance AddStringValue(this CodeLamdaNewInstance codeField, string value)
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
        public static CodeLamdaNewInstance AddPlainValue(this CodeLamdaNewInstance codeField, string value)
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
        public static CodeLamdaNewInstance AddMethod(this CodeLamdaNewInstance lamda, CodeMethod codeMethod)
        {
            if (lamda.MethodList == null)
            {
                lamda.MethodList = new List<CodeMethod>();
            }

            lamda.MethodList.Add(codeMethod);

            return lamda;
        }

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static CodeMethod AddMethod(this CodeLamdaNewInstance lamda, string name, string summary = null)
        {
            if (lamda.MethodList == null)
            {
                lamda.MethodList = new List<CodeMethod>();
            }

            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = name;
            codeMethod.Summary = summary;

            lamda.MethodList.Add(codeMethod);

            return codeMethod;
        }

        /// <summary>
        /// 添加一批方法
        /// </summary>
        public static CodeLamdaNewInstance AddMethods(this CodeLamdaNewInstance lamda, List<CodeMethod> codeMethods)
        {
            if (codeMethods == null || codeMethods.Count == 0)
            {
                return lamda;
            }

            if (lamda.MethodList == null)
            {
                lamda.MethodList = new List<CodeMethod>();
            }

            lamda.MethodList.AddRange(codeMethods);

            return lamda;
        } 
        #endregion
    }
}
