using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RequiresResourceAttribute : Attribute
    {
        public string Name { get; }
        public int Amount { get; set; }

        public RequiresResourceAttribute(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
