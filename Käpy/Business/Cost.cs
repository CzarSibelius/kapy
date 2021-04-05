using System.Linq;

namespace Käpy.Business
{
    public abstract class Cost
    {
        public string Name { get; set; }

        public abstract bool RequirementCanBeMet(GameState state);
        
    }

    public class ResourceCost : Cost
    {
        public int Amount { get; set; }

        public override bool RequirementCanBeMet(GameState state)
        {
            return state.Resources.Any(r => r.Name == Name && r.Amount >= Amount);
        }
    }

    public class TechnologyCost : Cost
    {
        public override bool RequirementCanBeMet(GameState state)
        {
            return state.ResearchedTechnologies.Any(t => t.Name == Name);
        }
    }
}
