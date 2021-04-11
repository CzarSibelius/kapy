using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Business
{
    public class GameState
    {
        public Dictionary<string, int> Resources { get; set; } = new Dictionary<string, int>();
        //private readonly Storage storage = new Storage();

        public GameState()
        {
            ResourceConfig.All.ToList().ForEach(r => Resources.Add(r.Name, 0));
        }

        public List<Technology> ResearchedTechnologies = new List<Technology>();
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

        public IEnumerable<(string Name, int Amount)> ResourceAmounts
        {
            get => UnlockedResources.Select(ur => (ur.Name, Resources[ur.Name]));
        }

        public IEnumerable<Resource> UnlockedResources { get => Resources.Select(r => ResourceConfig.Get(r.Key)).Where(r => r.IsUnlocked(this)); }

        public bool HasTechnology(string technologyName)
        {
            return ResearchedTechnologies.Any(t => t.Name == technologyName);
        }

    }
}
