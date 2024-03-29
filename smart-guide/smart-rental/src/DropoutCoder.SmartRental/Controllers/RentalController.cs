﻿using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Operations.Abstraction;
using DropoutCoder.SmartRental.Operations.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DropoutCoder.SmartRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        public RentalController(ILogger<RentalController> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ILogger<RentalController> Logger { get; }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRental command, [FromServices] IHandler<CreateRental, IRental> handler)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await handler.ExecuteAsync(command);

            return Created($"api/customer/{result.Id}", result);
        }

        [HttpPatch("cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] CancelRental command, [FromServices] IHandler<CancelRental, bool> handler)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await handler.ExecuteAsync(command);

            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> ListAsync([FromServices] IQueryable<IRental> rentals)
        {
            var result = await rentals.ToListAsync();

            return Ok(result);
        }
    }
}
