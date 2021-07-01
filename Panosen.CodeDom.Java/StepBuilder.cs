using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public abstract class StepBuilder : CodeObject
    {
        /// <summary>
        /// 步骤
        /// </summary>
        public List<StepBuilder> StepBuilders { get; set; }
    }


    public static class StepBuilderExtension
    {
        public static TStepBuilder Step<TStepBuilder>(this TStepBuilder method, StepBuilder stepBuilder) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            method.StepBuilders.Add(stepBuilder);

            return method;
        }
        public static TStepBuilder Steps<TStepBuilder>(this TStepBuilder method, List<StepBuilder> stepBuilders) where TStepBuilder : StepBuilder
        {
            if (stepBuilders == null || stepBuilders.Count == 0)
            {
                return method;
            }

            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            method.StepBuilders.AddRange(stepBuilders);

            return method;
        }

        public static TStepBuilder StepEmpty<TStepBuilder>(this TStepBuilder method) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            method.StepBuilders.Add(new EmptyStepBuilder());

            return method;
        }

        public static TStepBuilder StepStatement<TStepBuilder>(this TStepBuilder method, string statement) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            method.StepBuilders.Add(new StatementStepBuilder(statement));

            return method;
        }

        public static IfStepBuilder StepIf<TStepBuilder>(this TStepBuilder method, string condition = null) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            IfStepBuilder ifStepBuilder = new IfStepBuilder();
            ifStepBuilder.Condition = condition;

            method.StepBuilders.Add(ifStepBuilder);

            return ifStepBuilder;
        }

        public static TryStepBuilder StepTry<TStepBuilder>(this TStepBuilder method) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            TryStepBuilder ifStepBuilder = new TryStepBuilder();

            method.StepBuilders.Add(ifStepBuilder);

            return ifStepBuilder;
        }

        public static ForeachStepBuilder StepForeach<TStepBuilder>(this TStepBuilder method, string type, string item, string items) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            ForeachStepBuilder foreachStepBuilder = new ForeachStepBuilder();
            foreachStepBuilder.Type = type;
            foreachStepBuilder.Item = item;
            foreachStepBuilder.Items = items;

            method.StepBuilders.Add(foreachStepBuilder);

            return foreachStepBuilder;
        }

        public static ForStepBuilder StepFor<TStepBuilder>(this TStepBuilder method, string start, string middle, string end) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            ForStepBuilder forStepBuilder = new ForStepBuilder();
            forStepBuilder.Start = start;
            forStepBuilder.Middle = middle;
            forStepBuilder.End = end;

            method.StepBuilders.Add(forStepBuilder);

            return forStepBuilder;
        }

        public static BracketStepBuilder StepBracket<TStepBuilder>(this TStepBuilder method, string key = null, string endWith = null) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            BracketStepBuilder bracketStepBuilder = new BracketStepBuilder();
            bracketStepBuilder.Key = key;
            bracketStepBuilder.EndWith = endWith;

            method.StepBuilders.Add(bracketStepBuilder);

            return bracketStepBuilder;
        }

        public static PushIndentStepBuilder StepPushIndent<TStepBuilder>(this TStepBuilder method, string key) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            PushIndentStepBuilder pushIndentStepBuilder = new PushIndentStepBuilder();
            pushIndentStepBuilder.Key = key;

            method.StepBuilders.Add(pushIndentStepBuilder);

            return pushIndentStepBuilder;
        }

        public static AssignStringVariableStepBuilder StepAssignStringVariable<TStepBuilder>(this TStepBuilder method, string name, string value) where TStepBuilder : StepBuilder
        {
            if (method.StepBuilders == null)
            {
                method.StepBuilders = new List<StepBuilder>();
            }

            AssignStringVariableStepBuilder assignStringVariableStepBuilder = new AssignStringVariableStepBuilder();
            assignStringVariableStepBuilder.Name = name;
            assignStringVariableStepBuilder.Value = value;

            method.StepBuilders.Add(assignStringVariableStepBuilder);

            return assignStringVariableStepBuilder;
        }
    }
}
