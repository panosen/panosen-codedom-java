using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        /// <summary>
        /// GenerateForeachStepBuilder
        /// </summary>
        public void GenerateForeachStepBuilder(ForeachStepBuilder foreachStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.FOR).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET)
                .Write(foreachStepBuilder.Type ?? string.Empty).Write(Marks.WHITESPACE)
                .Write(foreachStepBuilder.Item ?? string.Empty).Write(Marks.WHITESPACE)
                .Write(Marks.COLON).Write(Marks.WHITESPACE)
                .Write(foreachStepBuilder.Items ?? string.Empty)
                .Write(Marks.RIGHT_BRACKET)
                .Write(Marks.WHITESPACE);

            GenerateStepBuilderOrCollectionListAsBlock(foreachStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
