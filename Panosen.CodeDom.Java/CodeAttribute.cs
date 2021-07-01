using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public class CodeAttribute : CodeObject
    {
        public List<CodeValue> ParamList { get; set; }

        public Dictionary<string, CodeValue> ParamMap { get; set; }
    }


    public static class CodeAttributeExtension
    {
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
