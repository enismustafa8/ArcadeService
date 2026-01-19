using ArcadeService.Models.Responses;

namespace ArcadeService.BL.Interfaces
{
    public interface ISellArcadeMachine
    {
        SellCarResult Sell(Guid arcadeMachineId, Guid customerId);
    }
}
