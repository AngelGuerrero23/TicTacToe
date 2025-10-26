using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApi.shared.DTO;

public record MovimientoRequest(
        int PartidaId,
        string Jugador,
        int PosicionFila,
        int PosicionColumna
 );
