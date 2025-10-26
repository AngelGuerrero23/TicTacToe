using TicTacToeApi.shared;
using TicTacToeApi.shared.DTO;

namespace TicTacToe.Services;

public interface IMovimientosApiService
{
    Task<Resource<List<MovimientoResponse>>> GetMovimientosAsync(int partidaId);
    Task<Resource<MovimientoResponse>> PostMovimiento(int movimientoId, string jugador, int posicionFila, int posicionColumna);
}
