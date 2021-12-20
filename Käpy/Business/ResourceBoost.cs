using Käpy.Business.Attributes;

namespace Käpy.Business
{
    public class ResourceBoost
    {
        public string Name { get; set; }
        public string ResourceName { get; set; }
        public ResourceBoostType BoostType { get; set; }
        public int Amount { get; set; }
    }
}
