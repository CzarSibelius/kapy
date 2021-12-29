using FluentAssertions;
using Käpy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Käpy.Test
{
    public class GameStateTest
    {
        [Fact]
        public void Orava()
        {
            var gameState = new GameState();
            gameState.ResearchedTechnologies.Add(new Technology { Name = "Oravien kesyttäminen" });

            gameState.UnlockedResources.Should().Contain(x => x.Name == "Orava");
        }
    }
}
