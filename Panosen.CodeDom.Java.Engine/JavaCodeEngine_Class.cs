using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Java.Engine
{
    partial class JavaCodeEngine
    {
        /// <summary>
        /// 生成类
        /// </summary>
        public void GenerateClass(CodeClass codeClass, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeClass == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeClass.Summary, codeWriter, options);

            GenerateAttributeList(codeClass.AttributeList, codeWriter, options);

            codeWriter.Write(options.IndentString);

            if (codeClass.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeClass.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            if (codeClass.IsFinal)
            {
                codeWriter.Write(Keywords.FINAL).Write(Marks.WHITESPACE);
            }

            if (codeClass.IsAbstract)
            {
                codeWriter.Write(Keywords.ABSTRACT).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.CLASS).Write(Marks.WHITESPACE).Write(codeClass.Name ?? string.Empty);

            if (codeClass.BaseClass != null)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Keywords.EXTENDS).Write(Marks.WHITESPACE).Write(codeClass.BaseClass.Name ?? string.Empty);
            }

            if (codeClass.InterfaceList != null && codeClass.InterfaceList.Count > 0)
            {
                foreach (var codeInterface in codeClass.InterfaceList)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(Keywords.IMPLEMENTS).Write(Marks.WHITESPACE).Write(codeInterface.Name ?? string.Empty);
                }
            }

            codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            if (codeClass.ConstantList != null && codeClass.ConstantList.Count > 0)
            {
                foreach (var codeConstant in codeClass.ConstantList)
                {
                    codeWriter.WriteLine();
                    GenerateConstant(codeConstant, codeWriter, options);
                }
            }

            if (codeClass.FieldList != null && codeClass.FieldList.Count > 0)
            {
                foreach (var codeField in codeClass.FieldList)
                {
                    codeWriter.WriteLine();
                    GenerateField(codeField, codeWriter, options);
                }
            }

            if (codeClass.PropertyList != null && codeClass.PropertyList.Count > 0)
            {
                foreach (var codeProperty in codeClass.PropertyList)
                {
                    codeWriter.WriteLine();
                    GeneratePropertyField(codeProperty, codeWriter, options);
                }
            }

            if (codeClass.StaticConstructor != null)
            {
                codeWriter.WriteLine();
                GenerateStaticConstructor(codeClass.StaticConstructor, codeWriter, options);
            }

            if (codeClass.ConstructorList != null && codeClass.ConstructorList.Count > 0)
            {
                foreach (var codeConstructor in codeClass.ConstructorList)
                {
                    codeWriter.WriteLine();
                    GenerateMethod(codeConstructor, codeWriter, options);
                }
            }

            if (codeClass.PropertyList != null && codeClass.PropertyList.Count > 0)
            {
                foreach (var codeProperty in codeClass.PropertyList)
                {
                    codeWriter.WriteLine();
                    GeneratePropertyMethod(codeProperty, codeWriter, options);
                }
            }

            if (codeClass.MethodList != null && codeClass.MethodList.Count > 0)
            {
                foreach (var codeMethod in codeClass.MethodList)
                {
                    codeWriter.WriteLine();
                    GenerateMethod(codeMethod, codeWriter, options);
                }
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }

        private void GenerateAttributeList(List<CodeAttribute> attributeList, CodeWriter codeWriter, GenerateOptions options)
        {
            if (attributeList == null || attributeList.Count <= 0)
            {
                return;
            }
            foreach (var codeAttribute in attributeList)
            {
                codeWriter.Write(options.IndentString);
                GenerateAttribute(codeAttribute, codeWriter, options);
                codeWriter.WriteLine();
            }
        }
    }
}
