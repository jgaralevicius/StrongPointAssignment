using Assignment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.DataAccess
{
    public class CalculationInputConfiguration : IEntityTypeConfiguration<CalculationInput>
    {
        public void Configure(EntityTypeBuilder<CalculationInput> builder)
        {
            builder.ToTable("CalculationInput");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Mass);
            builder.Property(x => x.Velocity);
            builder.Property(x => x.DateCreated);
        }
    }
}
