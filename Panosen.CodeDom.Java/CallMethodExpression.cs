using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 示例：${MethodName}(${paramA}, ${paramB})
    /// </summary>
    public class CallMethodExpression : CodeExpression
    {
        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public List<DataItem> Parameters { get; set; }

        /// <summary>
        /// 换行
        /// </summary>
        public bool StartFromNewLine { get; set; }
    }

    /// <summary>
    /// CallMethodExpression 扩展
    /// </summary>
    public static class CallMethodExpressionExtension
    {
        /// <summary>
        /// 添加参数
        /// </summary>
        public static TCallMethodExpression SetMethodName<TCallMethodExpression>(this TCallMethodExpression callMethodExpression, string methodName)
            where TCallMethodExpression : CallMethodExpression
        {
            callMethodExpression.MethodName = methodName;

            return callMethodExpression;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        public static TCallMethodExpression SetStartFromNewLine<TCallMethodExpression>(this TCallMethodExpression callMethodExpression, bool startFromNewLine)
            where TCallMethodExpression : CallMethodExpression
        {
            callMethodExpression.StartFromNewLine = startFromNewLine;

            return callMethodExpression;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        public static TCallMethodExpression AddParameter<TCallMethodExpression>(this TCallMethodExpression callMethodExpression, DataValue parameter)
            where TCallMethodExpression : CallMethodExpression
        {
            if (callMethodExpression.Parameters == null)
            {
                callMethodExpression.Parameters = new List<DataItem>();
            }

            callMethodExpression.Parameters.Add(parameter);

            return callMethodExpression;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        public static TCallMethodExpression AddParameter<TCallMethodExpression>(this TCallMethodExpression callMethodExpression, DataItem parameter)
            where TCallMethodExpression : CallMethodExpression
        {
            if (callMethodExpression.Parameters == null)
            {
                callMethodExpression.Parameters = new List<DataItem>();
            }

            callMethodExpression.Parameters.Add(parameter);

            return callMethodExpression;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        private static TDataItem AddParameter<TDataItem>(this CallMethodExpression callMethodExpression) where TDataItem : DataItem, new()
        {
            if (callMethodExpression.Parameters == null)
            {
                callMethodExpression.Parameters = new List<DataItem>();
            }

            TDataItem parameter = new TDataItem();

            callMethodExpression.Parameters.Add(parameter);

            return parameter;
        }

        /// <summary>
        /// 添加 DataValue 类型的参数
        /// </summary>
        public static DataValue AddParameterOfDataValue<TCallMethodExpression>(this TCallMethodExpression callMethodExpression)
            where TCallMethodExpression : CallMethodExpression
        {
            return AddParameter<DataValue>(callMethodExpression);
        }

        /// <summary>
        /// 添加 CodeNewInstance 类型的参数
        /// </summary>
        public static CodeNewInstance AddParameterOfNewInstance<TCallMethodExpression>(this TCallMethodExpression callMethodExpression)
            where TCallMethodExpression : CallMethodExpression
        {
            return AddParameter<CodeNewInstance>(callMethodExpression);
        }

        /// <summary>
        /// 添加 CodeLamdaNewInstance 类型的参数
        /// </summary>
        public static CodeLamdaNewInstance AddParameterOfLamdaNewInstance<TCallMethodExpression>(this TCallMethodExpression callMethodExpression)
            where TCallMethodExpression : CallMethodExpression
        {
            return AddParameter<CodeLamdaNewInstance>(callMethodExpression);
        }

        /// <summary>
        /// 添加 CodeLamdaExpression 类型的参数
        /// </summary>
        public static CodeLamdaExpression AddParameterOfLamdaExpression<TCallMethodExpression>(this TCallMethodExpression callMethodExpression)
            where TCallMethodExpression : CallMethodExpression
        {
            return AddParameter<CodeLamdaExpression>(callMethodExpression);
        }
    }
}
