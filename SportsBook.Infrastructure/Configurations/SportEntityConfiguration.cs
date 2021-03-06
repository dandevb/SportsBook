﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsBook.Domain.Model;

namespace SportsBook.Infrastructure.Configurations
{
    class SportEntityConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> sportConfiguration)
        {

            sportConfiguration.HasKey(b => b.Id);
            sportConfiguration.Property(b => b.Name);
        }
    }
}
