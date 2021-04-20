namespace Käpy.Business.Costs
{
    public abstract class Cost
    {
        public string Name { get; set; }

        public abstract bool RequirementIsMet(GameState state);

    }
}
