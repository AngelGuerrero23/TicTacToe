using Microsoft.EntityFrameworkCore;
using TicTacToe.Models;

namespace TicTacToe.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Jugadores> Jugadores { get; set; }

        public DbSet<Partidas> Partidas { get; set; }

        public DbSet<Movimientos> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Partidas>(entity =>
            {
                entity.HasOne(p => p.Jugador1)
                .WithMany()
                .HasForeignKey(p => p.Jugador1Id)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.Jugador2)
                .WithMany()
                .HasForeignKey(p => p.Jugador2Id)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.Ganador)
                .WithMany()
                .HasForeignKey(p => p.GanadorId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.TurnoJugador)
                .WithMany()
                .HasForeignKey(p => p.TurnoJugadorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Movimientos>(entity =>
            {
                entity.HasOne(m => m.Jugador)
                      .WithMany(j => j.Movimientos)
                      .HasForeignKey(m => m.JugadorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Partida)
                      .WithMany()
                      .HasForeignKey(m => m.PartidaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
