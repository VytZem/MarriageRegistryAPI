using MarriageRegistryAPI.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Persistence.Config
{
    public class MarriageConfiguration : IEntityTypeConfiguration<Marriage>
    {
        public void Configure(EntityTypeBuilder<Marriage> builder)
        {
            builder
                .HasKey(m => m.MarriageId);

            builder
                .Property(m => m.MarriageDate)
                .IsRequired();

            builder
                .HasMany(m => m.Spouses)
                .WithOne(p => p.Marriage)
                .HasForeignKey(p => p.MarriageId);
        }
    }
}
