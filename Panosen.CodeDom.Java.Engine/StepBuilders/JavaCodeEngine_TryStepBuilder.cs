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
        /// GenerateTryStepBuilder
        /// </summary>
        public void GenerateTryStepBuilder(TryStepBuilder tryStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (tryStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.TRY);

            GenerateStepBuilderOrCollectionListAsPartialBlock(tryStepBuilder.StepBuilders, codeWriter, options);

            if (tryStepBuilder.CatchStepBuilders != null && tryStepBuilder.CatchStepBuilders.Count > 0)
            {
                foreach (var catchStepBuilder in tryStepBuilder.CatchStepBuilders)
                {
                    GenerateCacheStepBuilder(catchStepBuilder, codeWriter, options);
                }
            }

            GenerateFinallyStepBuilder(tryStepBuilder.FinallyStepBuilder, codeWriter, options);

            codeWriter.WriteLine();
        }
    }
}
