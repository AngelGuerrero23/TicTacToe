using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicTacToe.DAL;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public class PartidasService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Partidas partida)
        {
            if (!await Existe(partida.PartidaId) && partida.Jugador1Id != partida.Jugador2Id)
            {
                return await Insertar(partida);
            } 
            else if (await Existe(partida.PartidaId))
            {
                return await Modificar(partida);
            }
            else
            {
                return false;
            }

        }

        private async Task<bool> Insertar(Partidas partida)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Partidas.Add(partida);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Partidas partida)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(partida);
            return await contexto
                .SaveChangesAsync() > 0;
        }

        public async Task<Partidas?> Buscar(int partidaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Partidas
                .FirstOrDefaultAsync(o=>o.PartidaId == partidaId);
        }

        public async Task<bool> Eliminar(int partidaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Partidas
                .AsNoTracking()
                .Where(j => j.PartidaId == partidaId)
                .ExecuteDeleteAsync()>0;
        }

        public async Task<List<Partidas>> Listar(Expression<Func<Partidas, bool>>expression)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Partidas.Where(expression).AsNoTracking().ToListAsync();
        }
        private async Task<bool> Existe(int partidaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Partidas.AnyAsync(p=>p.PartidaId == partidaId);
        }

    }
}
