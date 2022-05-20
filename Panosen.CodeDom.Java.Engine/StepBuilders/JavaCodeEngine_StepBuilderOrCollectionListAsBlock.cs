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
        /// GenerateStepBuilderOrCollectionListAsPartialBlock
        /// </summary>
        public void GenerateStepBuilderOrCollectionListAsPartialBlock(List<StepBuilderOrCollection> stepBuilders, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            GenerateStepBuilderOrCollectionList(stepBuilders, codeWriter, options);

            options.PopIndent();
            codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);
        }

        /// <summary>
        /// GenerateStepBuilderOrCollectionListAsBlock
        /// </summary>
        public void GenerateStepBuilderOrCollectionListAsBlock(List<StepBuilderOrCollection> stepBuilders, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            GenerateStepBuilderOrCollectionList(stepBuilders, codeWriter, options);

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
