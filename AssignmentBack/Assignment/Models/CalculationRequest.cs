using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class CalculationRequest
    {
        [Range(0, double.PositiveInfinity)]
        public decimal Mass { get; set; }
        
        [Range(double.NegativeInfinity, double.PositiveInfinity)]
        public decimal Velocity { get; set; }
    }
}
