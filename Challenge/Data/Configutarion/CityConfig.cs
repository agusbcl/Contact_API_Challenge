using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Data.Configutarion
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        }
    }
}
