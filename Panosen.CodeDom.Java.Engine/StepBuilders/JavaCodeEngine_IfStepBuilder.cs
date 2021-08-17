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
            codeWriter.Write(options.IndentString).Write(Keywords.IF).Write(Marks.WHITESPACE)
                .Write(Marks.LEFT_BRACKET).Write(ifStepBuilder.Condition ?? string.Empty).Write(Marks.RIGHT_BRACKET);

            GenerateStepBuilderOrCollectionListAsPartialBlock(ifStepBuilder.StepBuilders, codeWriter, options);

            if (ifStepBuilder.ElseIfStepBuilders != null && ifStepBuilder.ElseIfStepBuilders.Count > 0)
            {
                foreach (var elseIfStepBuilder in ifStepBuilder.ElseIfStepBuilders)
                {
                    GenerateElseIfStepBuilder(elseIfStepBuilder, codeWriter, options);
                }
            }

            if (ifStepBuilder.ElseStepBuilder != null)
            {
                GenerateElseStepBuilder(ifStepBuilder.ElseStepBuilder, codeWriter, options);
            }

            codeWriter.WriteLine();
        }
    }
}
