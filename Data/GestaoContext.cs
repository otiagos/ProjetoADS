using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestao.Models;

namespace Gestao.Data
{
    public class GestaoContext : DbContext
    {
        public GestaoContext (DbContextOptions<GestaoContext> options)
            : base(options)
        {
        }

        public DbSet<Gestao.Models.Gato> Gato { get; set; } = default!;
        public DbSet<Gestao.Models.Tutor> Tutor { get; set; } = default!;
        public DbSet<Gestao.Models.Raca> Raca { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gato>()
                .HasOne(g => g.Raca)
                .WithMany()
                .HasForeignKey(g => g.IdRaca)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Tutor)
                .WithMany(t => t.Animais)
                .HasForeignKey(a => a.IdTutor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tutor>()
                .HasIndex(p => p.CpfTutor)
                .IsUnique();
        }
    }
}
