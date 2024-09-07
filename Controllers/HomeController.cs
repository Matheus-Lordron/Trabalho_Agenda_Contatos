using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trabalho_Agenda_Contatos.Filters;
using Trabalho_Agenda_Contatos.Models;

namespace Trabalho_Agenda_Contatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        // Ação para a página inicial
        public IActionResult Index()
        {
            return View();
        }

        // Ação para a página de privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // Ação para tratar erros
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
