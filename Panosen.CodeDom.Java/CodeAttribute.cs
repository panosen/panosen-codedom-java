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
        public List<CodeValue> ParamList { get; set; }

        /// <summary>
        /// ParamMap
        /// </summary>
        public Dictionary<string, CodeValue> ParamMap { get; set; }
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
                codeAttribute.ParamList = new List<CodeValue>();
            }

            CodeValue codeValue = new CodeValue();
            codeValue.Type = CodeValueType.PLAIN;
            codeValue.Value = value;

            codeAttribute.ParamList.Add(codeValue);

            return codeAttribute;
        }

        /// <summary>
        /// AddStringParam
        /// </summary>
        public static CodeAttribute AddStringParam(this CodeAttribute codeAttribute, string value)
        {
            if (codeAttribute.ParamList == null)
            {
                codeAttribute.ParamList = new List<CodeValue>();
            }

            CodeValue codeValue = new CodeValue();
            codeValue.Type = CodeValueType.STRING;
            codeValue.Value = value;

            codeAttribute.ParamList.Add(codeValue);

            return codeAttribute;
        }

        /// <summary>
        /// AddPlainParam
        /// </summary>
        public static CodeAttribute AddPlainParam(this CodeAttribute codeAttribute, string key, string value)
        {
            if (codeAttribute.ParamMap == null)
            {
                codeAttribute.ParamMap = new Dictionary<string, CodeValue>();
            }

            if (codeAttribute.ParamMap.ContainsKey(key))
            {
                return codeAttribute;
            }

            CodeValue codeValue = new CodeValue();
            codeValue.Type = CodeValueType.PLAIN;
            codeValue.Value = value;

            codeAttribute.ParamMap.Add(key, codeValue);

            return codeAttribute;
        }

        /// <summary>
        /// AddStringParam
        /// </summary>
        public static CodeAttribute AddStringParam(this CodeAttribute codeAttribute, string key, string value)
        {
            if (codeAttribute.ParamMap == null)
            {
                codeAttribute.ParamMap = new Dictionary<string, CodeValue>();
            }

            if (codeAttribute.ParamMap.ContainsKey(key))
            {
                return codeAttribute;
            }

            CodeValue codeValue = new CodeValue();
            codeValue.Type = CodeValueType.STRING;
            codeValue.Value = value;

            codeAttribute.ParamMap.Add(key, codeValue);

            return codeAttribute;
        }

    }
}
