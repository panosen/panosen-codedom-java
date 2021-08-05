using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    /// <summary>
    /// CodeFileExtension
    /// </summary>
    public static class CodeFileExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        public static string TransformText(this CodeFile codeFile, GenerateOptions options = null)
        {
            var builder = new StringBuilder();

            new JavaCodeEngine().GenerateCodeFile(codeFile, builder, options);

            return builder.ToString();
        }
    }
}
