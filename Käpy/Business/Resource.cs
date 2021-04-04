using System;
using System.Collections.Generic;

namespace Käpy.Business
{
    public class Resource
    {
        public string Name { get; set; }

        public Func<GameState, bool> RequirementFn { get; set; } = NoRequirements();

        public IEnumerable<(string, int)> Costs = null;

        public int Amount { get; set; }

        public static Func<GameState, bool> NoRequirements()
        {
            return (GameState) => true;
        }
    }
}
