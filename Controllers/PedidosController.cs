using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Models;
using System.Linq;

namespace Restaurante.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        
        public IActionResult Index()
        {
            var pedidos = MockPedidosRepository.ObterTodosOsPedidos();
            return View(pedidos);
        }

        
        public IActionResult Criar()
        {
            ViewBag.Produtos = MockPedidosRepository.Produtos;
            return View();
        }

        
        [HttpPost]
        public IActionResult Criar(string nomeSolicitante, int mesa, int? pratoId, int? qtdPrato, int? bebidaId, int? qtdBebida)
        {
            if (pratoId == null && bebidaId == null)
            {
                ModelState.AddModelError("", "Você precisa selecionar pelo menos um prato ou uma bebida.");
                ViewBag.Produtos = MockPedidosRepository.Produtos;
                return View();
            }

            if (pratoId != null)
            {
                var pedidoPrato = new Pedido
                {
                    NomeSolicitante = nomeSolicitante,
                    Mesa = mesa,
                    ProdutoId = pratoId.Value,
                    Quantidade = qtdPrato ?? 1,
                    Status = StatusPedido.Preparando
                };
                MockPedidosRepository.AdicionarPedido(pedidoPrato);
            }

            if (bebidaId != null)
            {
                var pedidoBebida = new Pedido
                {
                    NomeSolicitante = nomeSolicitante,
                    Mesa = mesa,
                    ProdutoId = bebidaId.Value,
                    Quantidade = qtdBebida ?? 1,
                    Status = StatusPedido.Preparando
                };
                MockPedidosRepository.AdicionarPedido(pedidoBebida);
            }

            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Cozinha()
        {
            var pedidos = MockPedidosRepository.ObterTodosOsPedidos()
                .Where(p => MockPedidosRepository.Produtos
                    .First(prod => prod.Id == p.ProdutoId).Tipo == TipoProduto.Prato)
                .ToList();

            return View(pedidos);
        }

       
        public IActionResult Copa()
        {
            var pedidos = MockPedidosRepository.ObterTodosOsPedidos()
                .Where(p => MockPedidosRepository.Produtos
                    .First(prod => prod.Id == p.ProdutoId).Tipo == TipoProduto.Bebida)
                .ToList();

            return View(pedidos);
        }

        
        public IActionResult Historico()
        {
            var pedidos = MockPedidosRepository.ObterTodosOsPedidos()
                .Where(p => p.Status == StatusPedido.Entregue)
                .ToList();

            return View(pedidos);
        }

        
        [HttpPost]
        public IActionResult AtualizarStatus(int id, string origem)
        {
            var pedido = MockPedidosRepository.Pedidos.FirstOrDefault(p => p.Id == id);

            if (pedido != null)
            {
                if (pedido.Status == StatusPedido.Preparando)
                {
                    pedido.Status = StatusPedido.Pronto;
                }
                else if (pedido.Status == StatusPedido.Pronto)
                {
                    pedido.Status = StatusPedido.Entregue;
                }
            }

            return RedirectToAction(origem);
        }
    }
}