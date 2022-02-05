using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ARTech.Shared.Domain;

namespace ARTech.Server.Configurations.Entities
{
    public class LogisticSeedConfiguration : IEntityTypeConfiguration<Logistic>
    {
        public void Configure(EntityTypeBuilder<Logistic> builder)
        {
            builder.HasData(
            new Logistic
            {
                LogisticId = 1,
                Name = "Ry",
                Address = "36 Chai Chee Avenue",
                Contact = "87515879"
            }
);
        }
    }
}
