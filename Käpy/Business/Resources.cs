using System;
using System.Collections.Generic;
using System.Linq;

namespace Käpy.Business
{
    public static class Resources
    {
        public static IEnumerable<Resource> All
        {
            get => new[]
            {
                new Resource { Name = "Käpy"},
                new Resource { Name = "Tikku", RequirementFn = RequiresTechnology(Technologies.Tikku)},
                new Resource { Name = "Käpylehmä",
                    RequirementFn = RequiresTechnology(Technologies.Käpylehmä),
                    Costs = new []
                    {
                        ("Käpy", 1),
                        ("Tikku", 4)
                    }
                },
            };
        }

        public static Func<GameState, bool> RequiresTechnology(string technology)
        {
            return (GameState s) => s.ResearchedTechnologies.Any(t => t.Name == technology);
        }
    }

}
