using System.Globalization;

namespace Restaurante.Models
{
    public enum StatusPedido
    {
        Preparando,
        Pronto,
        Entregue
    }

    public class Pedido
    {
        public int Id { get; set; }
        public int Mesa { get; set; }
        public string NomeSolicitante { get; set; }

        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public StatusPedido Status { get; set; } = StatusPedido.Preparando;
        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}