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
        /// GenerateTryStep
        /// </summary>
        public void GenerateTryStep(TryStep tryStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (tryStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.TRY);

            if (!string.IsNullOrEmpty(tryStep.Condition))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(tryStep.Condition).Write(Marks.RIGHT_BRACKET);
            }

            GenerateStepOrCollectionListAsPartialBlock(tryStep.Steps, codeWriter, options);

            if (tryStep.CatchSteps != null && tryStep.CatchSteps.Count > 0)
            {
                foreach (var catchStep in tryStep.CatchSteps)
                {
                    GenerateCacheStep(catchStep, codeWriter, options);
                }
            }

            GenerateFinallyStep(tryStep.FinallyStep, codeWriter, options);

            codeWriter.WriteLine();
        }
    }
}
