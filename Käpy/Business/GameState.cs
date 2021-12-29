using Käpy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Käpy.Business
{
    public class GameState
    {
        public Dictionary<string, int> Resources { get; set; } = new Dictionary<string, int>();

        public GameState()
        {
            ResourceConfig.All.ToList().ForEach(r => Resources.Add(r.Name, 0));
        }

        public List<Technology> ResearchedTechnologies { get; set; } = new List<Technology>();
       
        [JsonIgnore]
        public List<Technology> ResearchableTechnologies
        {
            get => TechnologyConfig.All
                .Where(t =>
                    !ResearchedTechnologies.Any(researched => researched.Name == t.Name) &&
                    (t.UnlockRequirements == null ||
                    t.UnlockRequirements
                        .All(c => c.RequirementIsMet(this))))
                .ToList();
        }

        [JsonIgnore]
        public IEnumerable<(string Name, int Amount)> ResourceAmounts
        {
            get => UnlockedResources.Select(ur => (ur.Name, Resources.TryGetValue(ur.Name, out var value) ? value : 0));
        }

        [JsonIgnore]
        public IEnumerable<Resource> UnlockedResources { get => ResourceConfig.All.Where(r => r.IsUnlocked(this)); }

        public bool HasTechnology(string technologyName)
        {
            return ResearchedTechnologies.Any(t => t.Name == technologyName);
        }

        public IEnumerable<ResourceBoost> GetResourceBoosts(string resourceName)
        {
            return TechnologyConfig.All.Where(tech => ResearchedTechnologies.Any(researched => researched.Name == tech.Name))
                .Where(tech => tech.ResourceBoosts != null)
                .SelectMany(tech => tech.ResourceBoosts)
                .Where(boost => boost.ResourceName == resourceName);
        }

        public IEnumerable<ResourceGenerator> GetGenerators(string resourceName)
        {
            
            var generatorConfigs = ResourceConfig.All
                .Where(tech => tech.ResourceGenerators != null)
                .SelectMany(tech => tech.ResourceGenerators)
                .Where(generator => generator.ResourceName == resourceName);

            return generatorConfigs;
        }

        public IEnumerable<ResourceGenerator> GetGenerators()
        {

            var generatorConfigs = ResourceConfig.All
                .Where(tech => tech.ResourceGenerators != null)
                .SelectMany(tech => tech.ResourceGenerators);

            return generatorConfigs;
        }

    }
}
