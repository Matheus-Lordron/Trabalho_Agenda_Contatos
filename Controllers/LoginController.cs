using Microsoft.AspNetCore.Mvc;
using Trabalho_Agenda_Contatos.Auxiliar;
using Trabalho_Agenda_Contatos.Models;
using Trabalho_Agenda_Contatos.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trabalho_Agenda_Contatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
            
        

        public IActionResult Index()
        {
            // Se o user tiver já logado, enviar para Home

            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            
            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoUsuario(usuario);
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
