using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        private void GenerateStatementChainStep(StatementChainStep statementChainStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (statementChainStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString);

            if (!string.IsNullOrEmpty(statementChainStep.Target))
            {
                codeWriter.Write(statementChainStep.Target);
            }

            if (statementChainStep.CallMethodExpressions != null && statementChainStep.CallMethodExpressions.Count != 0)
            {
                for (int i = 0; i < statementChainStep.CallMethodExpressions.Count; i++)
                {
                    GenerateStatementChainStep_Chain(statementChainStep.CallMethodExpressions[i], codeWriter, options, i > 0 || !string.IsNullOrEmpty(statementChainStep.Target));
                }
            }

            codeWriter.WriteLine(Marks.SEMICOLON);
        }

        private void GenerateStatementChainStep_Chain(CallMethodExpression callMethodExpression, CodeWriter codeWriter, GenerateOptions options, bool withDot)
        {
            if (callMethodExpression.StartFromNewLine)
            {
                options.PushIndent();
                options.PushIndent();

                codeWriter.WriteLine();
                codeWriter.Write(options.IndentString);
            }

            if (withDot)
            {
                codeWriter.Write(Marks.DOT);
            }
            GenerateCallMethodExpression(callMethodExpression, codeWriter, options);

            if (callMethodExpression.StartFromNewLine)
            {
                options.PopIndent();
                options.PopIndent();
            }
        }
    }
}
