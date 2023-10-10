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
        /// x => new Studengt()
        /// </summary>
        public void GenerateLamdaNewInstance(CodeLamdaNewInstance lamda, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (lamda == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            // x -> new ${ClassName}
            codeWriter.Write(lamda.LamdaParameter).Write(Marks.WHITESPACE).Write(Marks.MINUS).Write(Marks.GREATER_THAN).Write(Marks.WHITESPACE)
                .Write(Keywords.NEW);

            if (!string.IsNullOrEmpty(lamda.ClassName))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(lamda.ClassName);
            }

            codeWriter.Write(Marks.LEFT_BRACKET);

            if (lamda.ConstructorParameters != null)
            {
                var enumerator = lamda.ConstructorParameters.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    GenerateDataItem(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                    }
                }
            }

            codeWriter.Write(Marks.RIGHT_BRACKET);

            if (lamda.MethodList != null && lamda.MethodList.Count > 0)
            {
                codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
                options.PushIndent();

                foreach (var codeMethod in lamda.MethodList)
                {
                    codeWriter.WriteLine();
                    codeMethod.AddAttribute("Override");
                    GenerateMethod(codeMethod, codeWriter, options);
                }

                options.PopIndent();
                codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);
            }
        }
    }
}
