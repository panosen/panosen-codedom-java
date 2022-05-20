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
        /// GenerateElseStepBuilder
        /// </summary>
        public void GenerateElseStepBuilder(ElseStepBuilder elseStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (elseStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.WHITESPACE).Write(Keywords.ELSE);

            GenerateStepBuilderOrCollectionListAsPartialBlock(elseStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
