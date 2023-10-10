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
        /// GenerateAssignStringVariableStep
        /// </summary>
        public void GenerateAssignStringVariableStep(AssignStringVariableStep assignStringVariableStep, CodeWriter codeWriter, GenerateOptions options)
        {
            if (assignStringVariableStep == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            var items = assignStringVariableStep.Value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (items.Count == 1)
            {
                codeWriter.Write(options.IndentString).WriteLine($"String {assignStringVariableStep.Name} = \"{items[0]}\";");
            }
            else
            {
                codeWriter.Write(options.IndentString).WriteLine($"String {assignStringVariableStep.Name} = \"{items[0]}\"");
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
