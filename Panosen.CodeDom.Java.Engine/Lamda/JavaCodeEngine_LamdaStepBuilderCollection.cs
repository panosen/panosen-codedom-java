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
        /// ${param} => ${expression}
        /// </summary>
        public void GenerateLamdaStepBuilderCollection(CodeLamdaStepBuilderCollection lamda, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (lamda == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            /*
             x =>
             {
                 //do
             }
             */
            codeWriter.Write(lamda.Parameter)
                .Write(Marks.WHITESPACE).Write(Marks.EQUAL).WriteLine(Marks.GREATER_THAN);

            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            GenerateStepBuilderOrCollectionList(lamda.StepBuilders, codeWriter, options);

            options.PopIndent();
            codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);
        }
    }
}
