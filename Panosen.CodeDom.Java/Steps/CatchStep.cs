using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// catch
    /// </summary>
    public class CatchStep : StepCollection
    {
        /// <summary>
        /// Exception
        /// </summary>
        public string ExceptionType { get; set; }

        /// <summary>
        /// e
        /// </summary>
        public string ExceptionName { get; set; }
    }
}
