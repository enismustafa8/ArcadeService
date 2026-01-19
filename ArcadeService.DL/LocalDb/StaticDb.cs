using ArcadeService.Models.Dto;

namespace ArcadeService.DL.LocalDb
{
    internal static class StaticDb
    {
        public static List<ArcadeMachine> ArcadeMachines = new List<ArcadeMachine>
        {
            new ArcadeMachine
            {
                Id = Guid.NewGuid(),
                Model = "Pac-Man Cabinet",
                Year = 1985,
                BasePrice = 2500
            },
            new ArcadeMachine
            {
                Id = Guid.NewGuid(),
                Model = "Street Fighter II",
                Year = 1992,
                BasePrice = 3200
            },
            new ArcadeMachine
            {
                Id = Guid.NewGuid(),
                Model = "Mortal Kombat",
                Year = 1993,
                BasePrice = 3000
            }
        };

        public static List<Customer> Customers = new()
        {
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Email = "jd@xxx.com"
            },
            new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Stamat Genov",
                Email = "sg@xxx.com"
            }
        };
    }
}
