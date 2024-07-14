using Microsoft.EntityFrameworkCore;
using PokemonCadastro.Model;

namespace PokemonCadastro.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<PokemonModel> Pokemons { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PokemonOwnerJoin> PokemonOwners { get; set; }
        public DbSet<PokemonCategoryJoin> PokemonCategories { get; set; }
        public DbSet<Country> Country {  get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategoryJoin>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });

            modelBuilder.Entity<PokemonCategoryJoin>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonCategoryJoin>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);           
            
            modelBuilder.Entity<PokemonOwnerJoin>()
                .HasKey(pc => new { pc.PokemonId, pc.OwnerId});

            modelBuilder.Entity<PokemonOwnerJoin>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(c => c.PokemonId);

            modelBuilder.Entity<PokemonOwnerJoin>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
