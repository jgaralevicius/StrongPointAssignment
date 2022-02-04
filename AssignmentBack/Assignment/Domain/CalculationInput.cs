namespace Assignment.Domain
{
    public class CalculationInput
    {
        public Guid Id { get; private set; }
        public decimal Mass { get; private set; }
        public decimal Velocity { get; private set; }
        public DateTime DateCreated { get; private set; }

        public CalculationInput(decimal mass, decimal velocity)
        {
            Id = Guid.NewGuid();
            Mass = mass;
            Velocity = velocity;
            DateCreated = DateTime.UtcNow;
        }
    }
}
