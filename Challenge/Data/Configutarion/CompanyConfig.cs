using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Data.Configutarion
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.HasData(
                new Company
                {
                    Id = 1,
                    Name = "Marshall",
                },
                new Company
                {
                    Id = 2,
                    Name = "Accenture",
                },
                new Company
                {
                    Id = 3,
                    Name = "Logitech",
                },
                new Company
                {
                    Id = 4,
                    Name = "ASUS"
                });
        }
    }
}
