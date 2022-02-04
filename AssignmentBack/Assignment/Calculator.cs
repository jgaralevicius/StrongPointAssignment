namespace Assignment
{
    public static class Calculator
    {
        public static decimal CalculateKineticEnergy(decimal mass, decimal velocity)
        {
            if (mass < 0)
            {
                throw new ArgumentException("Mass must be greater than 0", nameof(mass));
            }

            return mass * (velocity * velocity) / 2;
        }
    }
}
