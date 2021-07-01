using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 方法参数
    /// </summary>
    public class CodeParameter : CodeObject
    {
        /// <summary>
        /// 参数类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeAttribute> AttributeList { get; set; }
    }


    public static class CodeParameterExtension
    {
        public static TCodeParameter AddAttribute<TCodeParameter>(this TCodeParameter codeParameter, CodeAttribute codeAttribute)
            where TCodeParameter : CodeParameter
        {
            if (codeParameter.AttributeList == null)
            {
                codeParameter.AttributeList = new List<CodeAttribute>();
            }

            codeParameter.AttributeList.Add(codeAttribute);

            return codeParameter;
        }

        public static TCodeParameter AddAttribute<TCodeParameter>(this TCodeParameter codeParameter, string name)
            where TCodeParameter : CodeParameter
        {
            if (codeParameter.AttributeList == null)
            {
                codeParameter.AttributeList = new List<CodeAttribute>();
            }

            CodeAttribute codeAttribute = new CodeAttribute();
            codeAttribute.Name = name;

            codeParameter.AttributeList.Add(codeAttribute);

            return codeParameter;
        }
    }
}
