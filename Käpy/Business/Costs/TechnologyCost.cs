using System.Linq;

namespace Käpy.Business.Costs
{
    public class TechnologyCost : Cost
    {
        public override bool RequirementIsMet(GameState state)
        {
            return state.ResearchedTechnologies.Any(t => t.Name == Name);
        }
    }
}
