using Käpy.Business;
using Käpy.Business.Costs;
using Käpy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Services
{
    public class GameManager : IGameManager
    {
        public GameState State { get; set; }

        public void AddResource(string resourceName, int amount)
        {
            State.Resources[resourceName] += amount;
            var resource = ResourceConfig.Get(resourceName);

            resource.BuildRequirements?
                .Where(c => c is ResourceCost)
                .Cast<ResourceCost>()
                .ToList()
                .ForEach(c => State.Resources[c.Name] -= c.Amount);
        }

        public void Research(Technology technology)
        {
            State.ResearchedTechnologies.Add(technology);
        }
    }
}
