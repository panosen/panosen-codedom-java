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
        /// 生成字段
        /// </summary>
        /// <param name="codeField"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateField(CodeField codeField, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeField == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeField.Summary, codeWriter, options);

            if (codeField.AttributeList != null && codeField.AttributeList.Count > 0)
            {
                foreach (var attribute in codeField.AttributeList)
                {
                    codeWriter.Write(options.IndentString);
                    GenerateAttribute(attribute, codeWriter, options);
                    codeWriter.WriteLine();
                }
            }

            codeWriter.Write(options.IndentString);

            if (codeField.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeField.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }
            else
            {
                codeWriter.Write(AccessModifiers.Private.Value()).Write(Marks.WHITESPACE);
            }

            if (codeField.IsFinal)
            {
                codeWriter.Write(Keywords.FINAL).Write(Marks.WHITESPACE);
            }

            if (codeField.IsStatic)
            {
                codeWriter.Write(Keywords.STATIC).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeField.Type ?? string.Empty).Write(Marks.WHITESPACE);

            codeWriter.Write(codeField.Name ?? string.Empty);

            if (codeField.ValueList != null)
            {
                options.PushIndent();

                codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);

                var enumerator = codeField.ValueList.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    GenerateDataItem(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.PLUS);
                        codeWriter.Write(options.IndentString);
                    }

                }

                options.PopIndent();
            }

            codeWriter.WriteLine(Marks.SEMICOLON);
        }
    }
}
