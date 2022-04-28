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
        /// 生成cs文件
        /// </summary>
        /// <param name="codeFile"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateCodeFile(CodeFile codeFile, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeFile == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Keywords.PACKAGE).Write(Marks.WHITESPACE).Write(codeFile.PackageName ?? string.Empty).WriteLine(Marks.SEMICOLON);

            if (codeFile.Mottos != null && codeFile.Mottos.Count > 0)
            {
                codeWriter.WriteLine();
                codeWriter.WriteLine("/*");
                codeWriter.WriteLine(" *------------------------------------------------------------------------------");
                for (int i = 0; i < codeFile.Mottos.Count; i++)
                {
                    codeWriter.WriteLine($" *     {codeFile.Mottos[i]}");
                    if (i < codeFile.Mottos.Count - 1)
                    {
                        codeWriter.WriteLine($" *");
                    }
                }
                codeWriter.WriteLine(" *------------------------------------------------------------------------------");
                codeWriter.WriteLine(" */");
            }

            List<string> usingList = new List<string>();
            AddImportList(usingList, codeFile.SystemImportList, codeFile.PackageName);
            AddImportList(usingList, codeFile.MavenImportList, codeFile.PackageName);
            AddImportList(usingList, codeFile.ProjectImportList, codeFile.PackageName);

            if (usingList.Count > 0)
            {
                foreach (var usingItem in usingList)
                {
                    if (string.IsNullOrEmpty(usingItem))
                    {
                        codeWriter.WriteLine();
                        continue;
                    }

                    codeWriter.Write(Keywords.IMPORT).Write(Marks.WHITESPACE).Write(usingItem).WriteLine(";");
                }
            }

            if (codeFile.ClassList != null && codeFile.ClassList.Count > 0)
            {
                foreach (var codeClass in codeFile.ClassList)
                {
                    codeWriter.WriteLine();
                    GenerateClass(codeClass, codeWriter, options);
                }
            }

            if (codeFile.InterfaceList != null && codeFile.InterfaceList.Count > 0)
            {
                foreach (var codeInterface in codeFile.InterfaceList)
                {
                    codeWriter.WriteLine();
                    GenerateInterface(codeInterface, codeWriter, options);
                }
            }

            if (codeFile.EnumList != null && codeFile.EnumList.Count > 0)
            {
                foreach (var codeEnum in codeFile.EnumList)
                {
                    codeWriter.WriteLine();
                    GenerateEnum(codeEnum, codeWriter, options);
                }
            }
        }

        private static void AddImportList(List<string> targetUsingList, Dictionary<string, HashSet<string>> packageList, string packageName)
        {
            if (packageList == null || packageList.Count == 0)
            {
                return;
            }

            var lines = packageList.OrderBy(v => v.Key).ToList();
            if (lines.Count == 0)
            {
                return;
            }

            targetUsingList.Add(string.Empty);

            foreach (var package in packageList)
            {
                if (package.Key == packageName)
                {
                    continue;
                }
                foreach (var name in package.Value.OrderBy(v => v))
                {
                    targetUsingList.Add(package.Key + "." + name);
                }
            }
        }
    }
}
