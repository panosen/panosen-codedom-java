using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        public void GeneratePushIndentStepBuilder(PushIndentStepBuilder pushIndentStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(pushIndentStepBuilder.Key ?? string.Empty);

            StepIndentBlocks(codeWriter, options, pushIndentStepBuilder.StepBuilders);
        }
    }
}
