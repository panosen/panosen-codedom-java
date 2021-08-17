using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        private void GenerateElseIfStepBuilder(ElseIfStepBuilder elseIfStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (elseIfStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.WHITESPACE).Write(Keywords.ELSE).Write(Marks.WHITESPACE)
                .Write(Keywords.IF).Write(Marks.WHITESPACE)
                .Write(Marks.LEFT_BRACKET).Write(elseIfStepBuilder.Condition ?? string.Empty)
                .Write(Marks.RIGHT_BRACKET);

            GenerateStepBuilderOrCollectionListAsPartialBlock(elseIfStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
