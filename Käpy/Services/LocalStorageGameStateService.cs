using Blazored.LocalStorage;
using Käpy.Business;
using System;
using System.Threading.Tasks;

namespace Käpy.Services
{
    public class LocalStorageGameStateService : IGameStateStorageService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly ISyncLocalStorageService syncLocalStorageService;

        private const string gameStateStorageKey = "gamestate";

        public LocalStorageGameStateService(
            ILocalStorageService localStorageService,
            ISyncLocalStorageService syncLocalStorageService)
        {
            this.localStorageService = localStorageService;
            this.syncLocalStorageService = syncLocalStorageService;
        }
        public async Task SaveStateAsync(GameState state)
        {
            await localStorageService.SetItemAsync(gameStateStorageKey, state);
        }

        public GameState GetState()
        {
            var stateFromStorage = syncLocalStorageService.GetItem<GameState>(gameStateStorageKey);
            Console.WriteLine(syncLocalStorageService.GetItemAsString(gameStateStorageKey));
            return stateFromStorage ?? new GameState();
        }

        public async Task<GameState> GetStateAsync()
        {
            var stateFromStorage = await localStorageService.GetItemAsync<GameState>(gameStateStorageKey);
            return stateFromStorage ?? new GameState();
        }


    }
}
