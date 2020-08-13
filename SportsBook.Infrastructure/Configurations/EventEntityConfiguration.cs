using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsBook.Domain.Enums;
using SportsBook.Domain.Model;
using System;

namespace SportsBook.Infrastructure.Configurations
{
    class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> eventConfiguration)
        {

            eventConfiguration.HasKey(b => b.Id);

            var converterType = new ValueConverter<EventType, string>(
                                                            v => v.ToString(),
                                                            v => (EventType)Enum.Parse(typeof(EventType), v));
            var converterStatus = new ValueConverter<EventStatusType, string>(
                                                            v => v.ToString(),
                                                            v => (EventStatusType)Enum.Parse(typeof(EventStatusType), v));

            eventConfiguration
                .Property(e => e.EventType)
                .HasConversion(converterType);
            eventConfiguration
                .Property(e => e.Status)
                .HasConversion(converterStatus);

        }
    }
}
