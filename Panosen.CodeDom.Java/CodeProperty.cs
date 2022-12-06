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
        public List<DataItem> ValueList { get; set; }

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
        /// SetName
        /// </summary>
        public static CodeProperty SetName(this CodeProperty codeProperty, string name)
        {
            codeProperty.Name = name;
            return codeProperty;
        }

        /// <summary>
        /// SetSummary
        /// </summary>
        public static CodeProperty SetSummary(this CodeProperty codeProperty, string summary)
        {
            codeProperty.Summary = summary;
            return codeProperty;
        }

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
        public static TCodeProperty AddValue<TCodeProperty>(this TCodeProperty codeProperty, DataItem dataItem) where TCodeProperty : CodeProperty
        {
            if (codeProperty.ValueList == null)
            {
                codeProperty.ValueList = new List<DataItem>();
            }

            codeProperty.ValueList.Add(dataItem);

            return codeProperty;
        }

        /// <summary>
        /// AddStringValue
        /// </summary>
        public static TCodeProperty AddStringValue<TCodeProperty>(this TCodeProperty codeProperty, string value) where TCodeProperty : CodeProperty
        {
            if (codeProperty.ValueList == null)
            {
                codeProperty.ValueList = new List<DataItem>();
            }

            codeProperty.ValueList.Add(DataValue.DoubleQuotationString(value));

            return codeProperty;
        }

        /// <summary>
        /// AddPlainValue
        /// </summary>
        public static CodeProperty AddPlainValue<TCodeProperty>(this TCodeProperty codeProperty, string value) where TCodeProperty : CodeProperty
        {
            if (codeProperty.ValueList == null)
            {
                codeProperty.ValueList = new List<DataItem>();
            }

            codeProperty.ValueList.Add((DataValue)value);

            return codeProperty;
        }
    }
}
