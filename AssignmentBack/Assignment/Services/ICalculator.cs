namespace Assignment.Services
{
    public interface ICalculator
    {
        /// <summary>
        /// Given object mass and velocity, calculate kinetic energy
        /// </summary>
        /// <param name="mass">Object mass (kg)</param>
        /// <param name="velocity">Object velocity (m/s)</param>
        /// <returns>Energy (J)</returns>
        public decimal CalculateKineticEnergy(decimal mass, decimal velocity);
    }
}
