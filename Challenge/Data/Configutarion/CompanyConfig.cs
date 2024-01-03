using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Data.Configutarion
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        }
    }
}
