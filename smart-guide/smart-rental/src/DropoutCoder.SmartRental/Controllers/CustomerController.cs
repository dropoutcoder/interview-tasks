﻿using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Operations.Abstraction;
using DropoutCoder.SmartRental.Operations.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DropoutCoder.SmartRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController(ILogger<CustomerController> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ILogger<CustomerController> Logger { get; }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomer command, [FromServices] IHandler<CreateCustomer, ICustomer> handler)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await handler.ExecuteAsync(command);

            return Created($"api/customer/{result.Id}", result);
        }

        [HttpGet()]
        public async Task<IActionResult> ListAsync([FromServices] IQueryable<ICustomer> customers)
        {
            var result = await customers.ToListAsync();

            return Ok(result);
        }
    }
}
