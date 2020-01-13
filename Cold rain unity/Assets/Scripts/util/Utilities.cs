using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.util
{
    class Utilities
    {
        public static IEnumerable<Type> GetAssembliesOfType(Type t)
        {
            Type type = t;
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            return types;
        }

        
    }
}
