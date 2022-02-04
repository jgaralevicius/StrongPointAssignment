using Assignment.Domain;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CalculationInput> CalculationInputs { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CalculationInputConfiguration());
        }
    }
}
