using System;
using System.Linq;
using System.Reflection;

namespace ToDo.Core.Infrastructure
{
    public static class CoreHelper
    {
        public static Assembly[] GetPlatformAndAppAssemblies()
        {
            var platformAndAppNames = new[] { "Cynosura", "ToDo" };
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => platformAndAppNames.Any(n => a.FullName.Contains(n)) ||
                            a.GetReferencedAssemblies()
                                .Any(ra => platformAndAppNames.Any(n => ra.FullName.Contains(n))))
                .ToArray();
        }
    }
}
