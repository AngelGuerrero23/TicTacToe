using TicTacToeApi.shared;
using TicTacToeApi.shared.DTO;

namespace TicTacToe.Wasm.Service;

public interface IPartidasApiService
{
    Task<Resource<List<PartidaResponse>>> GetPartidasAsync();
    Task<Resource<PartidaResponse>> GetPartidaAsync(int partidaId);
    Task<Resource<PartidaResponse>> PostPartida(int jugador1, int jugador2);
}
