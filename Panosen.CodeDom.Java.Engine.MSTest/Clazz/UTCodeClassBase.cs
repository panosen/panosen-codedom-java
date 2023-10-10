using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    public abstract class UTCodeClassBase
    {
        [TestMethod]
        public void Test()
        {
            var code = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().GenerateClass(code, builder);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected abstract string PrepareExpected();

        protected abstract CodeClass PrepareCode();
    }
}
