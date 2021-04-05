using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Käpy.Business
{
    public static class Technologies
    {
        [RequiresResource(Resources.Käpy, 100)]
        public const string Tikku = "Tikkujen kerääminen";

        [RequiresTechnology(Technologies.Tikku)]
        [RequiresResource(Resources.Tikku, 40)]
        public const string Käpylehmä = "Käpylehmän rakentaminen";

        public static IEnumerable<Technology> All
        {
            get => typeof(Technologies)
                    .GetFields()
                    .Where(fi => fi.IsPublic && fi.IsStatic)
                    .Select(fi => new Technology
                    {
                        Name = fi.GetValue(null) as string,
                        UnlockRequirements = GetResourceRequirements(fi).Concat(GetTechnologyRequirements(fi))
                    });
        }

        private static IEnumerable<Cost> GetResourceRequirements(FieldInfo fieldInfo)
        {
            return fieldInfo.GetCustomAttributes(false)
                            .Where(a => a is RequiresResourceAttribute)
                            .Cast<RequiresResourceAttribute>()
                            .Select(a => new ResourceCost { Name = a.Name, Amount = a.Amount });
        }

        private static IEnumerable<Cost> GetTechnologyRequirements(FieldInfo fieldInfo)
        {
            return fieldInfo.GetCustomAttributes(false)
                            .Where(a => a is RequiresTechnologyAttribute)
                            .Cast<RequiresTechnologyAttribute>()
                            .Select(a => new TechnologyCost { Name = a.Name });
        }
    }
}
