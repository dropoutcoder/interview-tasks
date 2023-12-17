using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DropoutCoder.SmartRental.Infrastructure.Database.Internal.Configuration
{
    internal class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder
                .HasBaseType<DbEntity<int>>();

            builder
                .Property(ce => ce.Name)
                .IsRequired();

            builder
                .Property(ce => ce.RegistrationNumber)
                .IsRequired();
        }
    }
}
