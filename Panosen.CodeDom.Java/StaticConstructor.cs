using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 方法
    /// </summary>
    public class StaticConstructor : IStepCollection
    {

        #region IStepCollection Members

        /// <summary>
        /// IStepCollection.Steps
        /// </summary>
        public List<StepOrCollection> Steps { get; set; }

        #endregion
    }
}
