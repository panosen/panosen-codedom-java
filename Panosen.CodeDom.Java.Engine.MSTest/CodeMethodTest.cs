using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class CodeMethodTest
    {
        [TestMethod]
        public void Test()
        {
            var option = GetData();

            StringBuilder builder = new StringBuilder();

            new JavaCodeEngine().Generate(option, builder);

            var actual = builder.ToString();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        private object PrepareExpected()
        {
            return @"public TestMethod(string name, int age) {
    name = age.ToString();
    name = age.ToString();
    try {
        int a = 0;
    } catch{
        //something 1
        11111
    } catch (Exception) {
        222
    } catch (Exception e) {
    } finally {
        333
    }
    if (1) {
        ok
    } else if (b) {
        333
    } else {
        okok
    }
    String sql = ""INSERT INTO `esmanage`.`field`""
            + ""(`cluster_id`,""
            + ""`document_id`,""
            + ""`id`,""
            + ""`name`,""
            + ""`field_type`,""
            + ""`remark`,""
            + ""`data_status`,""
            + ""`create_time`,""
            + ""`last_update_time`)""
            + ""VALUES""
            + ""(<{ cluster_id: }>,""
            + ""<{ document_id: }>,""
            + ""<{ id: }>,""
            + ""<{ name: }>,""
            + ""<{ field_type: }>,""
            + ""<{ remark: }>,""
            + ""<{ data_status: 0}>,""
            + ""<{ create_time: }>,""
            + ""<{ last_update_time: }>);"";
}
";
        }
        public Code GetData()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.AccessModifiers = AccessModifiers.Public;
            codeMethod.Name = "TestMethod";

            codeMethod.Parameters = new List<CodeParameter>();
            codeMethod.Parameters.Add(new CodeParameter { Name = "name", Type = "string" });
            codeMethod.Parameters.Add(new CodeParameter { Name = "age", Type = "int" });

            //codeMethod.StepBuilders = new List<StepBuilder>();

            codeMethod.StepStatement("name = age.ToString();");
            codeMethod.StepStatement("name = age.ToString();");

            var tryStepBuilder = codeMethod.StepTry();
            tryStepBuilder.StepStatement("int a = 0;");
            tryStepBuilder.WithCatch().StepStatement("//something 1").StepStatement("11111");
            tryStepBuilder.WithCatch(exceptionType: "Exception").StepStatement("222");
            tryStepBuilder.WithCatch(exceptionType: "Exception", exceptionName: "e");
            tryStepBuilder.WithFinally().StepStatement("333");

            var ifStepBuilder = codeMethod.StepIf("1").StepStatement("ok");
            ifStepBuilder.WithElseIf("b").StepStatement("333");
            ifStepBuilder.WithElse().StepStatement("okok");

            codeMethod.StepAssignStringVariable("sql", @"
INSERT INTO `esmanage`.`field`
(`cluster_id`,
`document_id`,
`id`,
`name`,
`field_type`,
`remark`,
`data_status`,
`create_time`,
`last_update_time`)
VALUES
(<{ cluster_id: }>,
<{ document_id: }>,
<{ id: }>,
<{ name: }>,
<{ field_type: }>,
<{ remark: }>,
<{ data_status: 0}>,
<{ create_time: }>,
<{ last_update_time: }>);");

            return codeMethod;

        }
    }
}
