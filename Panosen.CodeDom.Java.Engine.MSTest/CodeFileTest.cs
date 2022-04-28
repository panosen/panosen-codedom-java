using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class CodeFileTest
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCodeFile();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().GenerateCodeFile(option, builder);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected string PrepareExpected()
        {
            return @"package abc;

import system.a1;
import system.a2;

import maven.a1;
import maven.a2;

import project.a1;
import project.a2;

public class T {
}
";
        }

        protected CodeFile PrepareCodeFile()
        {
            CodeFile codeFile = new CodeFile();
            codeFile.PackageName = "abc";

            codeFile.AddSystemImport("system.a1");
            codeFile.AddSystemImport("system", "a1");
            codeFile.AddSystemImport("system", "a2");

            codeFile.AddMavenImport("maven.a1");
            codeFile.AddMavenImport("maven", "a1");
            codeFile.AddMavenImport("maven", "a2");

            codeFile.AddProjectImport("project.a1");
            codeFile.AddProjectImport("project", "a1");
            codeFile.AddProjectImport("project", "a2");

            codeFile.AddProjectImport("abc.TT");

            var codeClass = codeFile.AddClass("T");
            codeClass.AccessModifiers = AccessModifiers.Public;
            return codeFile;
        }
    }
}
