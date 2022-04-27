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
    public class CodeLamdaExpression : DataItem
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
        public static TCodeLamdaStatementExpression SetParameter<TCodeLamdaStatementExpression>(this TCodeLamdaStatementExpression lamda, string parameter)
            where TCodeLamdaStatementExpression : CodeLamdaExpression
        {
            lamda.Parameter = parameter;

            return lamda;
        }

        /// <summary>
        /// SetExpression
        /// </summary>
        public static TCodeLamdaStatementExpression SetExpression<TCodeLamdaStatementExpression>(this TCodeLamdaStatementExpression lamda, string expression)
            where TCodeLamdaStatementExpression : CodeLamdaExpression
        {
            lamda.Expression = expression;

            return lamda;
        }
    }
}
