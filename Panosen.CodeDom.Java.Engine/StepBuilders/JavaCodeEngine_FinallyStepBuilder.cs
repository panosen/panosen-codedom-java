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
        /// GenerateFinallyStepBuilder
        /// </summary>
        public void GenerateFinallyStepBuilder(FinallyStepBuilder finallyStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (finallyStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.WHITESPACE).Write(Keywords.FINALLY);

            GenerateStepBuilderOrCollectionListAsPartialBlock(finallyStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
