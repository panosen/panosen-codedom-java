using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public class ForeachStepBuilder : StepBuilder
    {
        public string Type { get; set; }

        public string Item { get; set; }

        public string Items { get; set; }
    }


    public static class ForeachStepBuilderExtension
    {
        public static TForeachStepBuilder Foreach<TForeachStepBuilder>(this TForeachStepBuilder foreachStepBuilder, string type, string item, string items)
            where TForeachStepBuilder : ForeachStepBuilder
        {
            foreachStepBuilder.Type = type;
            foreachStepBuilder.Item = item;
            foreachStepBuilder.Items = items;

            return foreachStepBuilder;
        }
    }
}
