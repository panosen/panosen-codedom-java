using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    public partial class JavaCodeEngine
    {
        public void GenerateBracketStepBuilder(BracketStepBuilder bracketStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString);

            if (bracketStepBuilder.Key != null)
            {
                codeWriter.Write(bracketStepBuilder.Key ?? string.Empty).Write(Marks.WHITESPACE);
            }

            StepBlocks(codeWriter, options, bracketStepBuilder.StepBuilders, bracketStepBuilder.EndWith);
        }
    }
}
