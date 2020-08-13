using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsBook.Domain.Enums;
using SportsBook.Domain.Model;
using System;

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
                .HasForeignKey(pt => pt.EventForeignKey);
        }
    }
}
