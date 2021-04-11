using System.Linq;

namespace Käpy.Business
{
    public abstract class Cost
    {
        public string Name { get; set; }

        public abstract bool RequirementIsMet(GameState state);
        
    }

    public class ResourceCost : Cost
    {
        public int Amount { get; set; }

        public override bool RequirementIsMet(GameState state)
        {
            return state.Resources[Name] >= Amount;
        }
    }

    public class TechnologyCost : Cost
    {
        public override bool RequirementIsMet(GameState state)
        {
            return state.ResearchedTechnologies.Any(t => t.Name == Name);
        }
    }
}
