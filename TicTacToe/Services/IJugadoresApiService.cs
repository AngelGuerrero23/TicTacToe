using TicTacToeApi.shared;
using TicTacToeApi.shared.DTO;

namespace TicTacToe.Services;

public interface IJugadoresApiService
{
        Task<Resource<List<JugadorResponse>>> GetJugadoresAsync();
        Task<Resource<JugadorResponse>> GetJugadorAsync(int jugadorId);
        Task<Resource<JugadorResponse>> PostJugador(string nombres, string email);
}
