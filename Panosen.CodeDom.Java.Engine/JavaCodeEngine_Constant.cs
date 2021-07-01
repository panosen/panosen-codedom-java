using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        public void GenerateConstant(CodeConstant codeConstant, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeConstant == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeConstant.Summary, codeWriter, options);
            codeWriter.Write(options.IndentString);

            if (codeConstant.AccessModifiers != null)
            {
                codeWriter.Write(codeConstant.AccessModifiers.Value).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(KEYWORD_CONST).Write(Marks.WHITESPACE);

            codeWriter.Write(codeConstant.Type ?? string.Empty)
                .Write(Marks.WHITESPACE).Write(codeConstant.Name ?? string.Empty)
                .Write(Marks.WHITESPACE).Write(Marks.EQUAL)
                .Write(Marks.WHITESPACE).Write(codeConstant.Value ?? "NULL")
                .WriteLine(Marks.SEMICOLON);
        }
    }
}
