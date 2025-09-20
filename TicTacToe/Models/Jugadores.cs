using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Victorias { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Las partidas deben ser  0 o mayor")]
        public int Derrotas { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Las partidas deben ser  0 o mayor")]
        public int Empates { get; set; }

        [InverseProperty(nameof(Models.Movimientos.Jugador))]
        public virtual ICollection<Movimientos> Movimientos { get; set; } = new List<Movimientos>();
    }   
}
