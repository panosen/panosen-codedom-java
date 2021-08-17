using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    /// <summary>
    /// 生成表达式
    /// </summary>
    partial class JavaCodeEngine
    {
        /// <summary>
        /// GenerateExpresion
        /// </summary>
        public void GenerateExpresion(CodeExpression codeExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeExpression is CodeThisReferenceExpression)
            {
                GenerateCodeThisReferenceExpression(codeExpression as CodeThisReferenceExpression, codeWriter, options);
                return;
            }

            if (codeExpression is CodeFieldReferenceExpression)
            {
                GenerateCodeFieldReferenceExpression(codeExpression as CodeFieldReferenceExpression, codeWriter, options);
                return;
            }

            if (codeExpression is CodeBinaryOperatorExpression)
            {
                GenerateBinaryOperatorExpresion(codeExpression as CodeBinaryOperatorExpression, codeWriter, options);
                return;
            }
        }

        /// <summary>
        /// GenerateBinaryOperatorExpresion
        /// </summary>
        public void GenerateBinaryOperatorExpresion(CodeBinaryOperatorExpression codeExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(codeExpression.Left ?? string.Empty).Write(Marks.WHITESPACE).Write(codeExpression.Operator?.Value ?? string.Empty).Write(Marks.WHITESPACE).Write(codeExpression.Right ?? string.Empty);
        }

        /// <summary>
        /// GenerateCodeFieldReferenceExpression
        /// </summary>
        public void GenerateCodeFieldReferenceExpression(CodeFieldReferenceExpression codeExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeExpression.TargetObject == null) { return; }
            if (codeExpression.FieldName == null) { return; }

            GenerateExpresion(codeExpression.TargetObject, codeWriter, options);
            codeWriter.Write(".");
            codeWriter.Write(codeExpression.FieldName);
        }

        /// <summary>
        /// GenerateCodeThisReferenceExpression
        /// </summary>
        public void GenerateCodeThisReferenceExpression(CodeThisReferenceExpression codeExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write("this");
        }
    }
}
