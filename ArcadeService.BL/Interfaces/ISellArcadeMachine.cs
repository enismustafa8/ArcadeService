using ArcadeService.Models.Responses;

namespace ArcadeService.BL.Interfaces
{
    public interface ISellArcadeMachine
    {
        SellArcadeMachineResult Sell(Guid arcadeMachineId, Guid customerId);
    }
}
