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
    public class TryStep : StepCollection
    {
        /// <summary>
        /// try (${condition}) {}
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// catch
        /// </summary>
        public List<CatchStep> CatchSteps { get; set; }

        /// <summary>
        /// finally
        /// </summary>
        public FinallyStep FinallyStep { get; set; }
    }

    /// <summary>
    /// TryStepExtension
    /// </summary>
    public static class TryStepExtension
    {
        /// <summary>
        /// WithCatch
        /// </summary>
        public static CatchStep WithCatch(this TryStep tryStep, string exceptionType = null, string exceptionName = null)
        {
            if (tryStep.CatchSteps == null)
            {
                tryStep.CatchSteps = new List<CatchStep>();
            }

            CatchStep catchStep = new CatchStep();
            catchStep.ExceptionType = exceptionType;
            catchStep.ExceptionName = exceptionName;

            tryStep.CatchSteps.Add(catchStep);

            return catchStep;
        }

        /// <summary>
        /// WithFinally
        /// </summary>
        public static FinallyStep WithFinally(this TryStep tryStep)
        {
            FinallyStep finallyStep = new FinallyStep();

            tryStep.FinallyStep = finallyStep;

            return finallyStep;
        }
    }
}
