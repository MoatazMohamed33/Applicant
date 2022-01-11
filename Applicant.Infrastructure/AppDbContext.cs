
using Applicant.Core.Common;
using Applicant.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("data source=.;Initial Catalog = ApplicantDB; Integrated Security = True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var persons = new Person[]
           {
                new Person{Id=1, Name="moataz",Age=20,Address="asss",CountryOfOrigin="egypt",EMailAdress="asss@fdgd.com",FamilyName="ddd",Hired=true}
           };
            modelBuilder.Entity<Person>().HasData(persons);


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetDates();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            SetDates();
            return await base.SaveChangesAsync();
        }

        private void SetDates()
        {
            ChangeTracker.DetectChanges();
            var added = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in added)
            {
                if (entity is AuditableEntity<int> track)
                {
                    track.Created = DateTime.Now;
                }

            }

            var modified = ChangeTracker.Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToArray();

            foreach (var entity in modified)
            {
                if (entity is AuditableEntity<int> track)
                {
                    track.LastModified = DateTime.Now;
                }
            }
        }
    }
}
