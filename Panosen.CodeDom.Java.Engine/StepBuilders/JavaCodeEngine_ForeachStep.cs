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
        /// GenerateForeachStep
        /// </summary>
        public void GenerateForeachStep(ForeachStep foreachStep, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.FOR).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET)
                .Write(foreachStep.Type ?? string.Empty).Write(Marks.WHITESPACE)
                .Write(foreachStep.Item ?? string.Empty).Write(Marks.WHITESPACE)
                .Write(Marks.COLON).Write(Marks.WHITESPACE)
                .Write(foreachStep.Items ?? string.Empty)
                .Write(Marks.RIGHT_BRACKET)
                .Write(Marks.WHITESPACE);

            GenerateStepOrCollectionListAsBlock(foreachStep.Steps, codeWriter, options);
        }
    }
}
