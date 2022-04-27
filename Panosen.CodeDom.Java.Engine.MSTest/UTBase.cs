using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    public abstract class UTBase
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().Generate(option, builder);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected abstract string PrepareExpected();

        protected abstract Code PrepareCode();
    }
}
