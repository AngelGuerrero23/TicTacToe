using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApi.shared.DTO;

public record JugadorResponse(
    int jugadorId,
    string Nombres,
    string Email
)
{
    // Backwards-compatible PascalCase aliases used by the UI
    public int JugadorId => jugadorId;
    public string JugadorName => Nombres;
}