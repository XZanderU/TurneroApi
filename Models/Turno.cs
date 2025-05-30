namespace TurneroApi.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string? NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string? Estado { get; set; } // Ejemplo: "Pendiente", "Confirmado", "Cancelado"
    }
}
