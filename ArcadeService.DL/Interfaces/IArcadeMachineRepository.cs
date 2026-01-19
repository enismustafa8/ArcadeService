using ArcadeService.Models.Dto;

namespace ArcadeService.DL.Interfaces
{
    public interface IArcadeMachineRepository
    {
        void Add(ArcadeMachine arcadeMachine);
        void Delete(Guid id);
        List<ArcadeMachine> GetAll();
        ArcadeMachine? GetById(Guid id);
    }
}
