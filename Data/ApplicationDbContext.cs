using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des relations
            modelBuilder.Entity<Cours>()
                .HasOne(c => c.Enseignant)
                .WithMany(e => e.Cours)
                .HasForeignKey(c => c.EnseignantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Etudiant)
                .WithMany(e => e.Inscriptions)
                .HasForeignKey(i => i.EtudiantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Cours)
                .WithMany(c => c.Inscriptions)
                .HasForeignKey(i => i.CoursId)
                .OnDelete(DeleteBehavior.Cascade);

            // Pour injecter les données avec une migration
            SeedData.Initialize(modelBuilder);
        }
    }
}
