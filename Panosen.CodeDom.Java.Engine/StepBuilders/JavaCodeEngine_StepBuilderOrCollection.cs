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
        /// 生成方法步骤
        /// </summary>
        /// <param name="stepBuilder"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateStepBuilderOrCollection(StepBuilderOrCollection stepBuilder, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (stepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (stepBuilder is EmptyStepBuilder)
            {
                codeWriter.WriteLine();
            }

            if (stepBuilder is StatementStepBuilder)
            {
                GenerateStatementStepBuilder(stepBuilder as StatementStepBuilder, codeWriter, options);
            }

            if (stepBuilder is IfStepBuilder)
            {
                GenerateIfStepBuilder(stepBuilder as IfStepBuilder, codeWriter, options);
            }

            if (stepBuilder is TryStepBuilder)
            {
                GenerateTryStepBuilder(stepBuilder as TryStepBuilder, codeWriter, options);
            }

            if (stepBuilder is ForeachStepBuilder)
            {
                GenerateForeachStepBuilder(stepBuilder as ForeachStepBuilder, codeWriter, options);
            }

            if (stepBuilder is ForStepBuilder)
            {
                GenerateForStepBuilder(stepBuilder as ForStepBuilder, codeWriter, options);
            }

            if (stepBuilder is PushIndentStepBuilder)
            {
                GeneratePushIndentStepBuilder(stepBuilder as PushIndentStepBuilder, codeWriter, options);
            }

            if (stepBuilder is AssignStringVariableStepBuilder)
            {
                GenerateAssignStringVariableStepBuilder(stepBuilder as AssignStringVariableStepBuilder, codeWriter, options);
            }
        }
    }
}
