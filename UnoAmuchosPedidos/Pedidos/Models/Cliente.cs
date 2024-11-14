namespace Pedidos.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }

        public string Telefono { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
