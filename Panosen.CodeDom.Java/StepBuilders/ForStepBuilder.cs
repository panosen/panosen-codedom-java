using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// ForeachStepBuilder
    /// </summary>
    public class ForStepBuilder : StepBuilderCollection
    {
        /// <summary>
        /// Start
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Middle
        /// </summary>
        public string Middle { get; set; }

        /// <summary>
        /// End
        /// </summary>
        public string End { get; set; }
    }

    /// <summary>
    /// ForStepBuilderExtension
    /// </summary>
    public static class ForStepBuilderExtension
    {
        /// <summary>
        /// For
        /// </summary>
        public static TForStepBuilder For<TForStepBuilder>(this TForStepBuilder forStepBuilder, string start, string middle, string end)
            where TForStepBuilder : ForStepBuilder
        {
            forStepBuilder.Start = start;
            forStepBuilder.Middle = middle;
            forStepBuilder.End = end;

            return forStepBuilder;
        }
    }
}
