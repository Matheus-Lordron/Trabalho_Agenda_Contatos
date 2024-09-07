using Microsoft.AspNetCore.Mvc;
using Trabalho_Agenda_Contatos.Filters;

namespace Trabalho_Agenda_Contatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
