namespace Käpy.Business.Costs
{
    public class ResourceCost : Cost
    {
        public int Amount { get; set; }

        public override bool RequirementIsMet(GameState state)
        {
            return state.Resources[Name] >= Amount;
        }
    }
}
