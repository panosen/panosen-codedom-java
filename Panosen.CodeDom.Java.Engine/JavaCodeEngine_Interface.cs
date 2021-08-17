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
        /// 生成接口
        /// </summary>
        /// <param name="codeInterface"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateInterface(CodeInterface codeInterface, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeInterface == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeInterface.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            if (codeInterface.AccessModifiers != null)
            {
                codeWriter.Write(codeInterface.AccessModifiers.Value).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.INTERFACE).Write(Marks.WHITESPACE).Write(codeInterface.Name ?? string.Empty);

            if (codeInterface.BaseInterface != null)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Keywords.EXTENDS).Write(Marks.WHITESPACE).Write(codeInterface.BaseInterface.Name ?? string.Empty);
            }

            codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            if (codeInterface.MethodList != null && codeInterface.MethodList.Count > 0)
            {
                foreach (var codeMethod in codeInterface.MethodList)
                {
                    codeWriter.WriteLine();
                    GenerateMethod(codeMethod, codeWriter, options);
                }
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
