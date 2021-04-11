using Käpy.Business;
using System.Threading.Tasks;

namespace Käpy.Services
{
    public interface IGameStateStorageService
    {
        GameState GetState();
        Task<GameState> GetStateAsync();
        Task SaveStateAsync(GameState state);
    }
}