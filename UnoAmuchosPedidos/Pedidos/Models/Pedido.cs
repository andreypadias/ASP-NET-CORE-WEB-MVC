using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        [StringLength(80)]
        public string Descripcion { get; set; }

        public DateTime FechaPedido { get; set; }

        public decimal Total { get; set; }

        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}
