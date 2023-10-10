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
        /// GenerateElseStep
        /// </summary>
        public void GenerateElseStep(ElseStep elseStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (elseStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.WHITESPACE).Write(Keywords.ELSE);

            GenerateStepOrCollectionListAsPartialBlock(elseStep.Steps, codeWriter, options);
        }
    }
}
