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
        public List<DataValue> ParamList { get; set; }

        /// <summary>
        /// ParamMap
        /// </summary>
        public Dictionary<string, DataValue> ParamMap { get; set; }
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
                codeAttribute.ParamList = new List<DataValue>();
            }

            codeAttribute.ParamList.Add(value);

            return codeAttribute;
        }

        /// <summary>
        /// AddStringParam
        /// </summary>
        public static CodeAttribute AddStringParam(this CodeAttribute codeAttribute, string value)
        {
            if (codeAttribute.ParamList == null)
            {
                codeAttribute.ParamList = new List<DataValue>();
            }

            codeAttribute.ParamList.Add(DataValue.DoubleQuotationString(value));

            return codeAttribute;
        }

        /// <summary>
        /// AddPlainParam
        /// </summary>
        public static CodeAttribute AddPlainParam(this CodeAttribute codeAttribute, string key, string value)
        {
            if (codeAttribute.ParamMap == null)
            {
                codeAttribute.ParamMap = new Dictionary<string, DataValue>();
            }

            if (codeAttribute.ParamMap.ContainsKey(key))
            {
                return codeAttribute;
            }

            codeAttribute.ParamMap.Add(key, value);

            return codeAttribute;
        }

        /// <summary>
        /// AddStringParam
        /// </summary>
        public static CodeAttribute AddStringParam(this CodeAttribute codeAttribute, string key, string value)
        {
            if (codeAttribute.ParamMap == null)
            {
                codeAttribute.ParamMap = new Dictionary<string, DataValue>();
            }

            if (codeAttribute.ParamMap.ContainsKey(key))
            {
                return codeAttribute;
            }

            codeAttribute.ParamMap.Add(key, DataValue.DoubleQuotationString(value));

            return codeAttribute;
        }
    }
}
