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
        /// 生成属性对应的方法
        /// </summary>
        /// <param name="codeProperty"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GeneratePropertyMethod(CodeProperty codeProperty, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeProperty == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            {
                var codeMethod = BuildMethod_GetProperty(codeProperty);
                if (!string.IsNullOrEmpty(codeProperty.Summary))
                {
                    codeMethod.Summary = "[getter] " + codeProperty.Summary;
                }
                else if (options.UseJavaCoc)
                {
                    codeMethod.Summary = "[getter] " + codeProperty.Name;
                }
                GenerateMethod(codeMethod, codeWriter, options);
            }

            codeWriter.WriteLine();

            {
                var codeMethod = BuildMethod_SetMethod(codeProperty);
                if (!string.IsNullOrEmpty(codeProperty.Summary))
                {
                    codeMethod.Summary = "[setter] " + codeProperty.Summary;
                }
                else if (options.UseJavaCoc)
                {
                    codeMethod.Summary = "[setter] " + codeProperty.Name;
                }
                GenerateMethod(codeMethod, codeWriter, options);
            }
        }

        private CodeMethod BuildMethod_GetProperty(CodeProperty codeProperty)
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.AccessModifiers = AccessModifiers.Public;
            codeMethod.IsStatic = codeProperty.IsStatic;
            codeMethod.ReturnType = codeProperty.Type;
            codeMethod.Name = $"get{codeProperty.Name}";

            codeMethod.StepStatement($"return {codeProperty.Name.ToLowerCamelCase()};");

            return codeMethod;
        }

        private CodeMethod BuildMethod_SetMethod(CodeProperty codeProperty)
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.AccessModifiers = AccessModifiers.Public;
            codeMethod.IsStatic = codeProperty.IsStatic;
            codeMethod.ReturnType = "void";

            codeMethod.Name = $"set{codeProperty.Name}";

            codeMethod.AddParameter(codeProperty.Type, codeProperty.Name.ToLowerCamelCase());

            codeMethod.StepStatement($"this.{codeProperty.Name.ToLowerCamelCase()} = {codeProperty.Name.ToLowerCamelCase()};");

            return codeMethod;
        }
    }
}
