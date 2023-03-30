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

            codeWriter.Write(Marks.AT).Write(codeAttribute.Name ?? string.Empty);

            if (!hasListParam)
            {
                return;
            }

            // (
            codeWriter.Write(Marks.LEFT_BRACKET);

            //参数
            {
                var enumerator = codeAttribute.ParamList.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    if (enumerator.Current.Key != null)
                    {
                        codeWriter.Write(enumerator.Current.Key);
                        codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);
                    }

                    GenerateDataValue(enumerator.Current.Value, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                    }
                }
            }

            // )
            codeWriter.Write(Marks.RIGHT_BRACKET);
        }
    }
}
