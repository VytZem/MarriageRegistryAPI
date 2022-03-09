using MarriageRegistryAPI.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistryAPI.Persistence.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasKey(p => p.PersonId);

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(p => p.PersonalCode)
                .IsRequired()
                .HasMaxLength(20);
            
        }
    }
}
