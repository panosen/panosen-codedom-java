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
        public void GenerateConstructor(CodeMethod codeMethod, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeMethod == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (options.UseJavaDoc)
            {
                GenerateJavaDoc(codeMethod, codeWriter, options);
            }
            else
            {
                GenerateSummary(codeMethod.Summary, codeWriter, options);
            }

            if (codeMethod.AttributeList != null && codeMethod.AttributeList.Count > 0)
            {
                foreach (var codeAttribute in codeMethod.AttributeList)
                {
                    codeWriter.Write(options.IndentString);
                    GenerateAttribute(codeAttribute, codeWriter, options);
                    codeWriter.WriteLine();
                }
            }

            codeWriter.Write(options.IndentString);

            if (codeMethod.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeMethod.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            if (codeMethod.IsSynchronized)
            {
                codeWriter.Write(Keywords.SYNCHRONIZED).Write(Marks.WHITESPACE);
            }

            if (codeMethod.IsStatic)
            {
                codeWriter.Write(Keywords.STATIC).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeMethod.Name ?? string.Empty);

            codeWriter.Write(Marks.LEFT_BRACKET);

            if (codeMethod.Parameters != null && codeMethod.Parameters.Count > 0)
            {
                for (int i = 0; i < codeMethod.Parameters.Count; i++)
                {
                    var codeParameter = codeMethod.Parameters[i];
                    GenerateParameter(codeParameter, codeWriter, options);

                    if (i < codeMethod.Parameters.Count - 1)
                    {
                        codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                    }
                }
            }

            codeWriter.Write(Marks.RIGHT_BRACKET);

            if (codeMethod.ExceptionList != null && codeMethod.ExceptionList.Count > 0)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Keywords.THROWS).Write(Marks.WHITESPACE).Write(string.Join(", ", codeMethod.ExceptionList));
            }

            if (codeMethod.StepBuilders == null)
            {
                codeWriter.WriteLine(Marks.SEMICOLON);
                return;
            }

            codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            foreach (var stepBuilder in codeMethod.StepBuilders)
            {
                GenerateStepBuilderOrCollection(stepBuilder, codeWriter, options);
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
