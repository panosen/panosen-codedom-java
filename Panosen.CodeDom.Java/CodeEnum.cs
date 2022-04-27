using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 枚举
    /// </summary>
    public class CodeEnum : CodeObject
    {
        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public List<CodeEnumValue> ValueList { get; set; }
    }

    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class CodeEnumExtension
    {
        /// <summary>
        /// 设置访问修饰符
        /// </summary>
        public static TCodeEnum SetAccessModifiers<TCodeEnum>(this TCodeEnum codeEnum, AccessModifiers accessModifiers) where TCodeEnum : CodeEnum
        {
            codeEnum.AccessModifiers = accessModifiers;

            return codeEnum;
        }

        /// <summary>
        /// 添加枚举值
        /// </summary>
        public static TCodeEnum AddValue<TCodeEnum>(this TCodeEnum codeEnum, CodeEnumValue enumValue) where TCodeEnum : CodeEnum
        {
            if (codeEnum.ValueList == null)
            {
                codeEnum.ValueList = new List<CodeEnumValue>();
            }

            codeEnum.ValueList.Add(enumValue);

            return codeEnum;
        }

        /// <summary>
        /// 添加枚举值
        /// </summary>
        public static CodeEnumValue AddValue(this CodeEnum codEnum, string name, string summary = null, DataItem value = null)
        {
            if (codEnum.ValueList == null)
            {
                codEnum.ValueList = new List<CodeEnumValue>();
            }

            CodeEnumValue codeField = new CodeEnumValue();
            codeField.Name = name;
            codeField.Summary = summary;
            codeField.Value = value;

            codEnum.ValueList.Add(codeField);

            return codeField;
        }
    }
}
