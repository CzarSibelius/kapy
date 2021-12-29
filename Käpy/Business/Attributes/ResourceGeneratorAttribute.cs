using System;

namespace Käpy.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ResourceGeneratorAttribute : Attribute
    {
        public string ResourceName { get; }
        public int Amount { get; }
        public int TickAmount { get; }

        public ResourceGeneratorAttribute(string resourceName, int amount, int tickAmount)
        {
            ResourceName = resourceName;
            Amount = amount;
            TickAmount = tickAmount;
        }


    }
}
