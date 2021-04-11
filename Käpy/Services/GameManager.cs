using Käpy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Services
{
    public class GameManager : IGameManager
    {
        private readonly IGameStateStorageService gameStateStorageService;
        public GameState GameState { get; }

        public GameManager(IGameStateStorageService gameStateStorageService)
        {
            this.gameStateStorageService = gameStateStorageService;

            GameState = this.gameStateStorageService.GetState();
        }

        public GameState State => GameState;

        public void AddResource(string resourceName, int amount)
        {
            GameState.Resources[resourceName] += amount;
            var resource = ResourceConfig.Get(resourceName);

            resource.BuildRequirements?
                .Where(c => c is ResourceCost)
                .Cast<ResourceCost>()
                .ToList()
                .ForEach(c => GameState.Resources[c.Name] -= c.Amount);
        }

        public void Research(Technology technology)
        {
            GameState.ResearchedTechnologies.Add(technology);
        }
    }
}
