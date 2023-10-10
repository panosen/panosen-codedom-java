using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    public abstract class UTCodeMethodBase
    {
        [TestMethod]
        public void Test()
        {
            var codeMethod = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().GenerateMethod(codeMethod, builder);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        private CodeMethod PrepareCode()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.AccessModifiers = AccessModifiers.Public;
            codeMethod.Name = "TestMethod";
            codeMethod.ReturnType = "void";

            PrepareCodeMethod(codeMethod);

            return codeMethod;
        }

        protected abstract string PrepareExpected();

        protected abstract void PrepareCodeMethod(CodeMethod codeMethod);
    }
}
