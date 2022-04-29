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
    public interface IStepBuilderCollection
    {
        /// <summary>
        /// StepBuilders
        /// </summary>
        List<StepBuilderOrCollection> StepBuilders { get; set; }
    }

    /// <summary>
    /// 一批语句
    /// </summary>
    public class StepBuilderCollection : StepBuilderOrCollection, IStepBuilderCollection
    {
        #region IStepBuilderCollection Members

        /// <summary>
        /// IStepBuilderCollection.StepBuilders
        /// </summary>
        public List<StepBuilderOrCollection> StepBuilders { get; set; }

        #endregion
    }

    /// <summary>
    /// StepBuilderCollection 扩展
    /// </summary>
    public static class IStepBuilderCollectionExtension
    {
        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepBuilderCollection Step<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, StepBuilder stepBuilder)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            stepBuilderCollection.StepBuilders.Add(stepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个空行
        /// </summary>
        public static TStepBuilderCollection StepEmpty<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            stepBuilderCollection.StepBuilders.Add(new EmptyStepBuilder());

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepBuilderCollection StepStatement<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string statement)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            StatementStepBuilder statementStepBuilder = new StatementStepBuilder();
            statementStepBuilder.Statement = statement;
            stepBuilderCollection.StepBuilders.Add(statementStepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个 if 块
        /// </summary>
        public static IfStepBuilder StepIf<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string condition = null)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            IfStepBuilder ifStepBuilder = new IfStepBuilder();
            ifStepBuilder.Condition = condition;

            stepBuilderCollection.StepBuilders.Add(ifStepBuilder);

            return ifStepBuilder;
        }

        ///////// <summary>
        ///////// 添加一个 if 块
        ///////// </summary>
        //////public static WhileStepBuilder StepWhile<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string condition = null)
        //////    where TStepBuilderCollection : IStepBuilderCollection
        //////{
        //////    if (stepBuilderCollection.StepBuilders == null)
        //////    {
        //////        stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
        //////    }

        //////    WhileStepBuilder whileStepBuilder = new WhileStepBuilder();
        //////    whileStepBuilder.Condition = condition;

        //////    stepBuilderCollection.StepBuilders.Add(whileStepBuilder);

        //////    return whileStepBuilder;
        //////}

        ///////// <summary>
        ///////// switch语句块
        ///////// </summary>
        //////public static SwitchStepBuilder StepSwitch<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string expression = null)
        //////    where TStepBuilderCollection : IStepBuilderCollection
        //////{
        //////    if (stepBuilderCollection.StepBuilders == null)
        //////    {
        //////        stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
        //////    }

        //////    SwitchStepBuilder switchStepBuilder = new SwitchStepBuilder();
        //////    switchStepBuilder.Expression = expression;

        //////    stepBuilderCollection.StepBuilders.Add(switchStepBuilder);

        //////    return switchStepBuilder;
        //////}

        /// <summary>
        /// 添加一个 try 块
        /// </summary>
        public static TryStepBuilder StepTry<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            TryStepBuilder tryStepBuilder = new TryStepBuilder();

            stepBuilderCollection.StepBuilders.Add(tryStepBuilder);

            return tryStepBuilder;
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStepBuilder StepForeach<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string item, string items)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            return StepForeach(stepBuilderCollection, null, item, items);
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStepBuilder StepForeach<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string type, string item, string items)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            ForeachStepBuilder foreachStepBuilder = new ForeachStepBuilder();
            foreachStepBuilder.Type = type;
            foreachStepBuilder.Item = item;
            foreachStepBuilder.Items = items;

            stepBuilderCollection.StepBuilders.Add(foreachStepBuilder);

            return foreachStepBuilder;
        }

        /// <summary>
        /// 添加一个 for 块
        /// </summary>
        public static ForStepBuilder StepFor<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string start, string middle, string end)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            ForStepBuilder forStepBuilder = new ForStepBuilder();
            forStepBuilder.Start = start;
            forStepBuilder.Middle = middle;
            forStepBuilder.End = end;

            stepBuilderCollection.StepBuilders.Add(forStepBuilder);

            return forStepBuilder;
        }

        ///////// <summary>
        ///////// 添加一个代码块
        ///////// </summary>
        //////public static BlockStepBuilder StepBlock<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
        //////    where TStepBuilderCollection : IStepBuilderCollection
        //////{
        //////    if (stepBuilderCollection.StepBuilders == null)
        //////    {
        //////        stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
        //////    }

        //////    BlockStepBuilder blockStepBuilder = new BlockStepBuilder();

        //////    stepBuilderCollection.StepBuilders.Add(blockStepBuilder);

        //////    return blockStepBuilder;
        //////}

        /// <summary>
        /// 添加一个缩进块
        /// </summary>
        public static PushIndentStepBuilder StepPushIndent<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string key)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            PushIndentStepBuilder pushIndentStepBuilder = new PushIndentStepBuilder();
            pushIndentStepBuilder.Key = key;

            stepBuilderCollection.StepBuilders.Add(pushIndentStepBuilder);

            return pushIndentStepBuilder;
        }

        /// <summary>
        /// StepAssignStringVariable
        /// </summary>
        public static AssignStringVariableStepBuilder StepAssignStringVariable<TStepBuilderCollection>(this TStepBuilderCollection method, string name, string value)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilderOrCollection>();
            }

            AssignStringVariableStepBuilder assignStringVariableStepBuilder = new AssignStringVariableStepBuilder();
            assignStringVariableStepBuilder.Name = name;
            assignStringVariableStepBuilder.Value = value;

            method.StepBuilders.Add(assignStringVariableStepBuilder);

            return assignStringVariableStepBuilder;
        }

        ///////// <summary>
        ///////// 调用方法
        ///////// </summary>
        //////public static StatementChainStepBuilder StepStatementChain<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string target = null)
        //////    where TStepBuilderCollection : IStepBuilderCollection
        //////{
        //////    if (stepBuilderCollection.StepBuilders == null)
        //////    {
        //////        stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
        //////    }

        //////    StatementChainStepBuilder statementChainStepBuilder = new StatementChainStepBuilder();
        //////    statementChainStepBuilder.Target = target;

        //////    stepBuilderCollection.StepBuilders.Add(statementChainStepBuilder);

        //////    return statementChainStepBuilder;
        //////}

        ///////// <summary>
        ///////// 为变量赋值
        ///////// </summary>
        //////public static AssignmentStepBuilder StepAssignment<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
        //////    where TStepBuilderCollection : IStepBuilderCollection
        //////{
        //////    if (stepBuilderCollection.StepBuilders == null)
        //////    {
        //////        stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
        //////    }

        //////    AssignmentStepBuilder assignVariableStepBuilder = new AssignmentStepBuilder();

        //////    stepBuilderCollection.StepBuilders.Add(assignVariableStepBuilder);

        //////    return assignVariableStepBuilder;
        //////}
    }







    ///////////////// <summary>
    ///////////////// StepBuilderExtension
    ///////////////// </summary>
    //////////////public static class StepBuilderExtension
    //////////////{
    //////////////    /// <summary>
    //////////////    /// Step
    //////////////    /// </summary>
    //////////////    public static TStepBuilder Step<TStepBuilder>(this TStepBuilder method, StepBuilder stepBuilder) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        method.StepBuilders.Add(stepBuilder);

    //////////////        return method;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// Steps
    //////////////    /// </summary>
    //////////////    public static TStepBuilder Steps<TStepBuilder>(this TStepBuilder method, List<StepBuilder> stepBuilders) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (stepBuilders == null || stepBuilders.Count == 0)
    //////////////        {
    //////////////            return method;
    //////////////        }

    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        method.StepBuilders.AddRange(stepBuilders);

    //////////////        return method;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepEmpty
    //////////////    /// </summary>
    //////////////    public static TStepBuilder StepEmpty<TStepBuilder>(this TStepBuilder method) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        method.StepBuilders.Add(new EmptyStepBuilder());

    //////////////        return method;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepStatement
    //////////////    /// </summary>
    //////////////    public static TStepBuilder StepStatement<TStepBuilder>(this TStepBuilder method, string statement) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        method.StepBuilders.Add(new StatementStepBuilder(statement));

    //////////////        return method;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepIf
    //////////////    /// </summary>
    //////////////    /// <typeparam name="TStepBuilder"></typeparam>
    //////////////    /// <param name="method"></param>
    //////////////    /// <param name="condition"></param>
    //////////////    /// <returns></returns>
    //////////////    public static IfStepBuilder StepIf<TStepBuilder>(this TStepBuilder method, string condition = null) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        IfStepBuilder ifStepBuilder = new IfStepBuilder();
    //////////////        ifStepBuilder.Condition = condition;

    //////////////        method.StepBuilders.Add(ifStepBuilder);

    //////////////        return ifStepBuilder;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepTry
    //////////////    /// </summary>
    //////////////    public static TryStepBuilder StepTry<TStepBuilder>(this TStepBuilder method) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        TryStepBuilder ifStepBuilder = new TryStepBuilder();

    //////////////        method.StepBuilders.Add(ifStepBuilder);

    //////////////        return ifStepBuilder;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepForeach
    //////////////    /// </summary>
    //////////////    public static ForeachStepBuilder StepForeach<TStepBuilder>(this TStepBuilder method, string type, string item, string items) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        ForeachStepBuilder foreachStepBuilder = new ForeachStepBuilder();
    //////////////        foreachStepBuilder.Type = type;
    //////////////        foreachStepBuilder.Item = item;
    //////////////        foreachStepBuilder.Items = items;

    //////////////        method.StepBuilders.Add(foreachStepBuilder);

    //////////////        return foreachStepBuilder;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepFor
    //////////////    /// </summary>
    //////////////    public static ForStepBuilder StepFor<TStepBuilder>(this TStepBuilder method, string start, string middle, string end) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        ForStepBuilder forStepBuilder = new ForStepBuilder();
    //////////////        forStepBuilder.Start = start;
    //////////////        forStepBuilder.Middle = middle;
    //////////////        forStepBuilder.End = end;

    //////////////        method.StepBuilders.Add(forStepBuilder);

    //////////////        return forStepBuilder;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepBracket
    //////////////    /// </summary>
    //////////////    public static BracketStepBuilder StepBracket<TStepBuilder>(this TStepBuilder method, string key = null, string endWith = null) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        BracketStepBuilder bracketStepBuilder = new BracketStepBuilder();
    //////////////        bracketStepBuilder.Key = key;
    //////////////        bracketStepBuilder.EndWith = endWith;

    //////////////        method.StepBuilders.Add(bracketStepBuilder);

    //////////////        return bracketStepBuilder;
    //////////////    }

    //////////////    /// <summary>
    //////////////    /// StepPushIndent
    //////////////    /// </summary>
    //////////////    public static PushIndentStepBuilder StepPushIndent<TStepBuilder>(this TStepBuilder method, string key) where TStepBuilder : StepBuilder
    //////////////    {
    //////////////        if (method.StepBuilders == null)
    //////////////        {
    //////////////            method.StepBuilders = new List<StepBuilder>();
    //////////////        }

    //////////////        PushIndentStepBuilder pushIndentStepBuilder = new PushIndentStepBuilder();
    //////////////        pushIndentStepBuilder.Key = key;

    //////////////        method.StepBuilders.Add(pushIndentStepBuilder);

    //////////////        return pushIndentStepBuilder;
    //////////////    }

}
