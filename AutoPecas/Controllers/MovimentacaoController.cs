using Microsoft.AspNetCore.Mvc;
using Pecas.Models;

namespace Pecas.Controllers
{
    public class MovimentacaoController : Controller
    {
        private static IList<Movimentacao> Movimentacoes = new List<Movimentacao>()
        {
            new Movimentacao()
            {
                MovId = 1,
            }
        };
        public IActionResult Index()
        {
            return View(Movimentacoes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Movimentacao movimentacao)
        {
            movimentacao.MovId = Movimentacoes.Select(x => x.MovId).Max() + 1;
            Movimentacoes.Add(movimentacao);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(Movimentacoes.Where(movimentacao => movimentacao.MovId == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movimentacao movimentacao)
        {
            var movivemtacaoOld = Movimentacoes.Where(movimentacao => movimentacao.MovId == movimentacao.MovId).First();
            Movimentacoes.Remove(movivemtacaoOld);
            Movimentacoes.Add(movimentacao);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(Movimentacoes.Where(movimentacao => movimentacao.MovId == id).First());
        }
        public IActionResult Delete(int id)
        {
            return View(Movimentacoes.Where(movimentacao => movimentacao.MovId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Movimentacao movimentacao)
        {
            Movimentacoes.Remove(Movimentacoes.Where(x => x.MovId == movimentacao.MovId).First());
            return RedirectToAction("Index");
        }
    }
}

