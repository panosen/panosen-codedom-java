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
        /// GenerateMethod
        /// </summary>
        public void GenerateStaticConstructor(StaticConstructor staticConstructor, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (staticConstructor == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.STATIC).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            foreach (var stepBuilder in staticConstructor.Steps)
            {
                GenerateStepOrCollection(stepBuilder, codeWriter, options);
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
