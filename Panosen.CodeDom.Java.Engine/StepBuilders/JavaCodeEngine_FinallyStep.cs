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
        /// GenerateFinallyStep
        /// </summary>
        public void GenerateFinallyStep(FinallyStep finallyStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (finallyStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.WHITESPACE).Write(Keywords.FINALLY);

            GenerateStepOrCollectionListAsPartialBlock(finallyStep.Steps, codeWriter, options);
        }
    }
}
