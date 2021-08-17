using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// ForearchStepBuilder
    /// </summary>
    public class ForeachStepBuilder : StepBuilderCollection
    {
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Item
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public string Items { get; set; }
    }

    /// <summary>
    /// ForeachStepBuilderExtension
    /// </summary>
    public static class ForeachStepBuilderExtension
    {
        /// <summary>
        /// Foreach
        /// </summary>
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
