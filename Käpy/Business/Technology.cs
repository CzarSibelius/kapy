using Käpy.Business.Costs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Käpy.Business
{
    public class Technology
    {
        public string Name { get; set; }

        public IEnumerable<Cost> UnlockRequirements = null;
    }
}
