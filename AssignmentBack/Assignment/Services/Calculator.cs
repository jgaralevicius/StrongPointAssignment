namespace Assignment.Services
{
    public class Calculator : ICalculator
    {
        /// <summary>
        /// Given object mass and velocity, calculate kinetic energy using KE=1/2*m*v^2
        /// </summary>
        /// <exception cref="ArgumentException">when mass less than 0</exception>
        public decimal CalculateKineticEnergy(decimal mass, decimal velocity)
        {
            if (mass < 0)
            {
                throw new ArgumentException("Mass must be greater or equal to 0", nameof(mass));
            }

            return mass * velocity * velocity / 2;
        }
    }
}
