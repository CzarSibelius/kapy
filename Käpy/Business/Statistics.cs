using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Business
{
    public class Statistics
    {
        private Dictionary<string, int> resourceStats = Initialize();
        private Dictionary<string, int> previousStats = Initialize();

        public void AddStatistics(string resourceName, int amount)
        {
            resourceStats[resourceName] += amount;
        }

        public void Clear()
        {
            previousStats = resourceStats;
            resourceStats = Initialize();
        }

        public int Get(string resourceName)
        {
            return previousStats[resourceName];
        }

        private static Dictionary<string, int> Initialize()
        {
            return ResourceConfig.All.ToDictionary(x => x.Name, x => 0);
        }
    }
}
