using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        private void GenerateTryStepBuilder(TryStepBuilder tryStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(KEYWORD_TRY/*try*/).Write(Marks.WHITESPACE/* */);

            var withNewLine = (tryStepBuilder.CatchStepBuilders == null || tryStepBuilder.CatchStepBuilders.Count == 0) && tryStepBuilder.FinallyStepBuilder == null;

            StepBlocks(codeWriter, options, tryStepBuilder.StepBuilders, withNewLine: withNewLine);

            if (tryStepBuilder.CatchStepBuilders != null && tryStepBuilder.CatchStepBuilders.Count > 0)
            {
                foreach (var catchStepBuilder in tryStepBuilder.CatchStepBuilders)
                {
                    codeWriter.Write(Marks.WHITESPACE/* */).Write(KEYWORD_CATCH/*catch*/);

                    if (catchStepBuilder.ExceptionType != null)
                    {
                        codeWriter.Write(Marks.WHITESPACE/* */).Write(Marks.LEFT_BRACKET/*(*/).Write(catchStepBuilder.ExceptionType/*Exception*/);

                        if (catchStepBuilder.ExceptionName != null)
                        {
                            codeWriter.Write(Marks.WHITESPACE/* */).Write(catchStepBuilder.ExceptionName/* e*/);
                        }

                        codeWriter.Write(Marks.RIGHT_BRACKET/*)*/).Write(Marks.WHITESPACE/* */);
                    }

                    StepBlocks(codeWriter, options, catchStepBuilder.StepBuilders, withNewLine: false);
                }
            }

            if (tryStepBuilder.FinallyStepBuilder != null)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(KEYWORD_FINALLY).Write(Marks.WHITESPACE);

                StepBlocks(codeWriter, options, tryStepBuilder.FinallyStepBuilder.StepBuilders, withNewLine: false);
            }

            if (!withNewLine)
            {
                codeWriter.WriteLine();
            }
        }
    }
}
