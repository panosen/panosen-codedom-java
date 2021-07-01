using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 为 String 类型的变量赋值
    /// </summary>
    public class AssignStringVariableStepBuilder : StepBuilder
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
