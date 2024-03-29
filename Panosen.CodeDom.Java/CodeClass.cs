﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Java
{
    /// <summary>
    /// 类
    /// </summary>
    public class CodeClass : CodeObject
    {
        /// <summary>
        /// 是否是抽象类
        /// </summary>
        public bool IsAbstract { get; set; }

        /// <summary>
        /// final
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public List<CodeProperty> PropertyList { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public List<CodeField> FieldList { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public List<CodeMethod> MethodList { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public List<CodeMethod> ConstructorList { get; set; }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        public StaticConstructor StaticConstructor { get; set; }

        /// <summary>
        /// 该类实现的接口
        /// </summary>
        public List<CodeInterface> InterfaceList { get; set; }

        /// <summary>
        /// 该类实现的接口
        /// </summary>
        public CodeClass BaseClass { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeAttribute> AttributeList { get; set; }
    }

    /// <summary>
    /// CodeClassExtension
    /// </summary>
    public static class CodeClassExtension
    {
        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeClass AddAttribute(this CodeClass codeClass, CodeAttribute codeAttribute)
        {
            if (codeClass.AttributeList == null)
            {
                codeClass.AttributeList = new List<CodeAttribute>();
            }

            codeClass.AttributeList.Add(codeAttribute);

            return codeClass;
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        public static CodeAttribute AddAttribute(this CodeClass codeClass, string name)
        {
            if (codeClass.AttributeList == null)
            {
                codeClass.AttributeList = new List<CodeAttribute>();
            }

            CodeAttribute codeAttribute = new CodeAttribute();
            codeAttribute.Name = name;

            codeClass.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        /// <summary>
        /// AddInterface
        /// </summary>
        public static CodeClass AddInterface(this CodeClass codeClass, CodeInterface codeInterface)
        {
            if (codeClass.InterfaceList == null)
            {
                codeClass.InterfaceList = new List<CodeInterface>();
            }

            codeClass.InterfaceList.Add(codeInterface);

            return codeClass;
        }

        /// <summary>
        /// AddInterface
        /// </summary>
        public static CodeInterface AddInterface(this CodeClass codeClass, string name, string summary = null)
        {
            if (codeClass.InterfaceList == null)
            {
                codeClass.InterfaceList = new List<CodeInterface>();
            }

            CodeInterface codeInterface = new CodeInterface();
            codeInterface.Name = name;
            codeInterface.Summary = summary;

            codeClass.InterfaceList.Add(codeInterface);

            return codeInterface;
        }

        /// <summary>
        /// SetBaseClass
        /// </summary>
        public static CodeClass SetBaseClass(this CodeClass codeClass, string name, string summary = null)
        {
            CodeClass baseClass = new CodeClass();
            baseClass.Name = name;
            baseClass.Summary = summary;

            codeClass.BaseClass = baseClass;

            return codeClass;
        }

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static CodeClass AddMethod(this CodeClass codeClass, CodeMethod codeMethod)
        {
            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            codeClass.MethodList.Add(codeMethod);

            return codeClass;
        }

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static CodeMethod AddMethod(this CodeClass codeClass, string name, string summary = null)
        {
            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = name;
            codeMethod.Summary = summary;

            codeClass.MethodList.Add(codeMethod);

            return codeMethod;
        }

        /// <summary>
        /// 添加一批方法
        /// </summary>
        public static CodeClass AddMethods(this CodeClass codeClass, List<CodeMethod> codeMethods)
        {
            if (codeMethods == null || codeMethods.Count == 0)
            {
                return codeClass;
            }

            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            codeClass.MethodList.AddRange(codeMethods);

            return codeClass;
        }

        /// <summary>
        /// 添加构造函数
        /// </summary>
        public static CodeClass AddConstructor(this CodeClass codeClass, CodeMethod codeMethod)
        {
            if (codeClass.ConstructorList == null)
            {
                codeClass.ConstructorList = new List<CodeMethod>();
            }

            codeClass.ConstructorList.Add(codeMethod);

            return codeClass;
        }

        /// <summary>
        /// 添加构造函数
        /// </summary>
        public static CodeMethod AddConstructor(this CodeClass codeClass)
        {
            if (codeClass.ConstructorList == null)
            {
                codeClass.ConstructorList = new List<CodeMethod>();
            }

            CodeMethod codeMethod = new CodeMethod();

            codeClass.ConstructorList.Add(codeMethod);

            return codeMethod;
        }

        /// <summary>
        /// 添加静态构造函数
        /// </summary>
        public static CodeClass AddStaticConstructor(this CodeClass codeClass, StaticConstructor staticConstructor)
        {
            codeClass.StaticConstructor = staticConstructor;

            return codeClass;
        }

        /// <summary>
        /// 添加静态构造函数
        /// </summary>
        public static StaticConstructor AddStaticConstructor(this CodeClass codeClass)
        {
            StaticConstructor staticConstructor = new StaticConstructor();

            codeClass.StaticConstructor = staticConstructor;

            return staticConstructor;
        }

        /// <summary>
        /// AddProperty
        /// </summary>
        public static CodeClass AddProperty(this CodeClass codeClass, CodeProperty codeProperty)
        {
            if (codeClass.PropertyList == null)
            {
                codeClass.PropertyList = new List<CodeProperty>();
            }

            codeClass.PropertyList.Add(codeProperty);

            return codeClass;
        }

        /// <summary>
        /// AddProperty
        /// </summary>
        public static CodeClass AddProperties(this CodeClass codeClass, List<CodeProperty> properties)
        {
            if (properties == null || properties.Count == 0)
            {
                return codeClass;
            }

            if (codeClass.PropertyList == null)
            {
                codeClass.PropertyList = new List<CodeProperty>();
            }

            codeClass.PropertyList.AddRange(properties);

            return codeClass;
        }

        /// <summary>
        /// AddProperty
        /// </summary>
        public static CodeProperty AddProperty(this CodeClass codeClass, string type, string name, bool isStatic = false, string summary = null, string plainValue = null, string stringValue = null)
        {
            if (codeClass.PropertyList == null)
            {
                codeClass.PropertyList = new List<CodeProperty>();
            }

            CodeProperty codeProperty = new CodeProperty();
            codeProperty.Type = type;
            codeProperty.Name = name;
            codeProperty.IsStatic = isStatic;
            codeProperty.Summary = summary;
            if (plainValue != null)
            {
                codeProperty.AddPlainValue(plainValue);
            }
            if (stringValue != null)
            {
                codeProperty.AddStringValue(stringValue);
            }

            codeClass.PropertyList.Add(codeProperty);

            return codeProperty;
        }

        /// <summary>
        /// AddField
        /// </summary>
        public static CodeClass AddField(this CodeClass codeClass, CodeField codeField)
        {
            if (codeClass.FieldList == null)
            {
                codeClass.FieldList = new List<CodeField>();
            }

            codeClass.FieldList.Add(codeField);

            return codeClass;
        }

        /// <summary>
        /// AddFields
        /// </summary>
        public static CodeClass AddFields(this CodeClass codeClass, List<CodeField> codeFields)
        {
            if (codeFields == null || codeFields.Count == 0)
            {
                return codeClass;
            }

            if (codeClass.FieldList == null)
            {
                codeClass.FieldList = new List<CodeField>();
            }

            codeClass.FieldList.AddRange(codeFields);

            return codeClass;
        }

        /// <summary>
        /// AddField
        /// </summary>
        public static CodeField AddField(this CodeClass codeClass,
            string type, string name, bool isFinal = false, bool isStatic = false, string summary = null,
            AccessModifiers accessModifiers = AccessModifiers.None)
        {
            if (codeClass.FieldList == null)
            {
                codeClass.FieldList = new List<CodeField>();
            }

            CodeField codeField = new CodeField();
            codeField.AccessModifiers = accessModifiers;
            codeField.Name = name;
            codeField.Type = type;
            codeField.IsFinal = isFinal;
            codeField.IsStatic = isStatic;
            codeField.Summary = summary;

            codeClass.FieldList.Add(codeField);

            return codeField;
        }
    }
}
