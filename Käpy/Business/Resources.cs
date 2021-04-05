using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Käpy.Business
{
    public static class Resources
    {
        public const string Käpy = "Käpy";

        [RequiresTechnology(Technologies.Tikku)]
        public const string Tikku = "Tikku";

        [RequiresTechnology(Technologies.Käpylehmä)]
        [RequiresResource(Resources.Käpy, 1)]
        [RequiresResource(Resources.Tikku, 4)]
        public const string Käpylehmä = "Käpylehmä";

        public static IEnumerable<Resource> All
        {
            get => typeof(Resources)
                    .GetFields()
                    .Where(fi => fi.IsPublic && fi.IsStatic)
                    .Select(fi => new Resource
                    {
                        Name = fi.GetValue(null) as string,
                        BuildRequirements = GetResourceRequirements(fi).ToList(),
                        UnlockRequirements = GetTechnologyRequirements(fi).ToList()
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
