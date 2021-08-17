using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// EnumBinaryOperator
    /// </summary>
    public enum EnumBinaryOperator
    {
        /// <summary>
        /// +
        /// </summary>
        Add,

        /// <summary>
        /// -
        /// </summary>
        Subtract,

        /// <summary>
        /// *
        /// </summary>
        Multiply,

        /// <summary>
        /// /
        /// </summary>
        Divide,

        /// <summary>
        /// %
        /// </summary>
        Modulus,

        /// <summary>
        /// =
        /// </summary>
        Assign,

        /// <summary>
        /// !=
        /// </summary>
        IdentityInequality,

        /// <summary>
        /// ==
        /// </summary>
        IdentityEquality,

        /// <summary>
        /// ==
        /// </summary>
        ValueEquality,

        /// <summary>
        /// |
        /// </summary>
        BitwiseOr,

        /// <summary>
        /// &amp;
        /// </summary>
        BitwiseAnd,

        /// <summary>
        /// ||
        /// </summary>
        BooleanOr,

        /// <summary>
        /// &amp;&amp;
        /// </summary>
        BooleanAnd,

        /// <summary>
        /// &lt;
        /// </summary>
        LessThan,

        /// <summary>
        /// &gt;=
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// &gt;
        /// </summary>
        GreaterThan,

        /// <summary>
        /// &gt;=
        /// </summary>
        GreaterThanOrEqual
    }
}
