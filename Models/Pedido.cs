using System.Globalization;

namespace Restaurante.Models
{
    public enum StatusPedido
    {
        emPreparo,
        Pronto,
        Entregue
    }

    public class Pedido
    {
        public int Id {  get; set; }
        public int Mesa { get; set; }
        public string NomeSolicitante { get; set; }
        

        public string ProdutoId { get; set; } 
        public int Quantidade { get; set; }

        public StatusPedido Status { get; set; } = StatusPedido.emPreparo;
        public DateTime DataHora { get; set; } = DateTime.Now;


    }
}
