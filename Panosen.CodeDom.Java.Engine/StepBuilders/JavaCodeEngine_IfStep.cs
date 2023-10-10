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
        /// GenerateIfStep
        /// </summary>
        /// <param name="ifStep"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateIfStep(IfStep ifStep, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.IF).Write(Marks.WHITESPACE)
                .Write(Marks.LEFT_BRACKET).Write(ifStep.Condition ?? string.Empty).Write(Marks.RIGHT_BRACKET);

            GenerateStepOrCollectionListAsPartialBlock(ifStep.Steps, codeWriter, options);

            if (ifStep.ElseIfSteps != null && ifStep.ElseIfSteps.Count > 0)
            {
                foreach (var elseIfStep in ifStep.ElseIfSteps)
                {
                    GenerateElseIfStep(elseIfStep, codeWriter, options);
                }
            }

            if (ifStep.ElseStep != null)
            {
                GenerateElseStep(ifStep.ElseStep, codeWriter, options);
            }

            codeWriter.WriteLine();
        }
    }
}
