using FluentAssertions;
using Käpy.Data;
using Xunit;

namespace Käpy.Test
{
    public class ResourceConfigTest
    {
        [Fact]
        public void ShouldContainOrava()
        {
            ResourceConfig.All.Should().Contain(x => x.Name == "Orava");
        }
    }
}