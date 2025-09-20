namespace TicTacToe.Models
{
    public static class EstadosPartida
    {

        public const string EnEspera = "En espera";
        public const string EnProgreso = "En progreso";
        public const string Finalizada = "Finalizada";
        public const string Empate = "Empate";

        public static readonly List<String> Todos = new()
    {
        EnEspera,
        EnProgreso,
        Finalizada,
        Empate
    };

    }
}
    
