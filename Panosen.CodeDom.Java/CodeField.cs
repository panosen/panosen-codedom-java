using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 字段
    /// </summary>
    public class CodeField : CodeMember
    {

        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 是否是只读字段
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// static
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeAttribute> AttributeList { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public List<CodeValue> ValueList { get; set; }
    }

    /// <summary>
    /// CodeFieldExtension
    /// </summary>
    public static class CodeFieldExtension
    {
        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeField AddAttribute(this CodeField codeField, CodeAttribute codeAttribute)
        {
            if (codeField.AttributeList == null)
            {
                codeField.AttributeList = new List<CodeAttribute>();
            }

            codeField.AttributeList.Add(codeAttribute);

            return codeField;
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeAttribute AddAttribute(this CodeField codeField, string name)
        {
            if (codeField.AttributeList == null)
            {
                codeField.AttributeList = new List<CodeAttribute>();
            }

            CodeAttribute codeAttribute = new CodeAttribute();
            codeAttribute.Name = name;

            codeField.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        /// <summary>
        /// AddValue
        /// </summary>
        public static CodeField AddValue(this CodeField codeField, CodeValue codeValue)
        {
            if (codeField.ValueList == null)
            {
                codeField.ValueList = new List<CodeValue>();
            }

            codeField.ValueList.Add(codeValue);

            return codeField;
        }

        /// <summary>
        /// AddStringValue
        /// </summary>
        public static CodeField AddStringValue(this CodeField codeField, string value)
        {
            if (codeField.ValueList == null)
            {
                codeField.ValueList = new List<CodeValue>();
            }

            CodeValue codeValue = new CodeValue();
            codeValue.Type = CodeValueType.STRING;
            codeValue.Value = value;
            codeField.ValueList.Add(codeValue);

            return codeField;
        }

        /// <summary>
        /// AddPlainValue
        /// </summary>
        public static CodeField AddPlainValue(this CodeField codeField, string value)
        {
            if (codeField.ValueList == null)
            {
                codeField.ValueList = new List<CodeValue>();
            }

            CodeValue codeValue = new CodeValue();
            codeValue.Type = CodeValueType.PLAIN;
            codeValue.Value = value;
            codeField.ValueList.Add(codeValue);

            return codeField;
        }
    }
}
