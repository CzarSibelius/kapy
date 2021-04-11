using Käpy.Business;

namespace Käpy.Services
{
    public interface IGameManager
    {
        GameState State { get; }
        void Research(Technology technology);
        void AddResource(string resource, int amount);
    }
}