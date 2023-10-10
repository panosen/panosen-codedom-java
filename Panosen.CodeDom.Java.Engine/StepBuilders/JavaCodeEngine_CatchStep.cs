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
        /// GenerateCacheStep
        /// </summary>
        public void GenerateCacheStep(CatchStep catchStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (catchStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.WHITESPACE).Write(Keywords.CATCH);

            if (!string.IsNullOrEmpty(catchStep.ExceptionType))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(catchStep.ExceptionType);

                if (!string.IsNullOrEmpty(catchStep.ExceptionName))
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(catchStep.ExceptionName);
                }

                codeWriter.Write(Marks.RIGHT_BRACKET);
            }

            GenerateStepOrCollectionListAsPartialBlock(catchStep.Steps, codeWriter, options);
        }
    }
}
