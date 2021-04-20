using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RequiresTechnologyAttribute : Attribute
    {
        public string Name { get; }

        public RequiresTechnologyAttribute(string name)
        {
            Name = name;
        }
    }
}
