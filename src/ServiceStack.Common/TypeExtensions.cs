using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace ServiceStack
{
    public static class TypeExtensions
    {
        public static Type[] GetReferencedTypes(this Type type)
        {
            var refTypes = new HashSet<Type> { type };

            AddReferencedTypes(type, refTypes);

            return refTypes.ToArray();
        }

        public static void AddReferencedTypes(Type type, HashSet<Type> refTypes)
        {

#if !NETFX_CORE
            var t = type;
#else
            var t = type.GetTypeInfo();
#endif


            if (t.BaseType != null)
            {
                if (!refTypes.Contains(t.BaseType))
                {
                    refTypes.Add(t.BaseType);
                    AddReferencedTypes(t.BaseType, refTypes);
                }

                if (!t.BaseType.GetGenericArguments().IsEmpty())
                {
                    foreach (var arg in t.BaseType.GetGenericArguments())
                    {
                        if (!refTypes.Contains(arg))
                        {
                            refTypes.Add(arg);
                            AddReferencedTypes(arg, refTypes);
                        }
                    }
                }
            }

            var properties = type.GetProperties();
            if (!properties.IsEmpty())
            {
                foreach (var p in properties)
                {
                    if (!refTypes.Contains(p.PropertyType))
                    {
                        refTypes.Add(p.PropertyType);
                        AddReferencedTypes(type, refTypes);
                    }

                    var args = p.PropertyType.GetGenericArguments();
                    if (!args.IsEmpty())
                    {
                        foreach (var arg in args)
                        {
                            if (!refTypes.Contains(arg))
                            {
                                refTypes.Add(arg);
                                AddReferencedTypes(arg, refTypes);
                            }
                        }
                    }
                    else if (p.PropertyType.IsArray)
                    {
                        var elType = p.PropertyType.GetElementType();
                        if (!refTypes.Contains(elType))
                        {
                            refTypes.Add(elType);
                            AddReferencedTypes(elType, refTypes);
                        }
                    }
                }
            }
        }

    }

}