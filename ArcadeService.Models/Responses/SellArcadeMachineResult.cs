using ArcadeService.Models.Dto;

namespace ArcadeService.Models.Responses
{
    public class SellArcadeMachineResult
    {
        public ArcadeMachine ArcadeMachine { get; set; }

        public Customer Customer { get; set; }

        public decimal Price { get; set; }
    }
}
