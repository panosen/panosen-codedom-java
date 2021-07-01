using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// try
    /// </summary>
    public class TryStepBuilder : StepBuilder
    {
        /// <summary>
        /// catch
        /// </summary>
        public List<CatchStepBuilder> CatchStepBuilders { get; set; }

        /// <summary>
        /// finally
        /// </summary>
        public FinallyStepBuilder FinallyStepBuilder { get; set; }
    }

    public static class TryStepBuilderExtension
    {
        public static CatchStepBuilder WithCatch(this TryStepBuilder tryStepBuilder, string exceptionType = null, string exceptionName = null)
        {
            if (tryStepBuilder.CatchStepBuilders == null)
            {
                tryStepBuilder.CatchStepBuilders = new List<CatchStepBuilder>();
            }

            CatchStepBuilder catchStepBuilder = new CatchStepBuilder();
            catchStepBuilder.ExceptionType = exceptionType;
            catchStepBuilder.ExceptionName = exceptionName;
            catchStepBuilder.Name = exceptionName;

            tryStepBuilder.CatchStepBuilders.Add(catchStepBuilder);

            return catchStepBuilder;
        }

        public static FinallyStepBuilder WithFinally(this TryStepBuilder tryStepBuilder)
        {
            FinallyStepBuilder finallyStepBuilder = new FinallyStepBuilder();

            tryStepBuilder.FinallyStepBuilder = finallyStepBuilder;

            return finallyStepBuilder;
        }
    }
}
