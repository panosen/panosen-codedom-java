using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    /// <summary>
    /// 生成对象 命名空间 类 枚举 属性  方法
    /// </summary>
    partial class JavaCodeEngine
    {
        private void StepBlocks(CodeWriter codeWriter, GenerateOptions options, List<StepBuilder> stepBuilders, string endWith = null, bool withNewLine = true)
        {
            codeWriter.WriteLine(Marks.LEFT_BRACE);

            if (stepBuilders != null && stepBuilders.Count > 0)
            {
                options.PushIndent();

                foreach (var item in stepBuilders)
                {
                    GenerateStepBuilder(item, codeWriter, options);
                }

                options.PopIndent();
            }

            codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);

            if (!string.IsNullOrEmpty(endWith))
            {
                codeWriter.Write(endWith);
            }

            if (withNewLine)
            {
                codeWriter.WriteLine();
            }
        }

        private void StepIndentBlocks(CodeWriter codeWriter, GenerateOptions options, List<StepBuilder> stepBuilders)
        {
            if (stepBuilders != null && stepBuilders.Count > 0)
            {
                options.PushIndent();

                foreach (var item in stepBuilders)
                {
                    GenerateStepBuilder(item, codeWriter, options);
                }

                options.PopIndent();
            }
        }
    }
}
