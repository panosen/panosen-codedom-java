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
        /// GenerateAssignStringVariableStepBuilder
        /// </summary>
        public void GenerateAssignStringVariableStepBuilder(AssignStringVariableStepBuilder assignStringVariableStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (assignStringVariableStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            var items = assignStringVariableStepBuilder.Value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (items.Count == 1)
            {
                codeWriter.Write(options.IndentString).WriteLine($"String {assignStringVariableStepBuilder.Name} = \"{items[0]}\";");
            }
            else
            {
                codeWriter.Write(options.IndentString).WriteLine($"String {assignStringVariableStepBuilder.Name} = \"{items[0]}\"");
                for (int i = 1; i < items.Count; i++)
                {
                    var line = $"+ \"{items[i]}\"";
                    if (i == items.Count - 1)
                    {
                        line = line + ";";
                    }
                    codeWriter.Write(options.IndentString).Write(options.TabString).Write(options.TabString).WriteLine(line);
                }
            }
        }
    }
}
