using EmailSelect.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSelect.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SelectionAssociation>()
            .HasMany(r => r.RuleSelections)
            .WithOne(s => s.SelectionAssociation!)
            .HasForeignKey(r => r.AssociationId);

            modelBuilder
            .Entity<RuleSelection>()
            .HasOne(s => s.SelectionAssociation)
            .WithMany(r => r.RuleSelections)
            .HasForeignKey(r => r.AssociationId);
        }

        public DbSet<RuleSelection> RuleSelections { get; set; }
        public DbSet<SelectionAssociation> SelectionAssociations { get; set; }
    }
}