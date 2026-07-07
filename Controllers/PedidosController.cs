using Microsoft.AspNetCore.Mvc;
using Restaurante.Models;
using System.Linq;

namespace Restaurante.Controllers
{
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
        public IActionResult Cria(Pedido novoPedido)
        {
            if (ModelState.IsValid)
            {
                MockPedidosRepository.AdicionarPedido(novoPedido);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Produtos = MockPedidosRepository.Produtos;
            return View(novoPedido);
        }
    }
}