using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public class ForStepBuilder : StepBuilder
    {
        public string Start { get; set; }

        public string Middle { get; set; }

        public string End { get; set; }
    }

    public static class ForStepBuilderExtension
    {
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
