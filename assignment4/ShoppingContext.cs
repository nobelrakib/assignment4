using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment4
{
    public class ShoppingContext : DbContext
    {
        private string _connectionString;

        public ShoppingContext()
        {
            _connectionString = "Server=.;Database=abc;User Id=rakib;Password =123456; ";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Product>()
            //    .HasMany(p => p.Images)
            //    .WithOne(i => i.Product);

            builder.Entity<studentbook>()
               .HasKey(sb => new { sb.studentId, sb.bookId });

            builder.Entity<studentbook>()
                .HasOne(sb => sb.student)
                .WithMany(sb=> sb.books)
                .HasForeignKey(sb => sb.studentId);

            builder.Entity<studentbook>()
                .HasOne(sb => sb.book)
                .WithMany(sb => sb.books)
                .HasForeignKey(pc => pc.bookId);

            base.OnModelCreating(builder);
        }

        public DbSet<book> Books { get; set; }
        public DbSet<student> Students{ get; set; }
        public DbSet<studentbook> Studentbooks { get; set; }
    }
}
