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
        /// GenerateAttribute
        /// </summary>
        public void GenerateAttribute(CodeAttribute codeAttribute, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeAttribute == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            var hasListParam = codeAttribute.ParamList != null && codeAttribute.ParamList.Count > 0;
            var hasMapParam = codeAttribute.ParamMap != null && codeAttribute.ParamMap.Count > 0;

            codeWriter.Write(Marks.LEFT_SQUARE_BRACKET).Write(codeAttribute.Name ?? string.Empty);

            if (hasListParam || hasMapParam)
            {
                codeWriter.Write(Marks.LEFT_BRACKET);
            }

            if (hasListParam)
            {
                var enumerator = codeAttribute.ParamList.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    GenerateDataValue(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext || hasMapParam)
                    {
                        codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                    }
                }
            }

            if (hasMapParam)
            {
                var enumerator = codeAttribute.ParamMap.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    codeWriter.Write(enumerator.Current.Key);
                    codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);
                    GenerateDataValue(enumerator.Current.Value, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext || hasMapParam)
                    {
                        codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                    }
                }
            }

            if (hasListParam || hasMapParam)
            {
                codeWriter.Write(Marks.RIGHT_BRACKET);
            }

            codeWriter.Write(Marks.RIGHT_SQUARE_BRACKET);
        }
    }
}
