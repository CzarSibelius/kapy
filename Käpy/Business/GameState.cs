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
        public List<Technology> UnresearchedTechnologies
        {
            get => Technologies.All
                .Where(t =>
                    !ResearchedTechnologies.Any(researched => researched.Name == t.Name) &&
                    (t.UnlockCosts == null || t.UnlockCosts.All(c => storage.All.Any(x => x.Key == c.Name && x.Value.Amount >= c.Amount))))
                .ToList();
        }

        public List<Resource> Resources
        {
            get => storage.All.Where(r => r.Value.RequirementFn(this)).Select(r => r.Value).ToList();
        }

        public void AddResource(string resourceName, int amount)
        {
            storage.Add(resourceName, amount);
            var resource = storage.All[resourceName];

            resource.Costs?.ToList().ForEach(c => AddResource(c.Name, -1 * c.Amount));
        }

        public bool CanBeBuilt(Resource resource)
        {
            if (resource.Costs == null)
            {
                return true;
            }
            foreach (var cost in resource.Costs)
            {
                if (storage.All[cost.Name].Amount < cost.Amount)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
