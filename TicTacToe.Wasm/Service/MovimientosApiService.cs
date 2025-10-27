using System.Net.Http.Json;
using TicTacToeApi.shared;
using TicTacToeApi.shared.DTO;

namespace TicTacToe.Wasm.Service;

public class MovimientosApiService(HttpClient httpClient) : IMovimientosApiService
{
    public async Task<Resource<List<MovimientoResponse>>> GetMovimientosAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<MovimientoResponse>>($"api/Movimientos/{partidaId}");
            return new Resource<List<MovimientoResponse>>.Success(response!);
        }
        catch (Exception ex)
        {  
            return new Resource<List<MovimientoResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<MovimientoResponse>> PostMovimiento(int partidaId, string jugador, int posicionFila, int posicionColumna)
    {
        var request = new MovimientoRequest(partidaId, jugador, posicionFila, posicionColumna);
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Movimientos", request);
            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<MovimientoResponse>();
            return new Resource<MovimientoResponse>.Success(created!);
        }
        catch(HttpRequestException ex)
        {
            return new Resource<MovimientoResponse>.Error($"Error de red:{ex.Message}");
        }
        catch(NotSupportedException)
        {
            return new Resource<MovimientoResponse>.Error("Respuesta inválida del servidor");
        }
    }

}
