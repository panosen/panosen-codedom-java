﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 方法
    /// </summary>
    public class CodeMethod : CodeObject, IStepCollection
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string ReturnType { get; set; }

        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public List<CodeParameter> Parameters { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeAttribute> AttributeList { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        public List<string> ExceptionList { get; set; }

        /// <summary>
        /// 泛型参数列表
        /// </summary>
        public List<string> GenericTypeList { get; set; }

        /// <summary>
        /// static
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// synchronized
        /// </summary>
        public bool IsSynchronized { get; set; }

        #region IStepCollection Members

        /// <summary>
        /// IStepCollection.Steps
        /// </summary>
        public List<StepOrCollection> Steps { get; set; }

        #endregion
    }

    /// <summary>
    /// CodeMethodExtension
    /// </summary>
    public static class CodeMethodExtension
    {
        /// <summary>
        /// SetReturnType
        /// </summary>
        public static CodeMethod SetReturnType(this CodeMethod codeMethod, string returnType)
        {
            codeMethod.ReturnType = returnType;

            return codeMethod;
        }

        /// <summary>
        /// SetAccessModifiers
        /// </summary>
        public static CodeMethod SetAccessModifiers(this CodeMethod codeMethod, AccessModifiers accessModifiers)
        {
            codeMethod.AccessModifiers = accessModifiers;

            return codeMethod;
        }

        /// <summary>
        /// AddParameter
        /// </summary>
        public static CodeMethod AddParameter(this CodeMethod codeMethod, CodeParameter parameter)
        {
            if (codeMethod.Parameters == null)
            {
                codeMethod.Parameters = new List<CodeParameter>();
            }

            codeMethod.Parameters.Add(parameter);

            return codeMethod;
        }

        /// <summary>
        /// AddParameter
        /// </summary>
        public static CodeParameter AddParameter(this CodeMethod codeMethod, string type, string name, string summary = null)
        {
            if (codeMethod.Parameters == null)
            {
                codeMethod.Parameters = new List<CodeParameter>();
            }

            CodeParameter parameter = new CodeParameter();
            parameter.Name = name;
            parameter.Type = type;
            parameter.Summary = summary;

            codeMethod.Parameters.Add(parameter);

            return parameter;
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeMethod AddAttribute(this CodeMethod codeMethod, CodeAttribute codeAttribute)
        {
            if (codeMethod.AttributeList == null)
            {
                codeMethod.AttributeList = new List<CodeAttribute>();
            }

            codeMethod.AttributeList.Add(codeAttribute);

            return codeMethod;
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeAttribute AddAttribute(this CodeMethod codeMethod, string name)
        {
            if (codeMethod.AttributeList == null)
            {
                codeMethod.AttributeList = new List<CodeAttribute>();
            }

            CodeAttribute codeAttribute = new CodeAttribute();
            codeAttribute.Name = name;

            codeMethod.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        /// <summary>
        /// AddException
        /// </summary>
        public static CodeMethod AddException(this CodeMethod codeMethod, string exception)
        {
            if (codeMethod.ExceptionList == null)
            {
                codeMethod.ExceptionList = new List<string>();
            }

            codeMethod.ExceptionList.Add(exception);

            return codeMethod;
        }

        /// <summary>
        /// AddGenericType
        /// </summary>
        public static CodeMethod AddGenericType(this CodeMethod codeMethod, string genericType)
        {
            if (codeMethod.GenericTypeList == null)
            {
                codeMethod.GenericTypeList = new List<string>();
            }

            codeMethod.GenericTypeList.Add(genericType);

            return codeMethod;
        }
    }
}
