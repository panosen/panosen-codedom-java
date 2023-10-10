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
        /// GenerateForStep
        /// </summary>
        public void GenerateForStep(ForStep forStep, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.FOR).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET)
                .Write(forStep.Start ?? string.Empty).Write(Marks.SEMICOLON).Write(Marks.WHITESPACE)
                .Write(forStep.Middle ?? string.Empty).Write(Marks.SEMICOLON).Write(Marks.WHITESPACE)
                .Write(forStep.End ?? string.Empty)
                .Write(Marks.RIGHT_BRACKET)
                .Write(Marks.WHITESPACE);

            GenerateStepOrCollectionListAsBlock(forStep.Steps, codeWriter, options);
        }
    }
}
