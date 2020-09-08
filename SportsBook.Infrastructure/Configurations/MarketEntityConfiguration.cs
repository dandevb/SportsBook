using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsBook.Domain.Model;

namespace SportsBook.Infrastructure.Configurations
{
    class MarketEntityConfiguration : IEntityTypeConfiguration<Market>
    {
        public void Configure(EntityTypeBuilder<Market> marketConfiguration)
        {

            marketConfiguration.HasKey(b => b.Id);

            marketConfiguration
                .HasOne(pt => pt.Event)
                .WithMany(t => t.MarketList)
                .HasForeignKey(pt => pt.EventForeignKey)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
