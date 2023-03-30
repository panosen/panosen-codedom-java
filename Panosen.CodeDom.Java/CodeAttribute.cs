using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// CodeAttribute
    /// </summary>
    public class CodeAttribute : CodeObject
    {
        /// <summary>
        /// ParamList
        /// </summary>
        public List<CodeAttributeParam> ParamList { get; set; }
    }

    /// <summary>
    /// CodeAttributeExtension
    /// </summary>
    public static class CodeAttributeExtension
    {
        /// <summary>
        /// AddPlainParam
        /// </summary>
        public static CodeAttribute AddPlainParam(this CodeAttribute codeAttribute, string value)
        {
            if (codeAttribute.ParamList == null)
            {
                codeAttribute.ParamList = new List<CodeAttributeParam>();
            }

            codeAttribute.ParamList.Add(new CodeAttributeParam { Value = value });

            return codeAttribute;
        }

        /// <summary>
        /// AddStringParam
        /// </summary>
        public static CodeAttribute AddStringParam(this CodeAttribute codeAttribute, string value)
        {
            if (codeAttribute.ParamList == null)
            {
                codeAttribute.ParamList = new List<CodeAttributeParam>();
            }

            codeAttribute.ParamList.Add(new CodeAttributeParam { Value = DataValue.DoubleQuotationString(value) });

            return codeAttribute;
        }

        /// <summary>
        /// AddPlainParam
        /// </summary>
        public static CodeAttribute AddPlainParam(this CodeAttribute codeAttribute, string key, string value)
        {
            if (codeAttribute.ParamList == null)
            {
                codeAttribute.ParamList = new List<CodeAttributeParam>();
            }

            codeAttribute.ParamList.Add(new CodeAttributeParam { Key = key, Value = value });

            return codeAttribute;
        }

        /// <summary>
        /// AddStringParam
        /// </summary>
        public static CodeAttribute AddStringParam(this CodeAttribute codeAttribute, string key, string value)
        {
            if (codeAttribute.ParamList == null)
            {
                codeAttribute.ParamList = new List<CodeAttributeParam>();
            }

            codeAttribute.ParamList.Add(new CodeAttributeParam { Key = key, Value = DataValue.DoubleQuotationString(value) });

            return codeAttribute;
        }
    }
}
