using Käpy.Business.Costs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Käpy.Business
{
    public class Resource
    {
        public string Name { get; set; }

        public List<Cost> BuildRequirements = new List<Cost>();

        public List<Cost> UnlockRequirements = new List<Cost>();

        public List<ResourceGenerator> ResourceGenerators = new List<ResourceGenerator>();

        public bool CanBeBuilt(GameState state)
        {
            if(!BuildRequirements.Any())
            {
                return true;
            }

            return BuildRequirements.All(c => c.RequirementIsMet(state));
        }

        public bool IsUnlocked(GameState state)
        {
            
            if (!UnlockRequirements.Any())
            {
                return true;
            }

            var requirementsFulfilled = UnlockRequirements.All(c => c.RequirementIsMet(state));
            return requirementsFulfilled;
        }
    }
}
