using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicTacToe.DAL;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public class MovimientosService(IDbContextFactory<Contexto>DbFactory)
    {
        public async Task<bool> Guardar(Movimientos movimiento)
        {
            if (!await Existe(movimiento.MovimientoId))
                return await Insertar(movimiento);
            else return false;
        }

        private async Task<bool> Insertar(Movimientos movimiento)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Movimientos.Add(movimiento);
            return await contexto.SaveChangesAsync()>0;
        }

        public async Task<Movimientos?> Buscar(int movimientoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Movimientos
                .FirstOrDefaultAsync(m => m.MovimientoId == movimientoId);
        }

        public async Task<List<Movimientos>>Listar(Expression<Func<Movimientos, bool>> expression)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Movimientos
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> Existe(int movimientoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Movimientos
                .AnyAsync(m => m.MovimientoId == movimientoId);
        }
    }
}
