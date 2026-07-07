namespace Restaurante.Models
{
    public enum TipoProduto
    {
        Prato,
        Bebida

    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public TipoProduto Tipo { get; set; }
    }
}
