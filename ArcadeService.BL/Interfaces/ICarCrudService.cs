using ArcadeService.Models.Dto;

namespace ArcadeService.BL.Interfaces
{
    public interface IArcadeMachineCrudService
    {
        void Add(ArcadeMachine arcadeMachine);

        void Delete(Guid id);

        List<ArcadeMachine> GetAll();

        ArcadeMachine? GetById(Guid id);
    }
}
