using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// ${Parameter} => ${Expression}
    /// </summary>
    public class CodeLamdaStepBuilderCollection : DataItem, IStepBuilderCollection
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string Parameter { get; set; }

        #region IStepBuilderCollection Members

        /// <summary>
        /// 步骤
        /// </summary>
        public List<StepBuilderOrCollection> StepBuilders { get; set; }

        #endregion
    }

    /// <summary>
    /// CodeLamdaStepBuilderCollectionExtension
    /// </summary>
    public static class CodeLamdaStepBuilderCollectionExtension
    {
        /// <summary>
        /// SetParameter
        /// </summary>
        public static TCodeLamdaStepBuilderCollection SetParameter<TCodeLamdaStepBuilderCollection>(this TCodeLamdaStepBuilderCollection lamda, string parameter)
            where TCodeLamdaStepBuilderCollection : CodeLamdaStepBuilderCollection
        {
            lamda.Parameter = parameter;

            return lamda;
        }
    }
}
