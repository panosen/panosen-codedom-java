using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 访问修饰符
    /// </summary>
    public enum AccessModifiers
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Public
        /// </summary>
        Public = 1,

        /// <summary>
        /// Private
        /// </summary>
        Private = 2,

        /// <summary>
        /// Protected
        /// </summary>
        Protected = 3
    }

    /// <summary>
    /// AccessModifiersExtension
    /// </summary>
    public static class AccessModifiersExtension
    {
        /// <summary>
        /// 值
        /// </summary>
        /// <param name="accessModifiers"></param>
        /// <returns></returns>
        public static string Value(this AccessModifiers accessModifiers)
        {
            switch (accessModifiers)
            {
                case AccessModifiers.Public:
                    return "public";
                case AccessModifiers.Private:
                    return "private";
                case AccessModifiers.Protected:
                    return "protected";
                case AccessModifiers.None:
                default:
                    return string.Empty;
            }
        }
    }
}
