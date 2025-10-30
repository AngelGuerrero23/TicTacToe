using TicTacToe.DTO;
namespace TicTacToe.Services;

public interface IJugadoresApiService
{
        Task<Resource<List<JugadorResponse>>> GetJugadoresAsync();
        Task<Resource<JugadorResponse>> GetJugadorAsync(int jugadorId);
        Task<Resource<JugadorResponse>> PostJugador(string nombres, string email);
        Task<Resource<JugadorResponse>> PutJugador(int JugadorId, string nombre, string email);
}
