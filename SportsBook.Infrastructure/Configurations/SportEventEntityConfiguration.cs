using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsBook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBook.Infrastructure.Configurations
{
    class SportEventEntityConfiguration : IEntityTypeConfiguration<SportEvent>
    {
        public void Configure(EntityTypeBuilder<SportEvent> sportEventConfiguration)
        {

            sportEventConfiguration.HasKey(b => new { b.SportId, b.EventId });

            sportEventConfiguration
                .HasOne<Sport>(pt => pt.Sport)
                .WithMany(p => p.SportEventList)
                .HasForeignKey(pt => pt.SportId);

            sportEventConfiguration
                .HasOne<Event>(pt => pt.Event)
                .WithMany(t => t.SportEventList)
                .HasForeignKey(pt => pt.EventId);
        }
    }
}
