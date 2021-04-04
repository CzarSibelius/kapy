using System;
using System.Collections.Generic;
using System.Linq;

namespace Käpy.Business
{
    public class Resource
    {
        public string Name { get; set; }

        public Func<GameState, bool> RequirementFn { get; set; } = NoRequirements();

        //public Func<GameState, bool> CanBeBuilt { get; set; } = (GameState s) =>
        //    Cost == null || Cost.All(c => s.Resources.Any(r => r.Name == c.Item1 && r.Amount >= c.Item2));

        //public Action<GameState> BuildCost { get; set; } = NoCost();

        public IEnumerable<(string, int)> Costs = null;

        public int Amount { get; set; }

        public static IEnumerable<Resource> All
        {
            get => new[]
            {
                new Resource { Name = "Käpy"},
                new Resource { Name = "Tikku"},
                new Resource { Name = "Käpylehmä",
                    RequirementFn = RequiresTechnology(Technologies.Käpylehmä),
                    //CanBeBuilt = (GameState s) =>
                    //    s.Resources.Any(r => r.Name == "Käpy" && r.Amount >= 1) &&
                    //    s.Resources.Any(r => r.Name == "Tikku" && r.Amount >= 4),
                    //BuildCost = (GameState s) => {s.AddResource("Käpy", -1); s.AddResource("Tikku", -4); }
                    Costs = new []
                    {
                        ("Käpy", 1),
                        ("Tikku", 4)
                    }
                },
            };
        }

        public static Func<GameState, bool> NoRequirements()
        {
            return (GameState) => true;
        }

        public static Func<GameState, bool> RequiresTechnology(string technology)
        {
            return (GameState s) => s.ResearchedTechnologies.Any(t => t.Name == technology);
        }

        public static Action<GameState> NoCost()
        {
            return (GameState) => { };
        }
    }

}
