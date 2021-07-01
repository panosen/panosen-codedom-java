using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public class IfStepBuilder : StepBuilder
    {
        public string Condition { get; set; }

        public List<ElseIfStepBuilder> ElseIfStepBuilders { get; set; }

        public ElseStepBuilder ElseStepBuilder { get; set; }
    }


    public static class IfStepBuilderExtension
    {
        public static ElseIfStepBuilder WithElseIf(this IfStepBuilder ifStepBuilder, string condition)
        {
            if (ifStepBuilder.ElseIfStepBuilders == null)
            {
                ifStepBuilder.ElseIfStepBuilders = new List<ElseIfStepBuilder>();
            }

            ElseIfStepBuilder elseIfStepBuilder = new ElseIfStepBuilder();
            elseIfStepBuilder.Condition = condition;
            ifStepBuilder.ElseIfStepBuilders.Add(elseIfStepBuilder);

            return elseIfStepBuilder;
        }

        public static ElseStepBuilder WithElse(this IfStepBuilder ifStepBuilder)
        {
            ElseStepBuilder elseStepBuilder = new ElseStepBuilder();

            ifStepBuilder.ElseStepBuilder = elseStepBuilder;

            return elseStepBuilder;
        }
    }
}
