using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public class CodeFieldReferenceExpression : CodeExpression
    {
        public CodeExpression TargetObject { get; set; }

        public string FieldName { get; set; }
    }
}
