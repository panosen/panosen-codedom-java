using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java
{
    public enum CodeValueType
    {
        /// <summary>
        /// 保持原样
        /// </summary>
        PLAIN = 0,

        /// <summary>
        /// 需要用双引号包裹
        /// </summary>
        STRING = 1
    }
}
