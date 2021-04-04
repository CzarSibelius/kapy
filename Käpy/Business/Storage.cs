using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Business
{
    public class Storage
    {
        private readonly Dictionary<string, Resource> resourceDictionary = new Dictionary<string, Resource>();

        public Storage()
        {
            Resource.All.ToList().ForEach(r => resourceDictionary.Add(r.Name, r));
        }

        public void Add(string resource, int amount)
        {
            resourceDictionary[resource].Amount += amount;
        }

        public Dictionary<string, Resource> All
        {
            get => resourceDictionary;
        }
    }
}
