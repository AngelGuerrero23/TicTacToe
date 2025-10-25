using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicTacToe.DAL;
using TicTacToe.Models;


namespace TicTacToe.Services
{
    public class JugadoresService(IDbContextFactory<Contexto> DbFactory)
    {

        public async Task<bool> Guardar(Jugadores jugador)
        {
            if (jugador.Victorias <= 0)
            {
                jugador.Victorias = 0;
            }
            if (!await Existe(jugador.JugadorId) && !await ExisteNombre(jugador.JugadorName.ToLower())) return await Insertar(jugador);
            else if (await Existe(jugador.JugadorId) && !await ExisteNombre(jugador.JugadorName.ToLower(), jugador.JugadorId)) return await Modificar(jugador);
            else return false;

        }

        private async Task<bool> Insertar(Jugadores jugador)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Jugadores.Add(jugador);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Jugadores jugador)
        {
            if (jugador.Victorias <= 0)
            {
                jugador.Victorias = 0;
            }
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(jugador);
            return await contexto
                .SaveChangesAsync() > 0;
        }

        public async Task<Jugadores?> Buscar(int jugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .FirstOrDefaultAsync(o => o.JugadorId == jugadorId);
        }

        public async Task<bool> Eliminar(int jugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .AsNoTracking()
                .Where(j => j.JugadorId == jugadorId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Jugadores>> Listar(Expression<Func<Jugadores, bool>> expression)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores.Where(expression).AsNoTracking().ToListAsync();
        }

        private async Task<bool> Existe(int jugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .AnyAsync(j => j.JugadorId == jugadorId);
        }

        private async Task<bool> ExisteNombre(string jugadorName)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .AnyAsync(j => j.JugadorName.ToLower() == jugadorName.ToLower());
        }

        private async Task<bool> ExisteNombre(string jugadorName, int jugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .Where(j => j.JugadorId != jugadorId)
                .AnyAsync(j => j.JugadorName.ToLower() == jugadorName.ToLower());
        }


    }
}