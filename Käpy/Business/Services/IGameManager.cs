namespace Käpy.Business.Services
{
    public interface IGameManager
    {
        GameState State { get; set; }
        void Research(Technology technology);
        void AddResource(string resource, int amount);
    }
}