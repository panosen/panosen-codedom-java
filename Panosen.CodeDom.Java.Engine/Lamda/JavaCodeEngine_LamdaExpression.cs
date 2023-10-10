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
        public void GenerateLamdaExpression(CodeLamdaExpression lamda, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (lamda == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            // x -> new ${ClassName}
            codeWriter.Write(lamda.Parameter)
                .Write(Marks.WHITESPACE).Write(Marks.MINUS).Write(Marks.GREATER_THAN).Write(Marks.WHITESPACE)
                .Write(lamda.Expression);
        }
    }
}
