using Panosen.Language.Java;
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
        /// 生成类
        /// </summary>
        public void GenerateEnum(CodeEnum codeEnum, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeEnum == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeEnum.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            if (codeEnum.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeEnum.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.ENUM).Write(Marks.WHITESPACE).Write(codeEnum.Name ?? string.Empty).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            bool withEmptyConstructor = codeEnum.ValueList != null && codeEnum.ValueList.Count > 0
                && codeEnum.ValueList.Any(v => v.Value != null)
                && codeEnum.ValueList.Any(v => v.Value == null);

            bool withValueConstructor = codeEnum.ValueList != null && codeEnum.ValueList.Count > 0
                && codeEnum.ValueList.Any(v => v.Value != null);

            if (codeEnum.ValueList != null && codeEnum.ValueList.Count > 0)
            {
                var forceConstructor = codeEnum.ValueList.Any(v => v.Value != null);
                var enumerator = codeEnum.ValueList.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    codeWriter.WriteLine();
                    GenerateEnumValue(enumerator.Current, codeWriter, forceConstructor, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.COMMA);
                        codeWriter.WriteLine();
                    }
                }

                if (withEmptyConstructor || withValueConstructor)
                {
                    codeWriter.Write(Marks.SEMICOLON);
                }
                codeWriter.WriteLine();
            }

            if (withValueConstructor)
            {
                codeWriter.WriteLine();
                codeWriter.Write(options.IndentString);
                codeWriter.WriteLine("private final int value;");
            }

            if (withEmptyConstructor)
            {
                codeWriter.WriteLine();
                codeWriter.Write(options.IndentString).Write(codeEnum.Name).Write(Marks.LEFT_BRACKET).Write(Marks.RIGHT_BRACKET)
                    .Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACE).WriteLine();
                options.PushIndent();
                codeWriter.Write(options.IndentString).WriteLine("this.value = 0;");
                options.PopIndent();
                codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
            }

            if (withValueConstructor)
            {
                {
                    codeWriter.WriteLine();
                    codeWriter.Write(options.IndentString).Write(codeEnum.Name)
                        .Write(Marks.LEFT_BRACKET).Write("int value").Write(Marks.RIGHT_BRACKET)
                        .Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACE).WriteLine();
                    options.PushIndent();
                    codeWriter.Write(options.IndentString).WriteLine("this.value = value;");
                    options.PopIndent();
                    codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
                }

                {
                    codeWriter.WriteLine();
                    //public int getValue() {
                    codeWriter.Write(options.IndentString).Write(Keywords.PUBLIC).Write(Marks.WHITESPACE).Write(JavaTypeConstant.INTEGER).Write(Marks.WHITESPACE)
                        .Write("getValue").Write(Marks.LEFT_BRACKET).Write(Marks.RIGHT_BRACKET)
                        .Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACE).WriteLine();
                    options.PushIndent();
                    codeWriter.Write(options.IndentString).WriteLine("return value;");
                    options.PopIndent();
                    codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
                }
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
