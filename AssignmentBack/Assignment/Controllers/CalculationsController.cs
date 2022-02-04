using Assignment.DataAccess;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("/api/calculations")]
    public class CalculationsController : ControllerBase
    {
        DatabaseContext _dbContext;

        public CalculationsController(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CalculationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Calculate([FromBody]CalculationRequest request, CancellationToken ct)
        {
            try
            {
                var entity = new Domain.CalculationInput(request.Mass, request.Velocity);
                
                _dbContext.CalculationInputs.Add(entity);

                var result = new CalculationResult(entity.Mass, entity.Velocity, entity.DateCreated);
                
                await _dbContext.SaveChangesAsync(ct);

                return Ok(result);
            }
            catch (ArgumentException exc)
            {
                return BadRequest(new { Error = exc.Message });
            }
            catch (OverflowException)
            {
                return BadRequest(new { Error = "Inputs too large" });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CalculationResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPreviousResults(CancellationToken ct)
        {
            var inputs = await _dbContext.CalculationInputs
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync(ct);

            var results = inputs.Select(x => new CalculationResult(
                    x.Mass,
                    x.Velocity,
                    x.DateCreated));
                
            return Ok(results);
        }
    }
}