using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RSS.Data.Mapping;
using RSS.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RSS.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<RssFeed> RSSFeeds { get; set; }
        public DbSet<URL> URLS { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
           

            new URLMap(modelBuilder.Entity<URL>());
            new RssFeedMap(modelBuilder.Entity<RssFeed>());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreRSS1;Trusted_Connection=True;");
          
        }

    }
}
