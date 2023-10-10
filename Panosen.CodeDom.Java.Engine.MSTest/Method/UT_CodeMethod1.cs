using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Java.Engine.MSTest
{
    [TestClass]
    public class UT_CodeMethod1 : UTCodeMethodBase
    {

        protected override string PrepareExpected()
        {
            return @"public void TestMethod(string name, int age) {
    name = age.ToString();
    name = age.ToString();
    try {
        int a = 0;
    } catch {
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

        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            codeMethod.Parameters = new List<CodeParameter>();
            codeMethod.Parameters.Add(new CodeParameter { Name = "name", Type = "string" });
            codeMethod.Parameters.Add(new CodeParameter { Name = "age", Type = "int" });

            //codeMethod.Steps = new List<Step>();

            codeMethod.StepStatement("name = age.ToString();");
            codeMethod.StepStatement("name = age.ToString();");

            var tryStep = codeMethod.StepTry();
            tryStep.StepStatement("int a = 0;");
            tryStep.WithCatch().StepStatement("//something 1").StepStatement("11111");
            tryStep.WithCatch(exceptionType: "Exception").StepStatement("222");
            tryStep.WithCatch(exceptionType: "Exception", exceptionName: "e");
            tryStep.WithFinally().StepStatement("333");

            var ifStep = codeMethod.StepIf("1").StepStatement("ok");
            ifStep.WithElseIf("b").StepStatement("333");
            ifStep.WithElse().StepStatement("okok");

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

        }
    }
}
