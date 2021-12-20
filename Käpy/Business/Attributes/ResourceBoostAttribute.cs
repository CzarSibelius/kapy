using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Käpy.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ResourceBoostAttribute : Attribute
    {
        public string ResourceName { get; }
        public ResourceBoostType BoostType { get; }
        public int Amount { get; }

        public ResourceBoostAttribute(string resourceName, ResourceBoostType boostType, int amount )
        {
            ResourceName = resourceName;
            BoostType = boostType;
            Amount = amount;
        }

    }

    public enum ResourceBoostType
    {
        AddConstant = 1
    }
}
