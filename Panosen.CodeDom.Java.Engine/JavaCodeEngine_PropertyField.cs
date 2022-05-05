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
        /// 生成属性对应的字段
        /// </summary>
        /// <param name="codeProperty"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GeneratePropertyField(CodeProperty codeProperty, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeProperty == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeProperty.Summary, codeWriter, options);

            if (codeProperty.AttributeList != null && codeProperty.AttributeList.Count > 0)
            {
                foreach (var attribute in codeProperty.AttributeList)
                {
                    codeWriter.Write(options.IndentString);
                    GenerateAttribute(attribute, codeWriter, options);
                    codeWriter.WriteLine();
                }
            }

            codeWriter.Write(options.IndentString);

            if (codeProperty.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeProperty.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }
            else
            {
                codeWriter.Write(AccessModifiers.Private.Value()).Write(Marks.WHITESPACE);
            }

            if (codeProperty.IsStatic)
            {
                codeWriter.Write(Keywords.STATIC).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeProperty.Type ?? string.Empty).Write(Marks.WHITESPACE)
                .Write((codeProperty.Name ?? string.Empty).ToLowerCamelCase());

            if (codeProperty.ValueList != null)
            {
                options.PushIndent();

                codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);

                var enumerator = codeProperty.ValueList.GetEnumerator();
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
