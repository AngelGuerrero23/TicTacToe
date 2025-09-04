using Microsoft.EntityFrameworkCore;
using TicTacToe.Models;

namespace TicTacToe.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Jugadores> Jugadores { get; set; }
    }
}
