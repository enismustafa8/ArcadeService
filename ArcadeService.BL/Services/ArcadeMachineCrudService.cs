using ArcadeService.BL.Interfaces;
using ArcadeService.DL.Interfaces;
using ArcadeService.Models.Dto;

namespace ArcadeService.BL.Services
{
    public class ArcadeMachineCrudService : IArcadeMachineCrudService
    {
        private readonly IArcadeMachineRepository _arcadeMachineRepository;

        public ArcadeMachineCrudService(
            IArcadeMachineRepository arcadeMachineRepository)
        {
            _arcadeMachineRepository = arcadeMachineRepository;
        }

        public void Add(ArcadeMachine arcadeMachine)
        {
            if (arcadeMachine == null) return;

            if (arcadeMachine.Id == Guid.Empty)
            {
                arcadeMachine.Id = Guid.NewGuid();
            }

            _arcadeMachineRepository.Add(arcadeMachine);
        }

        public void Delete(Guid id)
        {
            _arcadeMachineRepository.Delete(id);
        }

        public List<ArcadeMachine> GetAll()
        {
            return _arcadeMachineRepository.GetAll();
        }

        public ArcadeMachine? GetById(Guid id)
        {
            return _arcadeMachineRepository.GetById(id);
        }
    }
}
