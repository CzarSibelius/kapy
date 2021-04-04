using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Käpy.Business
{
    public class Technology
    {
        public string Name { get; set; }

        //public Func<GameState, bool> UnlockFn { get; set; } = NoRequirements();

        public IEnumerable<Cost> UnlockCosts = null;

        //public static Func<GameState, bool> NoRequirements()
        //{
        //    return (GameState) => true;
        //}
    }
}
