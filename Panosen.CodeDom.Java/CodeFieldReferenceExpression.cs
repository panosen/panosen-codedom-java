using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// CodeFieldReferenceException
    /// </summary>
    public class CodeFieldReferenceExpression : CodeExpression
    {
        /// <summary>
        /// TargetObject
        /// </summary>
        public CodeExpression TargetObject { get; set; }

        /// <summary>
        /// FieldName
        /// </summary>
        public string FieldName { get; set; }
    }
}
