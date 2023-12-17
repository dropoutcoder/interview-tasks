using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DropoutCoder.SmartRental.Infrastructure.Database.Internal.Configuration
{
    internal class DbEntityTypeConfiguration<TKey> : IEntityTypeConfiguration<DbEntity<TKey>>
        where TKey : IEquatable<TKey>
    {
        public void Configure(EntityTypeBuilder<DbEntity<TKey>> builder)
        {
            builder
                .HasKey(e => e.Id);
        }
    }
}
