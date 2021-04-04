using System;
using System.Collections.Generic;
using System.Linq;

namespace Käpy.Business
{
    public static class Technologies
    {
        [RequiresResource("Käpy", 30)]
        public static string Tikku = "Tikkujen kerääminen";
        public static string Käpylehmä = "Käpylehmän rakentaminen";

        public static IEnumerable<Technology> All
        {
            get => typeof(Technologies)
                    .GetFields()
                    .Where(fi => fi.IsPublic && fi.IsStatic)
                    .Select(fi => new Technology
                    {
                        Name = fi.GetValue(null) as string,
                        UnlockCosts = fi.GetCustomAttributes(false)
                            .Where(a => a is RequiresResourceAttribute)
                            .Cast<RequiresResourceAttribute>()
                            .Select(a => new Cost { Name = a.Name, Amount = a.Amount})
                    });
        }

        public static Func<GameState, bool> Require(string resourceName, int amount)
        {
            return (GameState) => true;
        }
    }
}
