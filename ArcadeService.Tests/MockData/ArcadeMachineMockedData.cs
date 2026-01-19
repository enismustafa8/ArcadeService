using ArcadeService.Models.Dto;
using System;
using System.Collections.Generic;

namespace ArcadeService.Tests.MockData
{
    public static class ArcadeMachineMockedData
    {
        public static List<ArcadeMachine> ArcadeMachines = new()
        {
            new ArcadeMachine
            {
                Id = Guid.NewGuid(),
                Model = "Street Fighter II",
                Year = 1991,
                BasePrice = 3000
            }
        };
    }
}
