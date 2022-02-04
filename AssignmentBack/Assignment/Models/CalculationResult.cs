 namespace Assignment.Models
{
    public class CalculationResult
    {
        public DateTime DateCreated { get; }
        
        public decimal Mass { get; }
        public decimal Velocity { get; }
        public decimal Energy { get; }
        public string Comment { get; }

        public CalculationResult(decimal mass, decimal velocity, DateTime dateCreated)
        {
            Mass = mass;
            Velocity = velocity;
            DateCreated = dateCreated;

            Energy = Calculator.CalculateKineticEnergy(mass, velocity);
            Comment = CommentsMapper.GetComment(Energy);
        }
    }
}
