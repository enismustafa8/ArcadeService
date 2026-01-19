using ArcadeService.BL.Interfaces;
using ArcadeService.DL.Interfaces;
using ArcadeService.Models.Dto;
using ArcadeService.Models.Responses;

namespace ArcadeService.BL.Services
{
    public class SellArcadeMachine : ISellArcadeMachine
    {
        private readonly IArcadeMachineCrudService _arcadeMachineCrudService;
        private readonly ICustomerRepository _customerRepository;

        public SellArcadeMachine(
            IArcadeMachineCrudService arcadeMachineCrudService,
            ICustomerRepository customerRepository)
        {
            _arcadeMachineCrudService = arcadeMachineCrudService;
            _customerRepository = customerRepository;
        }

        public SellCarResult Sell(Guid arcadeMachineId, Guid customerId)
        {
            var arcadeMachine = _arcadeMachineCrudService.GetById(arcadeMachineId);
            var customer = _customerRepository.GetById(customerId);

            if (arcadeMachine == null || customer == null)
            {
                throw new ArgumentException(
                    $"ArcadeMachine with ID {arcadeMachineId} or Customer with ID {customerId} not found.");
            }

            var price = arcadeMachine.BasePrice - customer.Discount;

            return new SellCarResult
            {
                Price = price,
                ArcadeMachine = arcadeMachine,
                Customer = customer
            };
        }
    }
}
