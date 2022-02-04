using Assignment.DataAccess;
using Assignment.Models;
using Assignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("/api/calculations")]
    public class CalculationsController : ControllerBase
    {
        DatabaseContext _dbContext;
        ICommentsMapper _commentsMapper;
        ICalculator _calculator;

        public CalculationsController(DatabaseContext databaseContext, ICommentsMapper commentsMapper, ICalculator calculator)
        {
            _dbContext = databaseContext;
            _commentsMapper = commentsMapper;
            _calculator = calculator;
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

                var energy = _calculator.CalculateKineticEnergy(entity.Mass, entity.Velocity);
                var comment = _commentsMapper.GetComment(energy);
                var result = new CalculationResult(entity.Mass, entity.Velocity, energy, comment, entity.DateCreated);
                
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
        [ProducesResponseType(typeof(IEnumerable<CalculationResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPreviousResults(CancellationToken ct)
        {
            var inputs = await _dbContext.CalculationInputs
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync(ct);

            var results = inputs
                .Select(x => new
                {
                    x.Mass,
                    x.Velocity,
                    Energy = _calculator.CalculateKineticEnergy(x.Mass, x.Velocity),
                    x.DateCreated
                })
                .Select(x => new CalculationResult(x.Mass, x.Velocity, x.Energy, _commentsMapper.GetComment(x.Energy), x.DateCreated));
                
            return Ok(results);
        }
    }
}