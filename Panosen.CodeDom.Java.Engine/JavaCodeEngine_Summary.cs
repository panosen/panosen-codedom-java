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
        /// 生成摘要
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateSummary(string summary, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (string.IsNullOrEmpty(summary))
            {
                return;
            }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            var lines = summary.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            codeWriter.Write(options.IndentString).WriteLine("/**");
            foreach (var line in lines)
            {
                codeWriter.Write(options.IndentString).Write(" * ").WriteLine(line);
            }
            codeWriter.Write(options.IndentString).WriteLine(" */");
        }
    }
}
