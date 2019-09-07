using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FactsAboutNumbers.Classes;

namespace FactsAboutNumbers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<NumberFact> NumberFacts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NumberFact>(entity => {
                entity.Property<int>("Number");

                entity.Property<string>("Fact");
            });

            base.OnModelCreating(builder);
        }
    }
}
