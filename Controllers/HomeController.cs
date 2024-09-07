using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trabalho_Agenda_Contatos.Filters;
using Trabalho_Agenda_Contatos.Models;

namespace Trabalho_Agenda_Contatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        // A��o para a p�gina inicial
        public IActionResult Index()
        {
            return View();
        }

        // A��o para a p�gina de privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // A��o para tratar erros
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
