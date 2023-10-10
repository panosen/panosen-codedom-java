using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 实现此接口的
    /// </summary>
    public interface IStepCollection
    {
        /// <summary>
        /// Steps
        /// </summary>
        List<StepOrCollection> Steps { get; set; }
    }

    /// <summary>
    /// 一批语句
    /// </summary>
    public class StepCollection : StepOrCollection, IStepCollection
    {
        #region IStepCollection Members

        /// <summary>
        /// IStepCollection.Steps
        /// </summary>
        public List<StepOrCollection> Steps { get; set; }

        #endregion
    }

    /// <summary>
    /// StepCollection 扩展
    /// </summary>
    public static class IStepCollectionExtension
    {
        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepCollection Step<TStepCollection>(this TStepCollection stepBuilderCollection, Step stepBuilder)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            stepBuilderCollection.Steps.Add(stepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个空行
        /// </summary>
        public static TStepCollection StepEmpty<TStepCollection>(this TStepCollection stepBuilderCollection)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            stepBuilderCollection.Steps.Add(new EmptyStep());

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepCollection StepStatement<TStepCollection>(this TStepCollection stepBuilderCollection, string statement)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            StatementStep statementStep = new StatementStep();
            statementStep.Statement = statement;
            stepBuilderCollection.Steps.Add(statementStep);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个 if 块
        /// </summary>
        public static IfStep StepIf<TStepCollection>(this TStepCollection stepBuilderCollection, string condition = null)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            IfStep ifStep = new IfStep();
            ifStep.Condition = condition;

            stepBuilderCollection.Steps.Add(ifStep);

            return ifStep;
        }

        ///////// <summary>
        ///////// 添加一个 if 块
        ///////// </summary>
        //////public static WhileStep StepWhile<TStepCollection>(this TStepCollection stepBuilderCollection, string condition = null)
        //////    where TStepCollection : IStepCollection
        //////{
        //////    if (stepBuilderCollection.Steps == null)
        //////    {
        //////        stepBuilderCollection.Steps = new List<StepOrCollection>();
        //////    }

        //////    WhileStep whileStep = new WhileStep();
        //////    whileStep.Condition = condition;

        //////    stepBuilderCollection.Steps.Add(whileStep);

        //////    return whileStep;
        //////}

        ///////// <summary>
        ///////// switch语句块
        ///////// </summary>
        //////public static SwitchStep StepSwitch<TStepCollection>(this TStepCollection stepBuilderCollection, string expression = null)
        //////    where TStepCollection : IStepCollection
        //////{
        //////    if (stepBuilderCollection.Steps == null)
        //////    {
        //////        stepBuilderCollection.Steps = new List<StepOrCollection>();
        //////    }

        //////    SwitchStep switchStep = new SwitchStep();
        //////    switchStep.Expression = expression;

        //////    stepBuilderCollection.Steps.Add(switchStep);

        //////    return switchStep;
        //////}

        /// <summary>
        /// 添加一个 try 块
        /// </summary>
        public static TryStep StepTry<TStepCollection>(this TStepCollection stepBuilderCollection, string condition = null)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            TryStep tryStep = new TryStep();
            tryStep.Condition = condition;

            stepBuilderCollection.Steps.Add(tryStep);

            return tryStep;
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStep StepForeach<TStepCollection>(this TStepCollection stepBuilderCollection, string item, string items)
            where TStepCollection : IStepCollection
        {
            return StepForeach(stepBuilderCollection, null, item, items);
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStep StepForeach<TStepCollection>(this TStepCollection stepBuilderCollection, string type, string item, string items)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            ForeachStep foreachStep = new ForeachStep();
            foreachStep.Type = type;
            foreachStep.Item = item;
            foreachStep.Items = items;

            stepBuilderCollection.Steps.Add(foreachStep);

            return foreachStep;
        }

        /// <summary>
        /// 添加一个 for 块
        /// </summary>
        public static ForStep StepFor<TStepCollection>(this TStepCollection stepBuilderCollection, string start, string middle, string end)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            ForStep forStep = new ForStep();
            forStep.Start = start;
            forStep.Middle = middle;
            forStep.End = end;

            stepBuilderCollection.Steps.Add(forStep);

            return forStep;
        }

        ///////// <summary>
        ///////// 添加一个代码块
        ///////// </summary>
        //////public static BlockStep StepBlock<TStepCollection>(this TStepCollection stepBuilderCollection)
        //////    where TStepCollection : IStepCollection
        //////{
        //////    if (stepBuilderCollection.Steps == null)
        //////    {
        //////        stepBuilderCollection.Steps = new List<StepOrCollection>();
        //////    }

        //////    BlockStep blockStep = new BlockStep();

        //////    stepBuilderCollection.Steps.Add(blockStep);

        //////    return blockStep;
        //////}

        /// <summary>
        /// 添加一个缩进块
        /// </summary>
        public static PushIndentStep StepPushIndent<TStepCollection>(this TStepCollection stepBuilderCollection, string key)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            PushIndentStep pushIndentStep = new PushIndentStep();
            pushIndentStep.Key = key;

            stepBuilderCollection.Steps.Add(pushIndentStep);

            return pushIndentStep;
        }

        /// <summary>
        /// 调用方法
        /// </summary>
        public static StatementChainStep StepStatementChain<TStepCollection>(this TStepCollection stepBuilderCollection, string target = null)
            where TStepCollection : IStepCollection
        {
            if (stepBuilderCollection.Steps == null)
            {
                stepBuilderCollection.Steps = new List<StepOrCollection>();
            }

            StatementChainStep statementChainStep = new StatementChainStep();
            statementChainStep.Target = target;

            stepBuilderCollection.Steps.Add(statementChainStep);

            return statementChainStep;
        }

        /// <summary>
        /// StepAssignStringVariable
        /// </summary>
        public static AssignStringVariableStep StepAssignStringVariable<TStepCollection>(this TStepCollection method, string name, string value)
            where TStepCollection : IStepCollection
        {
            if (method.Steps == null)
            {
                method.Steps = new List<StepOrCollection>();
            }

            AssignStringVariableStep assignStringVariableStep = new AssignStringVariableStep();
            assignStringVariableStep.Name = name;
            assignStringVariableStep.Value = value;

            method.Steps.Add(assignStringVariableStep);

            return assignStringVariableStep;
        }

        ///////// <summary>
        ///////// 调用方法
        ///////// </summary>
        //////public static StatementChainStep StepStatementChain<TStepCollection>(this TStepCollection stepBuilderCollection, string target = null)
        //////    where TStepCollection : IStepCollection
        //////{
        //////    if (stepBuilderCollection.Steps == null)
        //////    {
        //////        stepBuilderCollection.Steps = new List<StepOrCollection>();
        //////    }

        //////    StatementChainStep statementChainStep = new StatementChainStep();
        //////    statementChainStep.Target = target;

        //////    stepBuilderCollection.Steps.Add(statementChainStep);

        //////    return statementChainStep;
        //////}

        ///////// <summary>
        ///////// 为变量赋值
        ///////// </summary>
        //////public static AssignmentStep StepAssignment<TStepCollection>(this TStepCollection stepBuilderCollection)
        //////    where TStepCollection : IStepCollection
        //////{
        //////    if (stepBuilderCollection.Steps == null)
        //////    {
        //////        stepBuilderCollection.Steps = new List<StepOrCollection>();
        //////    }

        //////    AssignmentStep assignVariableStep = new AssignmentStep();

        //////    stepBuilderCollection.Steps.Add(assignVariableStep);

        //////    return assignVariableStep;
        //////}
    }







    ///////////////// <summary>
    ///////////////// StepExtension
    ///////////////// </summary>
    //////////////public static class StepExtension
    //////////////{
    //////////////    /// <summary>
    //////////////    /// Step
    //////////////    /// </summary>
    //////////////    public static TStep Step<TStep>(this TStep method, Step stepBuilder) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        method.Steps.Add(stepBuilder);

    //////////////        return method;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// Steps
    //////////////    /// </summary>
    //////////////    public static TStep Steps<TStep>(this TStep method, List<Step> stepBuilders) where TStep : Step
    //////////////    {
    //////////////        if (stepBuilders == null || stepBuilders.Count == 0)
    //////////////        {
    //////////////            return method;
    //////////////        }

    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        method.Steps.AddRange(stepBuilders);

    //////////////        return method;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepEmpty
    //////////////    /// </summary>
    //////////////    public static TStep StepEmpty<TStep>(this TStep method) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        method.Steps.Add(new EmptyStep());

    //////////////        return method;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepStatement
    //////////////    /// </summary>
    //////////////    public static TStep StepStatement<TStep>(this TStep method, string statement) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        method.Steps.Add(new StatementStep(statement));

    //////////////        return method;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepIf
    //////////////    /// </summary>
    //////////////    /// <typeparam name="TStep"></typeparam>
    //////////////    /// <param name="method"></param>
    //////////////    /// <param name="condition"></param>
    //////////////    /// <returns></returns>
    //////////////    public static IfStep StepIf<TStep>(this TStep method, string condition = null) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        IfStep ifStep = new IfStep();
    //////////////        ifStep.Condition = condition;

    //////////////        method.Steps.Add(ifStep);

    //////////////        return ifStep;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepTry
    //////////////    /// </summary>
    //////////////    public static TryStep StepTry<TStep>(this TStep method) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        TryStep ifStep = new TryStep();

    //////////////        method.Steps.Add(ifStep);

    //////////////        return ifStep;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepForeach
    //////////////    /// </summary>
    //////////////    public static ForeachStep StepForeach<TStep>(this TStep method, string type, string item, string items) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        ForeachStep foreachStep = new ForeachStep();
    //////////////        foreachStep.Type = type;
    //////////////        foreachStep.Item = item;
    //////////////        foreachStep.Items = items;

    //////////////        method.Steps.Add(foreachStep);

    //////////////        return foreachStep;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepFor
    //////////////    /// </summary>
    //////////////    public static ForStep StepFor<TStep>(this TStep method, string start, string middle, string end) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        ForStep forStep = new ForStep();
    //////////////        forStep.Start = start;
    //////////////        forStep.Middle = middle;
    //////////////        forStep.End = end;

    //////////////        method.Steps.Add(forStep);

    //////////////        return forStep;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepBracket
    //////////////    /// </summary>
    //////////////    public static BracketStep StepBracket<TStep>(this TStep method, string key = null, string endWith = null) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        BracketStep bracketStep = new BracketStep();
    //////////////        bracketStep.Key = key;
    //////////////        bracketStep.EndWith = endWith;

    //////////////        method.Steps.Add(bracketStep);

    //////////////        return bracketStep;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepPushIndent
    //////////////    /// </summary>
    //////////////    public static PushIndentStep StepPushIndent<TStep>(this TStep method, string key) where TStep : Step
    //////////////    {
    //////////////        if (method.Steps == null)
    //////////////        {
    //////////////            method.Steps = new List<Step>();
    //////////////        }

    //////////////        PushIndentStep pushIndentStep = new PushIndentStep();
    //////////////        pushIndentStep.Key = key;

    //////////////        method.Steps.Add(pushIndentStep);

    //////////////        return pushIndentStep;
    //////////////    }

}
