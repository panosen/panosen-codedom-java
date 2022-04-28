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
        public Dictionary<string, HashSet<string>> SystemImportList { get; set; }

        /// <summary>
        /// 从nuget包里面的引用
        /// </summary>
        public Dictionary<string, HashSet<string>> MavenImportList { get; set; }

        /// <summary>
        /// 当前项目的引用
        /// </summary>
        public Dictionary<string, HashSet<string>> ProjectImportList { get; set; }

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
        /// 添加一个格言
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



        #region 系统引用

        /// <summary>
        /// 添加一个系统引用
        /// </summary>
        public static void AddSystemImport(this CodeFile codeFile, string fullName)
        {
            if (codeFile.SystemImportList == null)
            {
                codeFile.SystemImportList = new Dictionary<string, HashSet<string>>();
            }

            var packageName = fullName.Substring(0, fullName.LastIndexOf("."));
            var name = fullName.Substring(fullName.LastIndexOf(".") + 1);

            if (!codeFile.SystemImportList.ContainsKey(packageName))
            {
                codeFile.SystemImportList.Add(packageName, new HashSet<string>());
            }

            codeFile.SystemImportList[packageName].Add(name);
        }

        /// <summary>
        /// 添加一个系统引用
        /// </summary>
        public static void AddSystemImport(this CodeFile codeFile, string packageName, string name)
        {
            if (codeFile.SystemImportList == null)
            {
                codeFile.SystemImportList = new Dictionary<string, HashSet<string>>();
            }

            if (!codeFile.SystemImportList.ContainsKey(packageName))
            {
                codeFile.SystemImportList.Add(packageName, new HashSet<string>());
            }

            codeFile.SystemImportList[packageName].Add(name);
        }

        /// <summary>
        /// 添加一批系统引用
        /// </summary>
        public static void AddSystemImports(this CodeFile codeFile, string packageName, List<string> names)
        {
            if (codeFile.SystemImportList == null)
            {
                codeFile.SystemImportList = new Dictionary<string, HashSet<string>>();
            }

            if (!codeFile.SystemImportList.ContainsKey(packageName))
            {
                codeFile.SystemImportList.Add(packageName, new HashSet<string>());
            }

            foreach (var name in names)
            {
                codeFile.SystemImportList[packageName].Add(name);
            }
        }

        /// <summary>
        /// 添加一批系统引用
        /// </summary>
        public static void AddSystemImports(this CodeFile codeFile, List<string> imports)
        {
            if (codeFile.SystemImportList == null)
            {
                codeFile.SystemImportList = new Dictionary<string, HashSet<string>>();
            }

            foreach (var import in imports)
            {
                var packageName = import.Substring(0, import.LastIndexOf("."));
                var name = import.Substring(import.LastIndexOf(".") + 1);

                if (!codeFile.SystemImportList.ContainsKey(packageName))
                {
                    codeFile.SystemImportList.Add(packageName, new HashSet<string>());
                }

                codeFile.SystemImportList[packageName].Add(name);
            }
        }

        /// <summary>
        /// 添加一批系统引用
        /// </summary>
        public static void AddSystemImports(this CodeFile codeFile, Dictionary<string, List<string>> imports)
        {
            if (codeFile.SystemImportList == null)
            {
                codeFile.SystemImportList = new Dictionary<string, HashSet<string>>();
            }

            foreach (var import in imports)
            {
                if (!codeFile.SystemImportList.ContainsKey(import.Key))
                {
                    codeFile.SystemImportList.Add(import.Key, new HashSet<string>());
                }

                foreach (var name in import.Value)
                {
                    codeFile.SystemImportList[import.Key].Add(name);
                }
            }
        }

        #endregion

        #region maven引用

        /// <summary>
        /// 添加一个maven引用
        /// </summary>
        public static void AddMavenImport(this CodeFile codeFile, string fullName)
        {
            if (codeFile.MavenImportList == null)
            {
                codeFile.MavenImportList = new Dictionary<string, HashSet<string>>();
            }

            var packageName = fullName.Substring(0, fullName.LastIndexOf("."));
            var name = fullName.Substring(fullName.LastIndexOf(".") + 1);

            if (!codeFile.MavenImportList.ContainsKey(packageName))
            {
                codeFile.MavenImportList.Add(packageName, new HashSet<string>());
            }

            codeFile.MavenImportList[packageName].Add(name);
        }

        /// <summary>
        /// 添加一个maven引用
        /// </summary>
        public static void AddMavenImport(this CodeFile codeFile, string packageName, string name)
        {
            if (codeFile.MavenImportList == null)
            {
                codeFile.MavenImportList = new Dictionary<string, HashSet<string>>();
            }

            if (!codeFile.MavenImportList.ContainsKey(packageName))
            {
                codeFile.MavenImportList.Add(packageName, new HashSet<string>());
            }

            codeFile.MavenImportList[packageName].Add(name);
        }

        /// <summary>
        /// 添加一批maven引用
        /// </summary>
        public static void AddMavenImports(this CodeFile codeFile, string packageName, List<string> names)
        {
            if (codeFile.MavenImportList == null)
            {
                codeFile.MavenImportList = new Dictionary<string, HashSet<string>>();
            }

            if (!codeFile.MavenImportList.ContainsKey(packageName))
            {
                codeFile.MavenImportList.Add(packageName, new HashSet<string>());
            }

            foreach (var name in names)
            {
                codeFile.MavenImportList[packageName].Add(name);
            }
        }

        /// <summary>
        /// 添加一批maven引用
        /// </summary>
        public static void AddMavenImports(this CodeFile codeFile, List<string> imports)
        {
            if (codeFile.MavenImportList == null)
            {
                codeFile.MavenImportList = new Dictionary<string, HashSet<string>>();
            }

            foreach (var import in imports)
            {
                var packageName = import.Substring(0, import.LastIndexOf("."));
                var name = import.Substring(import.LastIndexOf(".") + 1);

                if (!codeFile.MavenImportList.ContainsKey(packageName))
                {
                    codeFile.MavenImportList.Add(packageName, new HashSet<string>());
                }

                codeFile.MavenImportList[packageName].Add(name);
            }
        }

        /// <summary>
        /// 添加一批maven引用
        /// </summary>
        public static void AddMavenImports(this CodeFile codeFile, Dictionary<string, List<string>> imports)
        {
            if (codeFile.MavenImportList == null)
            {
                codeFile.MavenImportList = new Dictionary<string, HashSet<string>>();
            }

            foreach (var import in imports)
            {
                if (!codeFile.MavenImportList.ContainsKey(import.Key))
                {
                    codeFile.MavenImportList.Add(import.Key, new HashSet<string>());
                }

                foreach (var name in import.Value)
                {
                    codeFile.MavenImportList[import.Key].Add(name);
                }
            }
        }

        #endregion

        #region 项目引用

        /// <summary>
        /// 添加一个项目引用
        /// </summary>
        public static void AddProjectImport(this CodeFile codeFile, string fullName)
        {
            if (codeFile.ProjectImportList == null)
            {
                codeFile.ProjectImportList = new Dictionary<string, HashSet<string>>();
            }

            var packageName = fullName.Substring(0, fullName.LastIndexOf("."));
            var name = fullName.Substring(fullName.LastIndexOf(".") + 1);

            if (!codeFile.ProjectImportList.ContainsKey(packageName))
            {
                codeFile.ProjectImportList.Add(packageName, new HashSet<string>());
            }

            codeFile.ProjectImportList[packageName].Add(name);
        }

        /// <summary>
        /// 添加一个项目引用
        /// </summary>
        public static void AddProjectImport(this CodeFile codeFile, string packageName, string name)
        {
            if (codeFile.ProjectImportList == null)
            {
                codeFile.ProjectImportList = new Dictionary<string, HashSet<string>>();
            }

            if (!codeFile.ProjectImportList.ContainsKey(packageName))
            {
                codeFile.ProjectImportList.Add(packageName, new HashSet<string>());
            }

            codeFile.ProjectImportList[packageName].Add(name);
        }

        /// <summary>
        /// 添加一批项目引用
        /// </summary>
        public static void AddProjectImports(this CodeFile codeFile, string packageName, List<string> names)
        {
            if (codeFile.ProjectImportList == null)
            {
                codeFile.ProjectImportList = new Dictionary<string, HashSet<string>>();
            }

            if (!codeFile.ProjectImportList.ContainsKey(packageName))
            {
                codeFile.ProjectImportList.Add(packageName, new HashSet<string>());
            }

            foreach (var name in names)
            {
                codeFile.ProjectImportList[packageName].Add(name);
            }
        }

        /// <summary>
        /// 添加一批项目引用
        /// </summary>
        public static void AddProjectImports(this CodeFile codeFile, List<string> imports)
        {
            if (codeFile.ProjectImportList == null)
            {
                codeFile.ProjectImportList = new Dictionary<string, HashSet<string>>();
            }

            foreach (var import in imports)
            {
                var packageName = import.Substring(0, import.LastIndexOf("."));
                var name = import.Substring(import.LastIndexOf(".") + 1);

                if (!codeFile.ProjectImportList.ContainsKey(packageName))
                {
                    codeFile.ProjectImportList.Add(packageName, new HashSet<string>());
                }

                codeFile.ProjectImportList[packageName].Add(name);
            }
        }

        /// <summary>
        /// 添加一批项目引用
        /// </summary>
        public static void AddProjectImports(this CodeFile codeFile, Dictionary<string, List<string>> imports)
        {
            if (codeFile.ProjectImportList == null)
            {
                codeFile.ProjectImportList = new Dictionary<string, HashSet<string>>();
            }

            foreach (var import in imports)
            {
                if (!codeFile.ProjectImportList.ContainsKey(import.Key))
                {
                    codeFile.ProjectImportList.Add(import.Key, new HashSet<string>());
                }

                foreach (var name in import.Value)
                {
                    codeFile.ProjectImportList[import.Key].Add(name);
                }
            }
        }

        #endregion



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
        public static CodeClass AddClass(this CodeFile codeFile, string name = null, string summary = null)
        {
            if (codeFile.ClassList == null)
            {
                codeFile.ClassList = new List<CodeClass>();
            }

            CodeClass codeClass = new CodeClass();
            codeClass.Name = name;
            codeClass.Summary = summary;

            codeFile.ClassList.Add(codeClass);

            return codeClass;
        }

        /// <summary>
        /// 添加一个枚举
        /// </summary>
        public static CodeFile AddEnum(this CodeFile codeFile, CodeEnum codeEnum)
        {
            if (codeFile.EnumList == null)
            {
                codeFile.EnumList = new List<CodeEnum>();
            }

            codeFile.EnumList.Add(codeEnum);

            return codeFile;
        }

        /// <summary>
        /// 添加一个枚举
        /// </summary>
        public static CodeEnum AddEnum(this CodeFile codeFile, string name = null, string summary = null)
        {
            if (codeFile.EnumList == null)
            {
                codeFile.EnumList = new List<CodeEnum>();
            }

            CodeEnum codeEnum = new CodeEnum();
            codeEnum.Name = name;
            codeEnum.Summary = summary;

            codeFile.EnumList.Add(codeEnum);

            return codeEnum;
        }
    }
}
