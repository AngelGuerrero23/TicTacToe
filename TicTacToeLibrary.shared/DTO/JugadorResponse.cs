using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeApi.shared.DTO;

public record JugadorResponse(
 int JugadorId,
 string JugadorName,
 int Victorias,
 int Derrotas,
 int Empates,
 string Email
 );