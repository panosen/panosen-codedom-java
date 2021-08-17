using System;
using System.IO;

namespace Panosen.CodeDom.Java.Engine
{
    public partial class JavaCodeEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        public void Generate(Code code, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (code == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (code is CodeClass)
            {
                GenerateClass(code as CodeClass, codeWriter, options);
                return;
            }

            if (code is CodeInterface)
            {
                GenerateInterface(code as CodeInterface, codeWriter, options);
                return;
            }

            if (code is CodeExpression)
            {
                GenerateExpresion(code as CodeExpression, codeWriter, options);
                return;
            }

            if (code is CodeMethod)
            {
                GenerateMethod(code as CodeMethod, codeWriter, options);
                return;
            }
        }
    }
}
