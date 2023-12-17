using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Operations.Abstraction;
using DropoutCoder.SmartRental.Operations.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DropoutCoder.SmartRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarController(ILogger<CarController> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ILogger<CarController> Logger { get; }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCar command, [FromServices] IHandler<CreateCar, ICar> handler)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await handler.ExecuteAsync(command);

            return Created($"api/car/{result.Id}", result);
        }

        [HttpGet()]
        public async Task<IEnumerable<ICar>> ListAsync([FromServices] IQueryable<ICar> cars)
        {
            var result = await cars.ToListAsync();

            return result;
        }
    }
}
