using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        private void GenerateIfStepBuilder(IfStepBuilder ifStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(KEYWORD_IF).Write(Marks.WHITESPACE)
                .Write(Marks.LEFT_BRACKET).Write(ifStepBuilder.Condition ?? string.Empty).Write(Marks.RIGHT_BRACKET).Write(Marks.WHITESPACE);

            var withNewLine = (ifStepBuilder.ElseIfStepBuilders == null || ifStepBuilder.ElseIfStepBuilders.Count == 0) && ifStepBuilder.ElseStepBuilder == null;

            StepBlocks(codeWriter, options, ifStepBuilder.StepBuilders, withNewLine: withNewLine);

            if (ifStepBuilder.ElseIfStepBuilders != null && ifStepBuilder.ElseIfStepBuilders.Count > 0)
            {
                foreach (var elseIfStepBuilder in ifStepBuilder.ElseIfStepBuilders)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(KEYWORD_ELSE).Write(Marks.WHITESPACE)
                        .Write(KEYWORD_IF).Write(Marks.WHITESPACE)
                        .Write(Marks.LEFT_BRACKET).Write(elseIfStepBuilder.Condition ?? string.Empty)
                        .Write(Marks.RIGHT_BRACKET).Write(Marks.WHITESPACE);

                    StepBlocks(codeWriter, options, elseIfStepBuilder.StepBuilders, withNewLine: false);
                }
            }

            if (ifStepBuilder.ElseStepBuilder != null)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(KEYWORD_ELSE).Write(Marks.WHITESPACE);

                StepBlocks(codeWriter, options, ifStepBuilder.ElseStepBuilder.StepBuilders);
            }
        }
    }
}
