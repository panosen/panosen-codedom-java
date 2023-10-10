using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    /// <summary>
    /// 生成表达式
    /// </summary>
    partial class JavaCodeEngine
    {
        /// <summary>
        /// GenerateExpresion
        /// </summary>
        public void GenerateExpresion(CodeWriter codeWriter, CodeExpression codeExpression, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeExpression is CallMethodExpression)
            {
                GenerateCallMethodExpression(codeExpression as CallMethodExpression, codeWriter, options);
                return;
            }
        }
    }
}
