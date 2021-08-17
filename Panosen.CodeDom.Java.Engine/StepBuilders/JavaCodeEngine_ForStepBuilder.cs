using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    public partial class JavaCodeEngine
    {
        /// <summary>
        /// GenerateForStepBuilder
        /// </summary>
        public void GenerateForStepBuilder(ForStepBuilder forStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.FOR).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET)
                .Write(forStepBuilder.Start ?? string.Empty).Write(Marks.SEMICOLON).Write(Marks.WHITESPACE)
                .Write(forStepBuilder.Middle ?? string.Empty).Write(Marks.SEMICOLON).Write(Marks.WHITESPACE)
                .Write(forStepBuilder.End ?? string.Empty)
                .Write(Marks.RIGHT_BRACKET)
                .Write(Marks.WHITESPACE);

            GenerateStepBuilderOrCollectionListAsBlock(forStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
