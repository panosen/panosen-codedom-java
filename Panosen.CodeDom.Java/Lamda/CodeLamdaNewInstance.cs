using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// x => new Item { }
    /// </summary>
    public class CodeLamdaNewInstance : DataItem
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 步骤集合
        /// </summary>
        public StepBuilderCollection StepBuilderCollection { get; set; }

        /// <summary>
        /// Statements
        /// </summary>
        public List<string> Statements { get; set; }
    }

    /// <summary>
    /// CodeLamdaNewInstanceExpressionExtension
    /// </summary>
    public static class CodeLamdaNewInstanceExpressionExtension
    {
        /// <summary>
        /// SetParameter
        /// </summary>
        public static TCodeLamdaNewInstanceExpression SetParameter<TCodeLamdaNewInstanceExpression>(this TCodeLamdaNewInstanceExpression codeLamdaNewInstanceExpression, string parameter)
            where TCodeLamdaNewInstanceExpression : CodeLamdaNewInstance
        {
            codeLamdaNewInstanceExpression.Parameter = parameter;

            return codeLamdaNewInstanceExpression;
        }

        /// <summary>
        /// SetBooleanExpression
        /// </summary>
        public static TCodeLamdaNewInstanceExpression SetClassName<TCodeLamdaNewInstanceExpression>(this TCodeLamdaNewInstanceExpression codeLamdaNewInstanceExpression, string className)
            where TCodeLamdaNewInstanceExpression : CodeLamdaNewInstance
        {
            codeLamdaNewInstanceExpression.ClassName = className;

            return codeLamdaNewInstanceExpression;
        }

        /// <summary>
        /// SetBooleanExpression
        /// </summary>
        public static TCodeLamdaNewInstanceExpression StepStatement<TCodeLamdaNewInstanceExpression>(this TCodeLamdaNewInstanceExpression codeLamdaNewInstanceExpression, string statement)
            where TCodeLamdaNewInstanceExpression : CodeLamdaNewInstance
        {
            if (codeLamdaNewInstanceExpression.Statements == null)
            {
                codeLamdaNewInstanceExpression.Statements = new List<string>();
            }

            codeLamdaNewInstanceExpression.Statements.Add(statement);

            return codeLamdaNewInstanceExpression;
        }
    }
}
