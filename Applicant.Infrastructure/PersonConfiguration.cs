
using Applicant.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Applicant.Infrastructure
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(a => a.Id)
            .UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
            .IsRequired(true)
            .HasMaxLength(100);

            builder.Property(a => a.FamilyName)
            .IsRequired(true)
            .HasMaxLength(100);

            builder.Property(a => a.Address)
            .IsRequired(true)
            .HasMaxLength(100);

            builder.Property(a => a.CountryOfOrigin)
            .IsRequired(true)
            .HasMaxLength(100);

            builder.Property(a => a.EMailAdress)
            .IsRequired(true)
            .HasMaxLength(100);

            builder.Property(a => a.Age)
            .IsRequired(true);
        }
    }
}
