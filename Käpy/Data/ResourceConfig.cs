using Käpy.Business;
using Käpy.Business.Attributes;
using Käpy.Business.Costs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Käpy.Data
{
    public static class ResourceConfig
    {
        public const string Käpy = "Käpy";

        [RequiresTechnology(TechnologyConfig.Tikku)]
        public const string Tikku = "Tikku";

        [RequiresTechnology(TechnologyConfig.Käpylehmä)]
        [RequiresResource(Käpy, 1)]
        [RequiresResource(Tikku, 4)]
        public const string Käpylehmä = "Käpylehmä";

        [RequiresTechnology(TechnologyConfig.Oravat)]
        [ResourceGenerator(ResourceConfig.Käpy, 1, 10)]
        public const string Orava = "Orava";

        public static IEnumerable<Resource> All
        {
            get => typeof(ResourceConfig)
                    .GetFields()
                    .Where(fi => fi.IsPublic && fi.IsStatic)
                    .Select(fi => new Resource
                    {
                        Name = fi.GetValue(null) as string,
                        BuildRequirements = GetResourceRequirements(fi).ToList(),
                        UnlockRequirements = GetTechnologyRequirements(fi).ToList(),
                        ResourceGenerators = GetResourceGenerators(fi).ToList()
                    });
        }

        public static Resource Get(string resourceName)
        {
            try
            {
                return All.Single(r => r.Name == resourceName);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Could not find resourceName '{resourceName}' from Resource configuration.");
                throw;
            }

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

        private static IEnumerable<ResourceGenerator> GetResourceGenerators(FieldInfo fieldInfo)
        {
            return fieldInfo.GetCustomAttributes(false)
                            .Where(a => a is ResourceGeneratorAttribute)
                            .Cast<ResourceGeneratorAttribute>()
                            .Select(a => new ResourceGenerator { GeneratorResourceName = fieldInfo.Name, ResourceName = a.ResourceName, Amount = a.Amount, TickAmount = a.TickAmount });
        }
    }


}
