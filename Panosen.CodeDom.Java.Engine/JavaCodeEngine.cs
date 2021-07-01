using System;
using System.IO;

namespace Panosen.CodeDom.Java.Engine
{
    public partial class JavaCodeEngine
    {
        private const string NAMESPACE = "namespace";
        private const string KEYWORD_CLASS = "class";
        private const string KEYWORD_INTERFACE = "interface";
        private const string KEYWORD_IF = "if";
        private const string KEYWORD_TRY = "try";
        private const string KEYWORD_CATCH = "catch";
        private const string KEYWORD_FINALLY = "finally";
        private const string KEYWORD_CONST = "const";
        private const string KEYWORD_ELSE = "else";
        private const string KEYWORD_FOR = "for";
        private const string KEYWORD_ABSTRACT = "abstract";
        private const string KEYWORD_FINAL = "final";
        private const string KEYWORD_PACKAGE = "package";
        private const string KEYWORD_IMPORT = "import";
        private const string KEYWORD_IMPLEMENTS = "implements";
        private const string KEYWORD_EXTENDS = "extends";
        private const string KEYWORD_THROWS = "throws";
        private const string KEYWORD_STATIC = "static";
        private const string KEYWORD_SYNCHRONIZED = "synchronized";

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
