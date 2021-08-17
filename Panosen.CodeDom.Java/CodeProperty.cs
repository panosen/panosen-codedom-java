using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// CodePropery
    /// </summary>
    public class CodeProperty : CodeMember
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
        /// 特性
        /// </summary>
        public List<CodeAttribute> AttributeList { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public List<CodeValue> ValueList { get; set; }

        /// <summary>
        /// static
        /// </summary>
        public bool IsStatic { get; internal set; }
    }

    /// <summary>
    /// CodePropertyExtension
    /// </summary>
    public static class CodePropertyExtension
    {
        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeProperty AddAttribute(this CodeProperty codeProperty, CodeAttribute codeAttribute)
        {
            if (codeProperty.AttributeList == null)
            {
                codeProperty.AttributeList = new List<CodeAttribute>();
            }

            codeProperty.AttributeList.Add(codeAttribute);

            return codeProperty;
        }

        /// <summary>
        /// Addtribute
        /// </summary>
        public static CodeAttribute AddAttribute(this CodeProperty codeProperty, string name)
        {
            if (codeProperty.AttributeList == null)
            {
                codeProperty.AttributeList = new List<CodeAttribute>();
            }

            CodeAttribute codeAttribute = new CodeAttribute();
            codeAttribute.Name = name;

            codeProperty.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        /// <summary>
        /// AddValue
        /// </summary>
        public static CodeProperty AddValue(this CodeProperty codeProperty, CodeValue codeValue)
        {
            if (codeProperty.ValueList == null)
            {
                codeProperty.ValueList = new List<CodeValue>();
            }

            codeProperty.ValueList.Add(codeValue);

            return codeProperty;
        }

        /// <summary>
        /// AddStringValue
        /// </summary>
        public static CodeProperty AddStringValue(this CodeProperty codeProperty, string value)
        {
            if (codeProperty.ValueList == null)
            {
                codeProperty.ValueList = new List<CodeValue>();
            }

            CodeValue codeValue = new CodeValue();
            codeValue.Type = CodeValueType.STRING;
            codeValue.Value = value;
            codeProperty.ValueList.Add(codeValue);

            return codeProperty;
        }

        /// <summary>
        /// AddPlainValue
        /// </summary>
        public static CodeProperty AddPlainValue(this CodeProperty codeProperty, string value)
        {
            if (codeProperty.ValueList == null)
            {
                codeProperty.ValueList = new List<CodeValue>();
            }

            CodeValue codeValue = new CodeValue();
            codeValue.Type = CodeValueType.PLAIN;
            codeValue.Value = value;
            codeProperty.ValueList.Add(codeValue);

            return codeProperty;
        }
    }
}
