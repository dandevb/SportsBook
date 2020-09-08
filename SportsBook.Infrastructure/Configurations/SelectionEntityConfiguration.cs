using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsBook.Domain.Enum;
using SportsBook.Domain.Model;
using System;

namespace SportsBook.Infrastructure.Configurations
{
    class SelectionEntityConfiguration : IEntityTypeConfiguration<Selection>
    {
        public void Configure(EntityTypeBuilder<Selection> selectionConfiguration)
        {

            selectionConfiguration.HasKey(b => b.Id);

            var converterSelection = new ValueConverter<SelectionOutcome, string>(
                                                            v => v.ToString(),
                                                            v => (SelectionOutcome)Enum.Parse(typeof(SelectionOutcome), v));

            selectionConfiguration
                .Property(e => e.Outcome)
                .HasConversion(converterSelection);

            selectionConfiguration
                .HasOne<Event>(pt => pt.Event)
                .WithMany()
                .HasForeignKey(pt => pt.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            selectionConfiguration
                .HasOne<Market>(pt => pt.Market)
                .WithMany(pt => pt.SelectionList)
                .HasForeignKey(pt => pt.MarketId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
