using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 访问修饰符
    /// </summary>
    public class AccessModifiers
    {
        public string Value { get; private set; }

        private AccessModifiers()
        {
        }

        public static readonly AccessModifiers Public = new AccessModifiers { Value = "public" };

        public static readonly AccessModifiers Private = new AccessModifiers { Value = "private" };

        public static readonly AccessModifiers Protected = new AccessModifiers { Value = "protected" };
    }
}
