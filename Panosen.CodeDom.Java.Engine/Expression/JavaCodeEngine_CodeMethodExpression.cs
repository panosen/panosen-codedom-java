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
        /// GenerateCallMethodExpression
        /// </summary>
        public void GenerateCallMethodExpression(CallMethodExpression codeMethodExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeMethodExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(codeMethodExpression.MethodName).Write(Marks.LEFT_BRACKET);

            if (codeMethodExpression.Parameters != null && codeMethodExpression.Parameters.Count > 0)
            {
                var enumerator = codeMethodExpression.Parameters.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    GenerateDataItem(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.COMMA);
                        codeWriter.Write(Marks.WHITESPACE);
                    }
                }
            }

            codeWriter.Write(Marks.RIGHT_BRACKET);
        }
    }
}
