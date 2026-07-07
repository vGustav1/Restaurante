using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Models
{
    public static class MockPedidosRepository
    {
        public static List<Produto> Produtos { get; set; } = new List<Produto>();
        public static List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        static MockPedidosRepository()
        {
            Produtos.Add(new Produto { Id = 1, Nome = "Hambúrguer Artesanal", Preco = 29.90m, Tipo = TipoProduto.Prato });
            Produtos.Add(new Produto { Id = 2, Nome = "Batata Frita", Preco = 15.00m, Tipo = TipoProduto.Prato });
            Produtos.Add(new Produto { Id = 3, Nome = "Refrigerante Lata", Preco = 6.00m, Tipo = TipoProduto.Bebida });
            Produtos.Add(new Produto { Id = 4, Nome = "Suco Natural", Preco = 8.50m, Tipo = TipoProduto.Bebida });
        }

        public static void AdicionarPedido(Pedido pedido)
        {
            pedido.Id = Pedidos.Count > 0 ? Pedidos.Max(p => p.Id) + 1 : 1;
            Pedidos.Add(pedido);
        }

        public static List<Pedido> ObterTodosOsPedidos()
        {
            return Pedidos;
        }
    }
}