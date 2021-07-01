using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public class BinaryOperator
    {
        public string Value { get; private set; } = string.Empty;

        private BinaryOperator()
        {
        }

        /// <summary>
        /// +
        /// </summary>
        public static readonly BinaryOperator Add = new BinaryOperator { Value = "+" };

        /// <summary>
        /// -
        /// </summary>
        public static readonly BinaryOperator Subtract = new BinaryOperator { Value = "-" };

        /// <summary>
        /// *
        /// </summary>
        public static readonly BinaryOperator Multiply = new BinaryOperator { Value = "*" };

        /// <summary>
        /// /
        /// </summary>
        public static readonly BinaryOperator Divide = new BinaryOperator { Value = "/" };

        /// <summary>
        /// %
        /// </summary>
        public static readonly BinaryOperator Modulus = new BinaryOperator { Value = "%" };

        /// <summary>
        /// =
        /// </summary>
        public static readonly BinaryOperator Assign = new BinaryOperator { Value = "=" };

        /// <summary>
        /// !=
        /// </summary>
        public static readonly BinaryOperator IdentityInequality = new BinaryOperator { Value = "!=" };

        /// <summary>
        /// ==
        /// </summary>
        public static readonly BinaryOperator IdentityEquality = new BinaryOperator { Value = "==" };

        /// <summary>
        /// ==
        /// </summary>
        public static readonly BinaryOperator ValueEquality = new BinaryOperator { Value = "==" };

        /// <summary>
        /// |
        /// </summary>
        public static readonly BinaryOperator BitwiseOr = new BinaryOperator { Value = "|" };

        /// <summary>
        /// &amp;
        /// </summary>
        public static readonly BinaryOperator BitwiseAnd = new BinaryOperator { Value = "&" };

        /// <summary>
        /// ||
        /// </summary>
        public static readonly BinaryOperator BooleanOr = new BinaryOperator { Value = "||" };

        /// <summary>
        /// &&
        /// </summary>
        public static readonly BinaryOperator BooleanAnd = new BinaryOperator { Value = "&&" };

        /// <summary>
        /// &lt;
        /// </summary>
        public static readonly BinaryOperator LessThan = new BinaryOperator { Value = "<" };

        /// <summary>
        /// &gt;=
        /// </summary>
        public static readonly BinaryOperator LessThanOrEqual = new BinaryOperator { Value = "<=" };

        /// <summary>
        /// &gt;
        /// </summary>
        public static readonly BinaryOperator GreaterThan = new BinaryOperator { Value = ">=" };

        /// <summary>
        /// &gt;=
        /// </summary>
        public static readonly BinaryOperator GreaterThanOrEqual = new BinaryOperator { Value = ">=" };

        public static implicit operator BinaryOperator(EnumBinaryOperator binaryOperator)
        {
            switch (binaryOperator)
            {
                case EnumBinaryOperator.Add:
                    return Add;

                case EnumBinaryOperator.Subtract:
                    return Subtract;

                case EnumBinaryOperator.Multiply:
                    return Multiply;

                case EnumBinaryOperator.Divide:
                    return Divide;

                case EnumBinaryOperator.Modulus:
                    return Modulus;

                case EnumBinaryOperator.Assign:
                    return Assign;

                case EnumBinaryOperator.IdentityInequality:
                    return IdentityInequality;

                case EnumBinaryOperator.IdentityEquality:
                    return IdentityEquality;

                case EnumBinaryOperator.ValueEquality:
                    return ValueEquality;

                case EnumBinaryOperator.BitwiseOr:
                    return BitwiseOr;

                case EnumBinaryOperator.BitwiseAnd:
                    return BitwiseAnd;

                case EnumBinaryOperator.BooleanOr:
                    return BooleanOr;

                case EnumBinaryOperator.BooleanAnd:
                    return BooleanAnd;

                case EnumBinaryOperator.LessThan:
                    return LessThan;

                case EnumBinaryOperator.LessThanOrEqual:
                    return LessThanOrEqual;

                case EnumBinaryOperator.GreaterThan:
                    return GreaterThan;

                case EnumBinaryOperator.GreaterThanOrEqual:
                    return GreaterThanOrEqual;

                default:
                    break;
            }

            return new BinaryOperator();
        }
    }
}
