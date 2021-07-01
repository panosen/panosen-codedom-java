using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        public void GenerateParameter(CodeParameter codeParameter, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeParameter == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeParameter.AttributeList != null && codeParameter.AttributeList.Count > 0)
            {
                foreach (var codeAttribute in codeParameter.AttributeList)
                {
                    GenerateAttribute(codeAttribute, codeWriter, options);
                    codeWriter.Write(Marks.WHITESPACE);
                }
            }
            codeWriter.Write(codeParameter.Type ?? string.Empty).Write(Marks.WHITESPACE).Write(codeParameter.Name ?? string.Empty);
        }
    }
}
