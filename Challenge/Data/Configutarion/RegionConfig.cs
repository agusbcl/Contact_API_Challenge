using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Data.Configutarion
{
    public class RegionConfig : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.HasData(
                new Region
                {
                    Id = 1,
                    Name = "Buenos Aires",
                },
                new Region
                {
                    Id = 2,
                    Name = "Cordoba",
                },
                new Region
                {
                    Id = 3,
                    Name = "Ciudad Autónoma de Buenos Aires",
                },
                new Region
                {
                    Id = 4,
                    Name = "Catamarca",
                },
                new Region
                {
                    Id = 5,
                    Name = "Chaco",
                },
                new Region
                {
                    Id = 6,
                    Name = "Chubut",
                },
                new Region
                {
                    Id = 7,
                    Name = "Entre Rios",
                },
                new Region
                {
                    Id = 8,
                    Name = "Corrientes",
                },
                new Region
                {
                    Id = 9,
                    Name = "Formosa",
                },
                new Region
                {
                    Id = 10,
                    Name = "Jujuy",
                },
                new Region
                {
                    Id = 11,
                    Name = "La Pampa",
                },
                new Region
                {
                    Id = 12,
                    Name = "La Rioja",
                },
                new Region
                {
                    Id = 13,
                    Name = "Mendoza",
                });
        }
    }
}
