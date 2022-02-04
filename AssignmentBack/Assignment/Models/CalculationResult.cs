 namespace Assignment.Models
{
    public class CalculationResult
    {
        public DateTime DateCreated { get; }
        
        public decimal Mass { get; }
        public decimal Velocity { get; }
        public decimal Energy { get; }
        public string Comment { get; }

        public CalculationResult(decimal mass, decimal velocity, decimal energy, string comment, DateTime dateCreated)
        {
            Mass = mass;
            Velocity = velocity;
            DateCreated = dateCreated;

            Energy = energy;
            Comment = comment;
        }
    }
}
