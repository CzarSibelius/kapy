using Käpy.Business;
using System.Threading.Tasks;

namespace Käpy.Services
{
    public interface IGameManager
    {
        GameState State { get; set; }
        void Research(Technology technology);
        void AddResource(string resource, int amount);
    }
}