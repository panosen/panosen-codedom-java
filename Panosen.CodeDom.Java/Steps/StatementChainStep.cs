using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 调用方法
    /// </summary>
    public class StatementChainStep : Step
    {
        /// <summary>
        /// ${Target}.MethodA().MethodB();
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 调用方法表达式
        /// </summary>
        public List<CallMethodExpression> CallMethodExpressions { get; set; }
    }

    /// <summary>
    /// StatementChainStepExtension
    /// </summary>
    public static class StatementChainStepExtension
    {
        /// <summary>
        /// 添加一个方法表达式
        /// </summary>
        public static TCallMethodStep SetTarget<TCallMethodStep>(this TCallMethodStep callMethodStep, string target)
            where TCallMethodStep : StatementChainStep
        {
            callMethodStep.Target = target;

            return callMethodStep;
        }
        /// <summary>
        /// 添加一个方法表达式
        /// </summary>
        public static TCallMethodStep AddCallMethodExpression<TCallMethodStep>(this TCallMethodStep callMethodStep, CallMethodExpression callMethodExpression)
            where TCallMethodStep : StatementChainStep
        {
            if (callMethodStep.CallMethodExpressions == null)
            {
                callMethodStep.CallMethodExpressions = new List<CallMethodExpression>();
            }

            callMethodStep.CallMethodExpressions.Add(callMethodExpression);

            return callMethodStep;
        }

        /// <summary>
        /// 添加一个方法表达式
        /// </summary>
        public static CallMethodExpression AddCallMethodExpression<TCallMethodStep>(this TCallMethodStep callMethodStep, string methodName, bool startFromNewLine = false)
            where TCallMethodStep : StatementChainStep
        {
            if (callMethodStep.CallMethodExpressions == null)
            {
                callMethodStep.CallMethodExpressions = new List<CallMethodExpression>();
            }

            CallMethodExpression callMethodExpression = new CallMethodExpression();
            callMethodExpression.MethodName = methodName;
            callMethodExpression.StartFromNewLine = startFromNewLine;

            callMethodStep.CallMethodExpressions.Add(callMethodExpression);

            return callMethodExpression;
        }

        /// <summary>
        /// 添加一批方法表达式
        /// </summary>
        public static TCallMethodStep AddCallMethodExpressions<TCallMethodStep>(this TCallMethodStep callMethodStep, List<CallMethodExpression> callMethodExpressions)
            where TCallMethodStep : StatementChainStep
        {
            if (callMethodExpressions == null || callMethodExpressions.Count == 0)
            {
                return callMethodStep;
            }
            if (callMethodStep.CallMethodExpressions == null)
            {
                callMethodStep.CallMethodExpressions = new List<CallMethodExpression>();
            }

            callMethodStep.CallMethodExpressions.AddRange(callMethodExpressions);

            return callMethodStep;
        }
    }
}
