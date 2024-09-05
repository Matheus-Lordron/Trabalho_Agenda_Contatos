using Microsoft.AspNetCore.Mvc;
using Trabalho_Agenda_Contatos.Models;
using Trabalho_Agenda_Contatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trabalho_Agenda_Contatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
            
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
              if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                   if (usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha informada é inválida, tente novamente";

                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha incorreta(s), Por favor, tente novamente";
                }

              return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível autenticar o login, mais detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
