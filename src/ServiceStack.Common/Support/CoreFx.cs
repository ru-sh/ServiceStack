#if NETFX_CORE
using System;
using System.Linq;
using System.Collections.Generic;

namespace ServiceStack
{
    public static class CoreFx
    {
        public static IEnumerable<Type> FindInterfaces(this Type type, Func<Type, object, bool> predicate, object criteria)
        {
            var interfaces = type.GetTypeInfo().ImplementedInterfaces;

            return interfaces
                .Where(t => predicate(t, criteria))
                .ToArray();
        }
    }
}
#endif