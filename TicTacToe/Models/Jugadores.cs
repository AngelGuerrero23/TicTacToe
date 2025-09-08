using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Models
{
    public class Jugadores
    {
        [Key]

        [Required(ErrorMessage = "Este campo es requerido")]
        public int JugadorId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]

        public string JugadorName { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage="Las partidas deben ser  0 o mayor")]
        public int partida { get; set; }

       
    }   
}
