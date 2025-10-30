using TicTacToe.DTO;


namespace TicTacToe.Services;

public class JugadoresApiService(HttpClient httpClient) : IJugadoresApiService
{
    public async Task<Resource<JugadorResponse>> GetJugadorAsync(int jugadorId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<JugadorResponse>($"api/Jugadores/{jugadorId}");
            return new Resource<JugadorResponse>.Success( response!);
        }
        catch (Exception ex)
        {
            return new Resource<JugadorResponse>.Error(ex.Message);
        }
    }

    public async Task<Resource<List<JugadorResponse>>> GetJugadoresAsync()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<JugadorResponse>>("api/Jugadores");
            return new Resource<List<JugadorResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<JugadorResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<JugadorResponse>> PostJugador(string nombres, string email)
    {
        var request = new JugadorRequest(nombres, email);
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/Jugadores", request);
            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<JugadorResponse>();
            return new Resource<JugadorResponse>.Success(created!);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<JugadorResponse>.Error($"Error de red:{ex.Message}");
        }
        catch(NotSupportedException)
        {
            return new Resource<JugadorResponse>.Error("Respueta inválida del servidor.");
        }
    }

    public async Task<Resource<JugadorResponse>> UpdateJugadorAsync(int id, JugadorRequest request)
    {
        var response = await httpClient.PutAsJsonAsync($"api/Jugadores/{id}", request);
        response.EnsureSuccessStatusCode();
        var updated = await response.Content.ReadFromJsonAsync<JugadorResponse>();
        return new Resource<JugadorResponse>.Success(updated!);
    }

    public async Task<Resource<JugadorResponse>> PutJugador(int JugadorId, string nombre, string email)
    {
        var request = new JugadorRequest(nombre, email);
        try
        {
            var response = await httpClient.PutAsJsonAsync($"api/Jugadores/{JugadorId}", request);
            response.EnsureSuccessStatusCode();
            return new Resource<JugadorResponse>.Success(null!);
        }
        catch (HttpRequestException ex)
        {
            return new Resource<JugadorResponse>.Error($"Error de red: {ex.Message}");
        }
        catch (NotSupportedException)
        {
            return new Resource<JugadorResponse>.Error("Respuesta inválida del servidor.");
        }
    }
}
