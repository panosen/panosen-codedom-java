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
        /// 生成javadoc
        /// </summary>
        public void GenerateJavaDoc(CodeMethod codeMethod, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            var summary = codeMethod.Summary ?? codeMethod.Name;
            var lines = summary.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            codeWriter.Write(options.IndentString).WriteLine("/**");

            foreach (var line in lines)
            {
                codeWriter.Write(options.IndentString).Write(" * ").WriteLine(line);
            }

            if ((codeMethod.Parameters != null && codeMethod.Parameters.Count > 0) ||
                (codeMethod.ReturnType != null && codeMethod.ReturnType != "void"))
            {
                codeWriter.Write(options.IndentString).WriteLine(" *");
            }

            if (codeMethod.Parameters != null && codeMethod.Parameters.Count > 0)
            {
                foreach (var parameter in codeMethod.Parameters)
                {
                    var parmSummary = parameter.Summary ?? parameter.Name;
                    codeWriter.Write(options.IndentString).Write(" * @param ").Write(parameter.Name).Write(" ").WriteLine(parmSummary);
                }
            }
            if (codeMethod.ReturnType != null && codeMethod.ReturnType != "void")
            {
                codeWriter.Write(options.IndentString).Write(" * @return ").WriteLine(EncodeSummary(codeMethod.ReturnType));
            }

            codeWriter.Write(options.IndentString).WriteLine(" */");
        }

        private string EncodeSummary(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.Replace("<", "&lt;").Replace(">", "&gt;");
        }
    }
}
