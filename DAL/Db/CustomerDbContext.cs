using System;
using System.Collections.Generic;
using DAL.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DAL.Db
{
    public partial class CustomerDbContext : DbContext
    {
        private readonly IConfiguration? _config;
        private string _environment = String.Empty;
        public CustomerDbContext()
        {
        }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
            _environment = config.GetSection("Environment").Value;
        }

        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString(_environment));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.ToTable("Tbl_Customer");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
