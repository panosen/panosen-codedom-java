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
        /// 生成字段
        /// </summary>
        public void GenerateEnumValue(CodeEnumValue codeEnumValue, CodeWriter codeWriter, bool forceConstructor = false, GenerateOptions options = null)
        {
            if (codeEnumValue == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeEnumValue.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            codeWriter.Write(codeEnumValue.Name ?? string.Empty);

            if (codeEnumValue.Value != null || forceConstructor)
            {
                codeWriter.Write(Marks.LEFT_BRACKET);
            }

            if (codeEnumValue.Value != null)
            {
                GenerateDataItem(codeEnumValue.Value, codeWriter, options);
            }

            if (codeEnumValue.Value != null || forceConstructor)
            {
                codeWriter.Write(Marks.RIGHT_BRACKET);
            }
        }
    }
}
