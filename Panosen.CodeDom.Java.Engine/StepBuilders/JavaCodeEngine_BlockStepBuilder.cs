using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        private void GenerateBlockStepBuilder(BlockStepBuilder blockStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            GenerateStepBuilderOrCollectionList(blockStepBuilder.StepBuilders, codeWriter, options);

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
