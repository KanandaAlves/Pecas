using Microsoft.AspNetCore.Mvc;
using Pecas.Models;

namespace Pecas.Controllers
{
    public class FornecedorController : Controller
    {
        private static IList<Fornecedor> Fornecedores = new List<Fornecedor>()
        {
            new Fornecedor()
            {
                FornecedorId = 1,
                Nome = "Nakata",
                CNPJ = "12345678958",
                ProdFornecido = "Ponteira",
            },

            new Fornecedor()
            {
                FornecedorId = 2,
                Nome = "Perfect",
                CNPJ = "123456782548",
                ProdFornecido = "Pivo"
            }
        };
        public IActionResult Index()
        {
            return View(Fornecedores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Fornecedor fornecedor)
        {
            fornecedor.FornecedorId = Fornecedores.Select(x => x.FornecedorId).Max() + 1;
            Fornecedores.Add(fornecedor);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(Fornecedores.Where(fornecedor => fornecedor.FornecedorId == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Fornecedor fornecedor)
        {
            var fornecedorOld = Fornecedores.Where(fornecedor => fornecedor.FornecedorId == fornecedor.FornecedorId).First();
            Fornecedores.Remove(fornecedorOld);
            Fornecedores.Add(fornecedor);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(Fornecedores.Where(fornecedor => fornecedor.FornecedorId == id).First());
        }
        public IActionResult Delete(int id)
        {
            return View(Fornecedores.Where(fornecedor => fornecedor.FornecedorId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Fornecedor fornecedor)
        {
            Fornecedores.Remove(Fornecedores.Where(x => x.FornecedorId == fornecedor.FornecedorId).First());
            return RedirectToAction("Index");
        }
    }
}
