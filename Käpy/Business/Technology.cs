using Käpy.Business.Costs;
using System.Collections.Generic;

namespace Käpy.Business
{
    public class Technology
    {
        public string Name { get; set; }

        public IEnumerable<Cost> UnlockRequirements = null;

        public IEnumerable<ResourceBoost> ResourceBoosts = null;
    }
}
