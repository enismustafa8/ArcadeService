using ArcadeService.BL.Interfaces;
using ArcadeService.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ArcadeService.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArcadeMachinesController : ControllerBase
    {
        private readonly IArcadeMachineCrudService _arcadeMachineCrudService;

        public ArcadeMachinesController(
            IArcadeMachineCrudService arcadeMachineCrudService)
        {
            _arcadeMachineCrudService = arcadeMachineCrudService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_arcadeMachineCrudService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _arcadeMachineCrudService.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ArcadeMachine arcadeMachine)
        {
            _arcadeMachineCrudService.Add(arcadeMachine);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _arcadeMachineCrudService.Delete(id);
            return NoContent();
        }
    }
}
