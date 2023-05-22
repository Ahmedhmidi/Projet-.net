using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;
using System.ComponentModel;
using System.Security.Cryptography;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemenCategory> PokemenCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemenCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PokemenCategory>()
                 .HasOne(p => p.Pokemon)
                 .WithMany(pc => pc.pokemenCategories)
                 .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemenCategory>()
               .HasOne(c => c.Category)
               .WithMany(pc => pc.PokemenCategories)
               .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                 .HasOne(p => p.Pokemon)
                 .WithMany(po => po.PokemonOwners)
                 .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
               .HasOne(o => o.Owner)
               .WithMany(po => po.PokemonOwners)
               .HasForeignKey(o => o.OwnerId);
        }
    }
}
        
