using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Business
{
    public class GameState
    {
        private readonly Storage storage = new Storage();

        public List<Technology> ResearchedTechnologies = new List<Technology>();
        public List<Technology> ResearchableTechnologies
        {
            get => Technologies.All
                .Where(t =>
                    !ResearchedTechnologies.Any(researched => researched.Name == t.Name) &&
                    (t.UnlockRequirements == null ||
                    t.UnlockRequirements
                        .All(c => c.RequirementIsMet(this))))
                .ToList();
        }

        public List<Resource> Resources
        {
            get => storage.All
                .Select(r => r.Value)
                .ToList();
        }

        public void AddResource(string resourceName, int amount)
        {
            storage.Add(resourceName, amount);
            var resource = storage.All[resourceName];

            resource.BuildRequirements?
                .Where(c => c is ResourceCost)
                .Cast<ResourceCost>()
                .ToList()
                .ForEach(c => AddResource(c.Name, -1 * c.Amount));
        }

        public bool HasTechnology(string technologyName)
        {
            return ResearchedTechnologies.Any(t => t.Name == technologyName);
        }

    }
}
