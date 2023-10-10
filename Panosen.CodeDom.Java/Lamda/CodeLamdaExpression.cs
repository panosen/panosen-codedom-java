using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// ${Parameter} => ${Expression}
    /// </summary>
    public sealed class CodeLamdaExpression : DataItem
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// ${Expression}
        /// </summary>
        public string Expression { get; set; }
    }

    /// <summary>
    /// CodeLamdaExpressionExtension
    /// </summary>
    public static class CodeLamdaExpressionExtension
    {
        /// <summary>
        /// SetParameter
        /// </summary>
        public static CodeLamdaExpression SetParameter(this CodeLamdaExpression lamda, string parameter)
        {
            lamda.Parameter = parameter;

            return lamda;
        }

        /// <summary>
        /// SetExpression
        /// </summary>
        public static CodeLamdaExpression SetExpression(this CodeLamdaExpression lamda, string expression)
        {
            lamda.Expression = expression;

            return lamda;
        }
    }
}
