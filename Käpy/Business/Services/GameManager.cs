using Käpy.Business.Costs;
using Käpy.Data;
using System.Linq;

namespace Käpy.Business.Services
{
    public class GameManager : IGameManager
    {
        public GameState State { get; set; }

        public void AddResource(string resourceName, int amount)
        {
            if (!State.Resources.ContainsKey(resourceName))
            {
                State.Resources.Add(resourceName, amount);
            }
            else
            {
                State.Resources[resourceName] += amount;
            }
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
