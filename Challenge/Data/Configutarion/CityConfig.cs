using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Data.Configutarion
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.HasData(
                new City
                {
                    Id = 1,
                    Name = "Ramos Mejia",
                    RegionId = 1
                },
                new City
                {
                    Id = 2,
                    Name = "La Plata",
                    RegionId = 1
                },
                new City
                {
                    Id = 3,
                    Name = "Tigre",
                    RegionId = 1
                },
                new City
                {
                    Id = 4,
                    Name = "Merlo",
                    RegionId = 1
                },
                new City
                {
                    Id = 5,
                    Name = "Cosquin",
                    RegionId = 2
                },
                new City
                {
                    Id = 6,
                    Name = "Villa General Belgrano",
                    RegionId = 2
                },
                new City
                {
                    Id = 7,
                    Name = "Mina Clavero",
                    RegionId = 2
                },
                new City
                {
                    Id = 8,
                    Name = "San Martin De Los Andes",
                    RegionId = 3
                },
                new City
                {
                    Id = 9,
                    Name = "Villa La Angostura",
                    RegionId = 3
                },
                new City
                {
                    Id = 10,
                    Name = "Centenario",
                    RegionId = 3
                },
                new City
                {
                    Id = 11,
                    Name = "Potrerillos",
                    RegionId = 13
                }
            );
        }
    }
}
