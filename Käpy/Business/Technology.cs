using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Business
{
    public class Technology
    {
        public string Name { get; set; }
    }

    public static class Technologies
    {
        public static string Käpylehmä = "Käpylehmän rakentaminen";

        public static IEnumerable<Technology> All
        {
            get => typeof(Technologies)
                    .GetFields()
                    .Where(fi => fi.IsPublic && fi.IsStatic)
                    .Select(fi => fi.GetValue(null) as string)
                    .Select(name => new Technology { Name = name });
        }
    }
}
