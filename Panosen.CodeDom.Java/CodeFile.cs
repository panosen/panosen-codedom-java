using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// csharp code file
    /// </summary>
    public class CodeFile
    {
        /// <summary>
        /// 包
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// 系统引用
        /// </summary>
        public List<string> SystemImportList { get; set; }

        /// <summary>
        /// 从nuget包里面的引用
        /// </summary>
        public List<string> MavenImportList { get; set; }

        /// <summary>
        /// 当前项目的引用
        /// </summary>
        public List<string> ProjectImportList { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        public List<CodeClass> ClassList { get; set; }

        /// <summary>
        /// 接口
        /// </summary>
        public List<CodeInterface> InterfaceList { get; set; }

        /// <summary>
        /// 枚举
        /// </summary>
        public List<CodeEnum> EnumList { get; set; }

        /// <summary>
        /// 格言
        /// </summary>
        public List<string> Mottos { get; set; }
    }


    /// <summary>
    /// CodeFile 扩展
    /// </summary>
    public static class CodeFileExtension
    {

        /// <summary>
        /// 添加一个nuget引用
        /// </summary>
        public static CodeFile AddMotto(this CodeFile codeFile, string motto)
        {
            if (codeFile.Mottos == null)
            {
                codeFile.Mottos = new List<string>();
            }

            codeFile.Mottos.Add(motto);

            return codeFile;
        }

        /// <summary>
        /// 添加一个nuget引用
        /// </summary>
        public static void AddSystemImport(this CodeFile codeFile, string systemImport)
        {
            if (codeFile.SystemImportList == null)
            {
                codeFile.SystemImportList = new List<string>();
            }

            codeFile.SystemImportList.Add(systemImport);
        }

        /// <summary>
        /// 添加一个nuget引用
        /// </summary>
        public static void AddMavenImport(this CodeFile codeFile, string mavenImport)
        {
            if (codeFile.MavenImportList == null)
            {
                codeFile.MavenImportList = new List<string>();
            }

            codeFile.MavenImportList.Add(mavenImport);
        }

        /// <summary>
        /// 添加一个nuget引用
        /// </summary>
        public static void AddProjectImport(this CodeFile codeFile, string projectImport)
        {
            if (codeFile.ProjectImportList == null)
            {
                codeFile.ProjectImportList = new List<string>();
            }

            codeFile.ProjectImportList.Add(projectImport);
        }

        /// <summary>
        /// 添加一个类
        /// </summary>
        public static CodeFile AddClass(this CodeFile codeFile, CodeClass codeClass)
        {
            if (codeFile.ClassList == null)
            {
                codeFile.ClassList = new List<CodeClass>();
            }

            codeFile.ClassList.Add(codeClass);

            return codeFile;
        }

        /// <summary>
        /// 添加一个类
        /// </summary>
        public static CodeClass AddClass(this CodeFile codeFile, string name = null)
        {
            if (codeFile.ClassList == null)
            {
                codeFile.ClassList = new List<CodeClass>();
            }

            CodeClass codeClass = new CodeClass();
            codeClass.Name = name;

            codeFile.ClassList.Add(codeClass);

            return codeClass;
        }
    }
}
