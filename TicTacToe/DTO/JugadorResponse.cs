using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.DTO;

public record JugadorResponse(
    int jugadorId,
    string Nombres,
    string Email
);
