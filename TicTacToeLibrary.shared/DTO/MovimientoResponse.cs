using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApi.shared.DTO;

public record MovimientoResponse(
    int PartidaId,
    int JugadorId,
    int PosicionFila,
    int PosicionColumna
);
